using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLike
    {
        List<ProtectedLikeMethodDetail> Methods { get; }
        List<ProtectedLikePropertyDetail> Properties { get; }
        ITypeSymbol MockedType { get; }
        string MinimallyUniqueLikeTypeName();

    }

}
