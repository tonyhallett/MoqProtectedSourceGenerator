using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodExtensionMethods
    {
        void Initialize(List<ProtectedLikeMethodDetail> Methods);
        List<Diagnostic> Diagnostics { get; }
        List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> Setups { get; }
        Dictionary<string, SyntaxList<UsingDirectiveSyntax>> ExtensionsUsingsByFilePath { get; }
        void MethodInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel);
        string GetExtensionMethods(string mockedTypeName, string likeTypeName);
    }
}
