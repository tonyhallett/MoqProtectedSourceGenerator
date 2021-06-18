using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLike
    {
        List<ProtectedLikeMethodDetails> Methods { get; }
        List<PropertyDetails> Properties { get; }
        string LikeTypeName { get; }
        string MockedTypeName { get; }
        ITypeSymbol MockedType { get; }
        INamespaceSymbol MockedTypeNamespace { get; }

    }

}
