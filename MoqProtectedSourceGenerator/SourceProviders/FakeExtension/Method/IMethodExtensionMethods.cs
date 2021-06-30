using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodExtensionMethods
    {
        void Initialize(List<ProtectedLikeMethodDetail> Methods);
        List<Diagnostic> Diagnostics { get; }
        List<(List<ArgumentInfo> argumentInfos, FileLocation fileLocation)> Setups { get; }
        Dictionary<string, SyntaxList<UsingDirectiveSyntax>> ExtensionsUsingsByFilePath { get; }
        void ExtensionInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider analyzerConfigOptions);
        string GetExtensionMethods(string mockedTypeName, string likeTypeName, AnalyzerConfigOptionsProvider analyzerConfigOptions);
    }
}
