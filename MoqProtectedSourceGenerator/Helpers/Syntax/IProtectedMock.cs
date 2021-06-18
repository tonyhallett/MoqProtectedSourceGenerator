using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedMock
    {
        string GetClosedTypeName(string mockedType);
        TypeSyntax GetMockedType(SyntaxNode node);
        IProtectedMockExtension ProtectedMockExtensionInvocation(InvocationExpressionSyntax invocationExpression, SemanticModel semanticModel);
    }
}
