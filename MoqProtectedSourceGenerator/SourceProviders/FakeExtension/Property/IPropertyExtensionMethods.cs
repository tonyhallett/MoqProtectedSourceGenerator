using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public interface IPropertyExtensionMethods
    {
        void ExtensionInvocation(InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider analyzerConfigOptions);
        void Initialize(List<ProtectedLikePropertyDetail> properties);
        List<Diagnostic> Diagnostics { get; }
        List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> Setups { get; }
        string GetExtensionMethods(string mockedTypeName, string likeTypeName, AnalyzerConfigOptionsProvider analyzerConfigOptions);
    }
}
