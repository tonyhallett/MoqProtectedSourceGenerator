using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikeCreationDependent
    {
        TypeSyntax GetMockedType(SyntaxNode node);
    }

}
