using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class LikeAndMethodDetails
    {
        public IProtectedLike ProtectedLike { get; set; }
        public ProtectedLikeMethodDetails MethodDetails { get; set; }
    }
}
