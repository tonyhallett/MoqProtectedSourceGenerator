using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface ITreeVisitor
    {
        void OnVisitTree(SyntaxTree syntaxTree);
        void OnVisitSyntaxNode(SyntaxNode node);
    }
}
