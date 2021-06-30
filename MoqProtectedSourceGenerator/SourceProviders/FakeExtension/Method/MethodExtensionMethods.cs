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
    public class MethodExtensionMethods : IMethodExtensionMethods
    {
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IArgumentInfoExtractor argumentInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly ISetupExpressionArgument setupExpressionArgument;
        public Dictionary<string, SyntaxList<UsingDirectiveSyntax>> ExtensionsUsingsByFilePath { get; } = new();
        public List<(List<ArgumentInfo> argumentInfos, FileLocation fileLocation)> Setups { get; } = new();
        private List<ProtectedLikeMethodDetail> methods;
        private readonly Dictionary<bool, IReturnTypeDetails> returnTypeDetailsLookup = new()
        {
            { true, new VoidReturnTypeDetails() },
            { false, new ReturningReturnTypeDetails() },
        };

        public List<Diagnostic> Diagnostics { get; } = new();

        public MethodExtensionMethods(
            IMethodInvocationExtractor methodInvocationExtractor,
            IArgumentInfoExtractor argumentInfoExtractor,
            IProtectedMock protectedMock,
            ISetupExpressionArgument setupExpressionArgumentSource
        )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.argumentInfoExtractor = argumentInfoExtractor;
            this.protectedMock = protectedMock;
            this.setupExpressionArgument = setupExpressionArgumentSource;
        }

        public void Initialize(List<ProtectedLikeMethodDetail> methods)
        {
            this.methods = methods;
        }

        public string GetExtensionMethods(string mockedTypeName, string likeTypeName, AnalyzerConfigOptionsProvider _)
        {
            var stringBuilder = new StringBuilder();
            var numMethods = methods.Count;
            for (var i = 0; i < numMethods; i++)
            {
                var method = methods[i];
                stringBuilder.AppendLine(GetExtensionMethod(mockedTypeName, likeTypeName, method, i == numMethods - 1));
            }

            return stringBuilder.ToString();
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
            var argumentInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
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
                    lines.Add($"var expressionArg{count} = argumentInfos[{count}].RefAny;");
                }
                else
                {
                    addSetupExpressionStatement = true;
                    var isOut = parameter.RefKind == RefKind.Out;
                    var value = isOut ? $"{parameterName} == null ? ({parameter.Type})default({parameter.Type}) : {parameterName}.Value" : $"({parameter.Type}){parameterName}";
                    lines.Add($"var expressionArg{count} = {setupExpressionVariableName}.{setupExpressionArgument.MethodName}({value},argumentInfos[{count}]);");
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


            var setupExpressionStatement = addSetupExpressionStatement ? $"var {setupExpressionVariableName} = new {setupExpressionArgument.ClassName}(matches);{Environment.NewLine}" : "";
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

        public void ExtensionInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider _)
        {
            var extraction = methodInvocationExtractor.Extract(invocationExpression);
            if (extraction.Diagnostic != null)
            {
                Diagnostics.Add(extraction.Diagnostic);
            }
            if (!extraction.Success)
            {
                return;
            }

            var arguments = invocationExpression.ArgumentList.Arguments;
            var argumentExtraction = argumentInfoExtractor.Extract(arguments, semanticModel);
            if (argumentExtraction.Diagnostics.Count > 0)
            {
                Diagnostics.AddRange(argumentExtraction.Diagnostics);
            }
            else
            {
                var argumentInfos = argumentExtraction.ArgumentInfos;
                var extensionSyntaxTree = invocationExpression.SyntaxTree;
                var hasRefParameters = methods.Where(m => m.Symbol.Name == extensionName).Any(m => m.Symbol.Parameters.Any((p => p.RefKind == RefKind.Ref)));
                if (hasRefParameters)
                {
                    if (!ExtensionsUsingsByFilePath.ContainsKey(extensionSyntaxTree.FilePath))
                    {
                        ExtensionsUsingsByFilePath.Add(extensionSyntaxTree.FilePath, extensionSyntaxTree.GetCompilationUnitRoot().Usings);
                    }
                }

                Setups.Add((argumentInfos, extraction.FileLocation));

            }

        }
    }
}
