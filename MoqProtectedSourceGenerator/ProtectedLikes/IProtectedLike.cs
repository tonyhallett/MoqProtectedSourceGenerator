using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLike
    {
        List<ProtectedLikeMethodDetails> Methods { get; }
        List<PropertyDetails> Properties { get; }
        ITypeSymbol MockedType { get; }
        string MinimallyUniqueLikeTypeName();

    }

}
