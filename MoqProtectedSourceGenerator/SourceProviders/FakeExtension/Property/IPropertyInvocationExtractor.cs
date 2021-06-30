using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IPropertyInvocationExtractor
    {
        PropertyInvocationExtraction Extract(InvocationExpressionSyntax invocationExpression);
    }
}
