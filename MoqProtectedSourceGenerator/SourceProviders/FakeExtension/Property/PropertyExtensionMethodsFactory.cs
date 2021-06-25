using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IPropertyExtensionMethodsFactory))]
    public class PropertyExtensionMethodsFactory : IPropertyExtensionMethodsFactory
    {
        public IPropertyExtensionMethods Create()
        {
            return new PropertyExtensionMethods();
        }
    }
}
