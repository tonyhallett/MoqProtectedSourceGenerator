using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionsFactory))]
    public class ProtectedLikeExtensionClassesFactory : IProtectedLikeExtensionsFactory
    {
        private readonly IMethodFakeExtensionFactory methodFakeExtensionFactory;

        [ImportingConstructor]
        public ProtectedLikeExtensionClassesFactory(IMethodFakeExtensionFactory methodFakeExtensionFactory)
        {
            this.methodFakeExtensionFactory = methodFakeExtensionFactory;
        }
        public IProtectedLikeExtensions Create(IProtectedLike protectedLike)
        {
            return new ProtectedLikeExtensionClasses(protectedLike, methodFakeExtensionFactory);
        }
    }
}
