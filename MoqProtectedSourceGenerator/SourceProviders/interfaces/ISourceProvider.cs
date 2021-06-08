using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface ISourceProvider
    {
        void AddSource(GeneratorExecutionContext context);
    }
}