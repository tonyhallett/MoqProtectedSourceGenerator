using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IParameterInfoSource
    {
        void AddSource(GeneratorExecutionContext context);
    }
}
