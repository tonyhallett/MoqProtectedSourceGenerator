using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public class MethodFakeExtensionClass : IFakeExtensionMethod
    {
        private static readonly List<string> defaultUsings = new()
        {
            "System.Collections.Generic",
            "System.Linq.Expressions",
            "Moq",
            "Moq.Protected",
            "MoqProtectedTyped"
        };
        private readonly Dictionary<string, SyntaxList<UsingDirectiveSyntax>> extensionsUsingsByFilePath = new();
        private List<string> usings;

        private readonly List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setups = new();
        private readonly List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> verifications = new();
        private readonly IProtectedLike protectedLike;
        private readonly ProtectedLikeMethodDetails methodDetails;
        private readonly string methodName;

        private string genericTypeParameters = "";
        private List<IParameterSymbol> parameters;
        private bool containsRefParameters;

        private bool isGlobal;
        private readonly Dictionary<bool, IReturnTypeDetails> returnTypeDetailsLookup = new()
        {
            { true, new VoidReturnTypeDetails() },
            { false, new ReturningReturnTypeDetails() },
        };

        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IParameterInfoExtractor parameterInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly IMatcherWrapperSource matcherWrapperSource;
        private readonly ISetupExpressionArgumentSource setupExpressionArgumentSource;
        private readonly IParameterInfoSource parameterInfoSource;
        private readonly IBuilderTypesSource builderTypesSource;
        private readonly List<Diagnostic> diagnostics = new();
        


        public MethodFakeExtensionClass(
            LikeAndMethodDetails likeAndMethodDetails,
            IMethodInvocationExtractor methodInvocationExtractor,
            IParameterInfoExtractor parameterInfoExtractor,
            IProtectedMock protectedMock,
            IMatcherWrapperSource matcherWrapperSource,
            ISetupExpressionArgumentSource setupExpressionArgumentSource,
            IParameterInfoSource parameterInfoSource,
            IBuilderTypesSource builderTypesSource
            )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.parameterInfoExtractor = parameterInfoExtractor;
            this.protectedMock = protectedMock;
            this.matcherWrapperSource = matcherWrapperSource;
            this.setupExpressionArgumentSource = setupExpressionArgumentSource;
            this.parameterInfoSource = parameterInfoSource;
            this.builderTypesSource = builderTypesSource;

            protectedLike = likeAndMethodDetails.ProtectedLike;
            methodDetails = likeAndMethodDetails.MethodDetails;

            InitializeParameters();
            InitializeUsings();

            methodName = methodDetails.Declaration.Identifier.Text;
        }

        private void InitializeUsings()
        {
            var methodNamespaces = methodDetails.UniqueNamespaces.Select(ns => ns.FullNamespace()).ToList();
            usings = defaultUsings.Concat(methodNamespaces).ToList();
        }

        private void InitializeParameters()
        {
            parameters = methodDetails.Symbol.Parameters.ToList();
            containsRefParameters = parameters.Any(p => p.RefKind == RefKind.Ref);
            if (methodDetails.Symbol.IsGenericMethod)
            {
                var typeParameters = methodDetails.Symbol.TypeParameters;

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
        }
        
        // will create a helper for this...
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

        private string FilePathAndLine(FileLocation fileLocation)
        {
            return "@\"" + $"{fileLocation.FilePath}_{fileLocation.Line + 1}" + "\"";
        }

        private string GetSetupsOrVerificationsInitializer(bool isSetups)
        {
            List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setupsOrVerifications = isSetups ? setups : verifications;
            var numSetupsOrVerifications = setupsOrVerifications.Count;
            if (numSetupsOrVerifications == 0)
            {
                return "{}";
            }
            var dictionaryEntryStringBuilder = new StringBuilder();
            dictionaryEntryStringBuilder.AggregateAppendIfLast(setupsOrVerifications, (setUpOrVerification, append, isLast) =>
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

        private string GetDictionary(bool isSetups)
        {
            var fieldName = isSetups ? "Setups" : "Verifications";
            return @$"    private static readonly Dictionary<string, List<ParameterInfo>> {fieldName} =
        new Dictionary<string, List<ParameterInfo>>{GetSetupsOrVerificationsInitializer(isSetups)};";
        }

        private (string statements, string expressionArrayVariable) GetExpressionConstants()
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

                    var value = isOut ? $"{parameterName}.Value" : $"({parameter.Type}){parameterName}";
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

        private string GetExtensionClass(string className,string mockedTypeName,string likeTypeName)
        {
            var expressionDelegate = ExpressionDelegate(likeTypeName);
            var methodBuilderType = MethodBuilderType(mockedTypeName);
            var (statements, expressionArrayVariable) = GetExpressionConstants();
            var extensionClass =
$@"public static class {className}
{{
{GetDictionary(true)}

{GetDictionary(false)}

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {{
        return sourceFileInfo + ""_"" + sourceLineNumber;
    }}

    {ExtensionMethodSignature(mockedTypeName)}
    {{
        var mock = protectedMock.Mock;
        var protectedLike = mock.Protected().As<{likeTypeName}>();

	    var likeParameter = Expression.Parameter(typeof({likeTypeName}));
            
        var matches = MatcherObserver.GetMatches();

        Expression<{expressionDelegate}> GetSetUpOrVerifyExpression(bool isSetup, string sourceFileInfo, int sourceLineNumber)
        {{
            var dictionary = isSetup ? Setups : Verifications;
            var parameterInfos = dictionary[GetKey(sourceFileInfo, sourceLineNumber)];
{statements}
            var call = Expression.Call(likeParameter, ""{methodName}"", new Type[] {{ {genericTypeParameters} }}, {expressionArrayVariable});
            return Expression.Lambda<{expressionDelegate}>(call, likeParameter);
        }}

        return new {methodBuilderType}(
            (sourceFileInfo, sourceLineNumber) => 
                protectedLike.Setup(GetSetUpOrVerifyExpression(true, sourceFileInfo, sourceLineNumber)),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => 
                protectedLike.Verify(GetSetUpOrVerifyExpression(false, sourceFileInfo, sourceLineNumber), times, failMessage)
        );
    }}
}}";
            if (isGlobal)
            {
                return extensionClass;
            }

            return extensionClass.PrefixEachLine("    ");
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

        private (string source, string className) GetSource()
        {
            var likeTypeName = protectedLike.MinimallyUniqueLikeTypeName();
            var mockedTypeName = protectedLike.MockedType.FullyQualifiedTypeName();
            //todo single class for all extension methods - single dictionary
            var uniqueMethodName = methodName;
            var className = $"{likeTypeName}_{uniqueMethodName}";
            string usings = GetUsings();
            string extensionClassAndNamespace = WithNamespace(GetExtensionClass(className, mockedTypeName, likeTypeName));
            var source =
@$"{usings}
{extensionClassAndNamespace}
";
            return (source, className);
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            ReportDiagnostics(context);
            isGlobal = IsGlobalExtensionClass(context.AnalyzerConfigOptions);
            var (source, className) = GetSource();
            context.AddSource($"{className}.cs", source);
            matcherWrapperSource.AddSource(context);
            setupExpressionArgumentSource.AddSource(context);
            parameterInfoSource.AddSource(context);
            builderTypesSource.AddSource(context);
        }

        private string ExpressionDelegate(string likeTypeName)
        {
            var methodDeclaration = methodDetails.Declaration;
            var returnTypeDetails = returnTypeDetailsLookup[methodDeclaration.ReturnTypeIsVoid()];
            return returnTypeDetails.ExpressionDelegate(likeTypeName, methodDeclaration.ReturnType.ToString());
        }

        private string MethodBuilderType(string mockedTypeName)
        {
            var methodDeclaration = methodDetails.Declaration;
            var returnTypeDetails = returnTypeDetailsLookup[methodDeclaration.ReturnTypeIsVoid()];
            return returnTypeDetails.MethodBuilderType(mockedTypeName, methodDeclaration.ReturnType.ToString());
        }

        private string ExtensionMethodSignature(string mockedTypeName)
        {
            var methodDeclaration = methodDetails.Declaration;
            var extensionMethod = methodDeclaration.MakeExtension(protectedMock.GetClosedTypeName(mockedTypeName), "protectedMock")
                .WithReturnType(SyntaxFactory.ParseTypeName($"I{MethodBuilderType(mockedTypeName)}"))
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

        private void ReportDiagnostics(GeneratorExecutionContext context)
        {
            foreach (var diagnostic in diagnostics)
            {
                context.ReportDiagnostic(diagnostic);
            }
        }

        private bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            var globalExtensionsOption = new Option<bool> { Key = $"{nameof(MoqProtectedSourceGenerator)}_GlobalExtensions", Value = true };
            configOptionProvider.GlobalOptions.GetOption(globalExtensionsOption);
            return globalExtensionsOption.Value;
        }

        public void AddSetupOrVerify(bool isSetup, List<ParameterInfo> parameterTypes, FileLocation fileLocation)
        {
            var setupsOrVerifications = isSetup ? setups : verifications;
            setupsOrVerifications.Add((parameterTypes, fileLocation));
        }

        public bool ExtensionInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel)
        {
            if (extensionName != methodName)
            {
                return false;
            }

            var buildSetupOrVerify = methodInvocationExtractor.Extract(invocationExpression);
            if (buildSetupOrVerify.Diagnostic != null)
            {
                diagnostics.Add(buildSetupOrVerify.Diagnostic);
            }
            if (!buildSetupOrVerify.Success)
            {
                return true;
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
                var incorrectOutParameters = false;
                for (var i = 0; i < parameters.Count; i++)
                {
                    if (parameters[i].RefKind == RefKind.Out && parameterInfos[i].Type != ParameterType.Out)
                    {
                        var location = arguments[i].GetLocation();
                        diagnostics.Add(Diagnostic.Create(
                            new DiagnosticDescriptor("MoqProtectedTyped4", "Out parameters must be inline - Out.From", "Out parameters must be inline - Out.From", "MoqProtectedTyped", DiagnosticSeverity.Error, true, "Out parameters must be inline - Out.From"), location
                        ));
                        incorrectOutParameters = true;
                    }
                }
                if (!incorrectOutParameters)
                {
                    if (containsRefParameters)
                    {
                        var extensionSyntaxTree = invocationExpression.SyntaxTree;
                        if (!extensionsUsingsByFilePath.ContainsKey(extensionSyntaxTree.FilePath))
                        {
                            extensionsUsingsByFilePath.Add(extensionSyntaxTree.FilePath, extensionSyntaxTree.GetCompilationUnitRoot().Usings);
                        }
                    }

                    AddSetupOrVerify(buildSetupOrVerify.IsSetup, parameterInfos, buildSetupOrVerify.FileLocation);
                }

            }

            return true;

        }

    }
}
