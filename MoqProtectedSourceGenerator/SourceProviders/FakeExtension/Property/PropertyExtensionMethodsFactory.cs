using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IPropertyExtensionMethodsFactory))]
    public class PropertyExtensionMethodsFactory : IPropertyExtensionMethodsFactory
    {
        private readonly IPropertyInvocationExtractor propertyInvocationExtractor;
        private readonly IArgumentInfoExtractor argumentInfoExtractor;
        private readonly IOptionsProvider optionsProvider;

        [ImportingConstructor]
        public PropertyExtensionMethodsFactory(
            IPropertyInvocationExtractor propertyInvocationExtractor,
            IArgumentInfoExtractor argumentInfoExtractor,
            IOptionsProvider optionsProvider
            )
        {
            this.propertyInvocationExtractor = propertyInvocationExtractor;
            this.argumentInfoExtractor = argumentInfoExtractor;
            this.optionsProvider = optionsProvider;
        }
        public IPropertyExtensionMethods Create()
        {
            return new PropertyExtensionMethods(propertyInvocationExtractor, argumentInfoExtractor, optionsProvider);
        }
    }
}
