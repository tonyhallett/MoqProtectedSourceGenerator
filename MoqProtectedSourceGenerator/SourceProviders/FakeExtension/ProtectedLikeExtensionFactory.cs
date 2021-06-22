using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionsFactory))]
    public class ProtectedLikeExtensionFactory : IProtectedLikeExtensionsFactory
    {
        private readonly IMethodExtensionMethodsFactory methodExtensionMethodsFactory;
        private readonly IEnumerable<IProtectedLikeExtensionSource> sources;

        [ImportingConstructor]
        public ProtectedLikeExtensionFactory(
            IMethodExtensionMethodsFactory methodExtensionMethodsFactory,
            [ImportMany]
            IEnumerable<IProtectedLikeExtensionSource> sources
        )
        {
            this.methodExtensionMethodsFactory = methodExtensionMethodsFactory;
            this.sources = sources;
        }
        public IProtectedLikeExtensions Create(IProtectedLike protectedLike)
        {
            return new ProtectedLikeExtension(
                protectedLike,
                sources,
                methodExtensionMethodsFactory.Create()
                );
        }
    }
}
