using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IMethodFakeExtensionFactory
    {
        IFakeExtensionMethod Create(IProtectedLike protectedLike, ProtectedLikeMethodDetails methodDetails);
    }
}
