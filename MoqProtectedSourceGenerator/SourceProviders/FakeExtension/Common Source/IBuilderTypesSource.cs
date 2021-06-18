using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IBuilderTypesSource
    {
        void AddSource(GeneratorExecutionContext context);
    }

}
