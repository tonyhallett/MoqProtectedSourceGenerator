using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodFakeExtensionFactory
    {
        IFakeExtensionMethod Create(string likeTypeName, string mockedTypeName, INamespaceSymbol mockedTypeNamespace, ProtectedLikeMethodDetails methodDetails);
    }
}
