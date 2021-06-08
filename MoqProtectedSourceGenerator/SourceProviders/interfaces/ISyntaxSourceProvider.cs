using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface ISyntaxSourceProvider : ISourceProvider
    {
        void OnVisitSyntaxNode(GeneratorSyntaxContext context);
    }
}