using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IMatcherWrapperSource
    {
        void AddSource(GeneratorExecutionContext context);
    }

}
