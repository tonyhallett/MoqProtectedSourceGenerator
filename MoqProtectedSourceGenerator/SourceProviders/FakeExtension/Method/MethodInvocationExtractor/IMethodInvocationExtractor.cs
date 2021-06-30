using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodInvocationExtractor
    {
        MethodInvocationExtraction Extract(InvocationExpressionSyntax invocation);
    }
}
