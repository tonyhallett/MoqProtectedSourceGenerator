using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodInvocationExtractor
    {
        BuildSetupOrVerify Extract(InvocationExpressionSyntax invocation);
    }
}
