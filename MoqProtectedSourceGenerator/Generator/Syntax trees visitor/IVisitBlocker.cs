using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IVisitBlocker
    {
        bool Allow(SyntaxNode node);
    }
}
