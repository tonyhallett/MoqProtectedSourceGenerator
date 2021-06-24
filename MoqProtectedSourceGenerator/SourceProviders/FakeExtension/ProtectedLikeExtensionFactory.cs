using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionsFactory))]
    public class ProtectedLikeExtensionFactory : IProtectedLikeExtensionsFactory
    {
        private readonly IMethodExtensionMethodsFactory methodExtensionMethodsFactory;
        private readonly IEnumerable<IProtectedLikeExtensionSource> sources;
        private readonly IGlobalClassFromOptions globalClassFromOptions;

        [ImportingConstructor]
        public ProtectedLikeExtensionFactory(
            IMethodExtensionMethodsFactory methodExtensionMethodsFactory,
            [ImportMany]
            IEnumerable<IProtectedLikeExtensionSource> sources,
            IGlobalClassFromOptions globalClassFromOptions
        )
        {
            this.methodExtensionMethodsFactory = methodExtensionMethodsFactory;
            this.sources = sources;
            this.globalClassFromOptions = globalClassFromOptions;
        }
        public IProtectedLikeExtensions Create(IProtectedLike protectedLike)
        {
            return new ProtectedLikeExtension(
                protectedLike,
                sources,
                methodExtensionMethodsFactory.Create(),
                globalClassFromOptions
                );
        }
    }
}
