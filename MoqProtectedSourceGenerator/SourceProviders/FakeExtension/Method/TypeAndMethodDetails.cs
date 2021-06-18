using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class TypeAndMethodDetails
    {
        public string LikeTypeName { get; set; }
        public string MockedTypeName { get; set; }
        public INamespaceSymbol MockedTypeNamespace { get; set; }
        public ProtectedLikeMethodDetails MethodDetails { get; set; }
    }
}
