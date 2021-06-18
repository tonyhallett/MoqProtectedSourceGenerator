using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedMockExtension
    {
        ITypeSymbol MockedType { get; }
        string ExtensionName { get; }
    }
}
