using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IExecutingVisitingSourceProvider : ITreeVisitor
    {
        void Executing(GeneratorExecutionContext context);
        void AddSource();
    }
}
