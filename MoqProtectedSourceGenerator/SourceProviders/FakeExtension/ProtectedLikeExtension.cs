using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikeExtension : IProtectedLikeExtensions
    {
        private readonly List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setups = new();
        private readonly List<Diagnostic> diagnostics = new();
        private readonly Dictionary<string, SyntaxList<UsingDirectiveSyntax>> extensionsUsingsByFilePath = new();
        private bool isGlobal;
        private static readonly List<string> defaultUsings = new()
        {
            "System.Collections.Generic",
            "System.Linq.Expressions",
            "Moq",
            "Moq.Protected",
            "MoqProtectedTyped"
        };
        private List<string> usings;
        private readonly IProtectedLike protectedLike;
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IParameterInfoExtractor parameterInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly IMatcherWrapperSource matcherWrapperSource;
        private readonly ISetupExpressionArgumentSource setupExpressionArgumentSource;
        private readonly IParameterInfoSource parameterInfoSource;
        private readonly IBuilderTypesSource builderTypesSource;
        private readonly List<string> methodNames;
        private readonly Dictionary<bool, IReturnTypeDetails> returnTypeDetailsLookup = new()
        {
            { true, new VoidReturnTypeDetails() },
            { false, new ReturningReturnTypeDetails() },
        };

        public ProtectedLikeExtension(
            IProtectedLike protectedLike,
            IMethodInvocationExtractor methodInvocationExtractor,
            IParameterInfoExtractor parameterInfoExtractor,
            IProtectedMock protectedMock,
            IMatcherWrapperSource matcherWrapperSource,
            ISetupExpressionArgumentSource setupExpressionArgumentSource,
            IParameterInfoSource parameterInfoSource,
            IBuilderTypesSource builderTypesSource
            )
        {
            this.protectedLike = protectedLike;
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.parameterInfoExtractor = parameterInfoExtractor;
            this.protectedMock = protectedMock;
            this.matcherWrapperSource = matcherWrapperSource;
            this.setupExpressionArgumentSource = setupExpressionArgumentSource;
            this.parameterInfoSource = parameterInfoSource;
            this.builderTypesSource = builderTypesSource;

            methodNames = protectedLike.Methods.Select(m => m.Declaration.Identifier.Text).ToList();
            InitializeUsings();
        }

        private void InitializeUsings()
        {
            usings = new List<string>(defaultUsings);
            foreach (var methodDetails in protectedLike.Methods)
            {
                usings.AddRange(methodDetails.UniqueNamespaces.Select(ns => ns.FullNamespace()));
            }
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            ReportDiagnostics(context);
            isGlobal = IsGlobalExtensionClass(context.AnalyzerConfigOptions);
            var (source, className) = GetSource();
            context.AddSource($"{className}.cs", source);
            AddCommonSources(context);
        }

        private (string source, string className) GetSource()
        {
            var likeTypeName = protectedLike.MinimallyUniqueLikeTypeName();
            var mockedTypeName = protectedLike.MockedType.FullyQualifiedTypeName();
            var className = $"{likeTypeName}_FakeExtension";
            string usings = GetUsings();
            string extensionClassAndNamespace = WithNamespace(GetExtensionClass(className, mockedTypeName, likeTypeName));
            var source =
@$"{usings}
{extensionClassAndNamespace}
";
            return (source, className);
        }

        private (string statements, string expressionArrayVariable) GetExpressionConstants(ImmutableArray<IParameterSymbol> parameters)
        {
            var setupExpressionVariableName = "setupExpression";
            var stringBuilder = new StringBuilder();
            var lines = new List<string> { };
            var count = 0;
            var addSetupExpressionStatement = false;

            foreach (var parameter in parameters)
            {
                var parameterName = parameter.Name;
                var isRef = parameter.RefKind == RefKind.Ref;
                if (isRef)
                {
                    lines.Add($"var expressionArg{count} = parameterInfos[{count}].RefAny;");
                }
                else
                {
                    addSetupExpressionStatement = true;
                    var isOut = parameter.RefKind == RefKind.Out;
                    var value = isOut ? $"{parameterName} == null ? ({parameter.Type})default({parameter.Type}) : {parameterName}.Value" : $"({parameter.Type}){parameterName}";
                    lines.Add($"var expressionArg{count} = {setupExpressionVariableName}.{setupExpressionArgumentSource.MethodName}({value},parameterInfos[{count}]);");
                }

                count++;
            }
            if (count == 0)
            {
                lines.Add("var expressionArgs = new Expression[]{};");
            }
            else
            {
                lines.Add("var expressionArgs = new Expression[]{");
                for (var i = 0; i < count; i++)
                {
                    var comma = i == count - 1 ? "" : ",";
                    lines.Add($"    expressionArg{i}{comma}");

                }
                lines.Add("};");
            }


            var setupExpressionStatement = addSetupExpressionStatement ? $"var {setupExpressionVariableName} = new {setupExpressionArgumentSource.ClassName}(matches);{Environment.NewLine}" : "";
            lines.Insert(0, setupExpressionStatement);
            foreach (var line in lines)
            {
                stringBuilder.Append("            ");
                stringBuilder.AppendLine(line);
            }

            return (stringBuilder.ToString(), "expressionArgs");
        }

        private string ExtensionMethodSignature(string mockedTypeName, MethodDeclarationSyntax methodDeclaration)
        {
            var extensionMethod = methodDeclaration.MakeExtension(protectedMock.GetClosedTypeName(mockedTypeName), "protectedMock")
                .WithReturnType(SyntaxFactory.ParseTypeName($"I{MethodBuilderType(mockedTypeName, methodDeclaration)}"))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
                .WithModifiers(
                    new SyntaxTokenList(
                        new SyntaxToken[]{
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.StaticKeyword)
                        }
                    )
                );
            extensionMethod = SwapOutsForOutType(extensionMethod);

            return extensionMethod.NormalizeWhitespace().ToFullString();
        }

        private MethodDeclarationSyntax SwapOutsForOutType(MethodDeclarationSyntax methodDeclarationSyntax)
        {
            return methodDeclarationSyntax.WithParameterList(
                methodDeclarationSyntax.ParameterList.WithParameters(
                    SwapOutsForOutTypeImplementation(methodDeclarationSyntax.ParameterList.Parameters)));
        }

        private SeparatedSyntaxList<ParameterSyntax> SwapOutsForOutTypeImplementation(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            var swapped = parameters.Select(p =>
            {
                var modifiers = p.Modifiers;
                var outToken = modifiers.FirstOrDefault(token => token.IsKind(SyntaxKind.OutKeyword));
                if (outToken != default)
                {
                    var parameter = p.WithModifiers(modifiers.Remove(outToken)).WithType(SyntaxFactory.ParseTypeName(OutType.ParameterType(p.Type)));
                    return parameter;
                }
                return p;
            });
            return SyntaxFactory.SeparatedList(swapped);
        }

        private string GetExtensionMethod(string mockedTypeName, string likeTypeName, ProtectedLikeMethodDetail methodDetail, bool isLast)
        {
            var expressionDelegate = ExpressionDelegate(likeTypeName, methodDetail.Declaration);
            var methodBuilderType = MethodBuilderType(mockedTypeName, methodDetail.Declaration);
            var methodName = methodDetail.Declaration.Identifier.Text;
            var genericTypeParameters = "";
            if (methodDetail.Symbol.IsGenericMethod)
            {
                var typeParameters = methodDetail.Symbol.TypeParameters;

                var count = 0;
                var numGenericTypes = typeParameters.Length;

                foreach (var parameter in typeParameters)
                {
                    var typeName = parameter.Name;
                    genericTypeParameters += $"typeof({typeName})";
                    if (count != numGenericTypes - 1)
                    {
                        genericTypeParameters += ", ";
                    }
                    count++;
                }
            }


            var (statements, expressionArrayVariable) = GetExpressionConstants(methodDetail.Symbol.Parameters);

            var extensionMethod =
            $@"    {ExtensionMethodSignature(mockedTypeName, methodDetail.Declaration)}
    {{
        var mock = protectedMock.Mock;
        var protectedLike = mock.Protected().As<{likeTypeName}>();

	    var likeParameter = Expression.Parameter(typeof({likeTypeName}));
            
        var matches = MatcherObserver.GetMatches();

        Expression<{expressionDelegate}> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber)
        {{
            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
{statements}
            var call = Expression.Call(likeParameter, ""{methodName}"", new Type[] {{ {genericTypeParameters} }}, {expressionArrayVariable});
            return Expression.Lambda<{expressionDelegate}>(call, likeParameter);
        }}

        return new {methodBuilderType}(
            (sourceFileInfo, sourceLineNumber) => 
                protectedLike.Setup(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber)),
            (sourceFileInfo, sourceLineNumber) => 
                protectedLike.SetupSequence(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber)),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => 
                protectedLike.Verify(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber), times, failMessage)
        );
    }}{(isLast ? "" : Environment.NewLine)}";
            return extensionMethod;
        }

        private string ExpressionDelegate(string likeTypeName, MethodDeclarationSyntax methodDeclaration)
        {
            var returnTypeDetails = returnTypeDetailsLookup[methodDeclaration.ReturnTypeIsVoid()];
            return returnTypeDetails.ExpressionDelegate(likeTypeName, methodDeclaration.ReturnType.ToString());
        }

        private string MethodBuilderType(string mockedTypeName, MethodDeclarationSyntax methodDeclaration)
        {
            var returnTypeDetails = returnTypeDetailsLookup[methodDeclaration.ReturnTypeIsVoid()];
            return returnTypeDetails.MethodBuilderType(mockedTypeName, methodDeclaration.ReturnType.ToString());
        }

        private string GetDictionary()
        {
            return @$"    private static readonly Dictionary<string, List<ParameterInfo>> Setups =
        new Dictionary<string, List<ParameterInfo>>{GetSetupsInitializer()};";
        }

        private string FilePathAndLine(FileLocation fileLocation)
        {
            return "@\"" + $"{fileLocation.FilePath}_{fileLocation.Line + 1}" + "\"";
        }

        private string GetSetupsInitializer()
        {
            if (setups.Count == 0)
            {
                return "{}";
            }
            var dictionaryEntryStringBuilder = new StringBuilder();
            dictionaryEntryStringBuilder.AggregateAppendIfLast(setups, (setUpOrVerification, append, isLast) =>
            {
                var comma = isLast ? "" : ",";
                append(@$"            {{
                {FilePathAndLine(setUpOrVerification.fileLocation)},
                {ParameterInfo.SourceList(setUpOrVerification.parameterInfos)}
            }}{comma}");
            });

            return @$"
        {{
{dictionaryEntryStringBuilder}
        }}";
        }

        private string GetExtensionMethods(string mockedTypeName, string likeTypeName)
        {
            var stringBuilder = new StringBuilder();
            var methods = protectedLike.Methods;
            var numMethods = methods.Count;
            for (var i = 0; i < numMethods; i++)
            {
                var method = methods[i];
                stringBuilder.AppendLine(GetExtensionMethod(mockedTypeName, likeTypeName, method, i == numMethods - 1));
            }

            return stringBuilder.ToString();
        }

        private string GetExtensionClass(string className, string mockedTypeName, string likeTypeName)
        {
            var extensionClass =
$@"public static class {className}
{{
{GetDictionary()}

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {{
        return sourceFileInfo + ""_"" + sourceLineNumber;
    }}

{GetExtensionMethods(mockedTypeName, likeTypeName)}
}}";
            if (isGlobal)
            {
                return extensionClass;
            }

            return extensionClass.PrefixEachLine("    ");
        }

        private string WithNamespace(string extensionClass)
        {
            if (!isGlobal)
            {
                return $@"namespace {MoqProtectedGenerated.NamespaceName}
{{
{extensionClass}
}}";
            }
            else
            {
                return extensionClass;
            }
        }

        private string GetUsings()
        {
            if (isGlobal)
            {
                usings.Add(MoqProtectedGenerated.NamespaceName);
            }

            List<string> aliases = new List<string>();
            foreach (var kvp in extensionsUsingsByFilePath)
            {
                foreach (var @using in kvp.Value)
                {
                    var usingName = @using.Name.ToString();
                    var alias = @using.Alias;
                    if (alias != null)
                    {
                        aliases.Add(@using.ToString());
                    }
                    else
                    {
                        usings.Add(usingName);
                    }
                }
            }

            var regularUsings = SourceHelper.CreateUsings(usings);

            if (aliases.Count == 0)
            {
                return regularUsings;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(regularUsings);
            foreach (var alias in aliases)
            {
                stringBuilder.AppendLine(alias);
            }
            var result = stringBuilder.ToString();
            return result;
        }

        private bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            var globalExtensionsOption = new Option<bool> { Key = $"{nameof(MoqProtectedSourceGenerator)}_GlobalExtensions", Value = true };
            configOptionProvider.GlobalOptions.GetOption(globalExtensionsOption);
            return globalExtensionsOption.Value;
        }

        private void AddCommonSources(GeneratorExecutionContext context)
        {
            matcherWrapperSource.AddSource(context);
            setupExpressionArgumentSource.AddSource(context);
            parameterInfoSource.AddSource(context);
            builderTypesSource.AddSource(context);
        }

        private void ReportDiagnostics(GeneratorExecutionContext context)
        {
            foreach (var diagnostic in diagnostics)
            {
                context.ReportDiagnostic(diagnostic);
            }
        }

        public void ExtensionInvocation(InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, GeneratorExecutionContext context)
        {
            if (methodNames.Contains(extensionName))
            {
                MethodInvocation(invocation, extensionName, semanticModel);
            }
        }

        private void MethodInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel)
        {
            var buildSetupOrVerify = methodInvocationExtractor.Extract(invocationExpression);
            if (buildSetupOrVerify.Diagnostic != null)
            {
                diagnostics.Add(buildSetupOrVerify.Diagnostic);
            }
            if (!buildSetupOrVerify.Success)
            {
                return;
            }

            var arguments = invocationExpression.ArgumentList.Arguments;
            var parameterExtraction = parameterInfoExtractor.Extract(arguments, semanticModel);
            if (parameterExtraction.Diagnostics.Count > 0)
            {
                diagnostics.AddRange(parameterExtraction.Diagnostics);
            }
            else
            {
                var parameterInfos = parameterExtraction.ParameterInfos;
                var extensionSyntaxTree = invocationExpression.SyntaxTree;
                var hasRefParameters = protectedLike.Methods.Where(m => m.Symbol.Name == extensionName).Any(m => m.Symbol.Parameters.Any((p => p.RefKind == RefKind.Ref)));
                if (hasRefParameters)
                {
                    if (!extensionsUsingsByFilePath.ContainsKey(extensionSyntaxTree.FilePath))
                    {
                        extensionsUsingsByFilePath.Add(extensionSyntaxTree.FilePath, extensionSyntaxTree.GetCompilationUnitRoot().Usings);
                    }
                }

                setups.Add((parameterInfos, buildSetupOrVerify.FileLocation));

            }

        }

    }
}
