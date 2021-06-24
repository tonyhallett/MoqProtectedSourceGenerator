using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikeExtensionSource
    {
        void AddSource(GeneratorExecutionContext context);
    }

}
