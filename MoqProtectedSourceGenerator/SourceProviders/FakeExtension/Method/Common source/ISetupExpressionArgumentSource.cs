using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface ISetupExpressionArgumentSource
    {
        void AddSource(GeneratorExecutionContext context);
        string ClassName { get; }
        string MethodName { get; }
    }

}
