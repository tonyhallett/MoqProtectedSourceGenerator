using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IMethodExtensionMethodsFactory))]
    public class MethodExtensionMethodsFactory : IMethodExtensionMethodsFactory
    {
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IArgumentInfoExtractor argumentInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly ISetupExpressionArgument setupExpressionArgument;

        [ImportingConstructor]
        public MethodExtensionMethodsFactory(
            IMethodInvocationExtractor methodInvocationExtractor,
            IArgumentInfoExtractor argumentInfoExtractor,
            IProtectedMock protectedMock,
            ISetupExpressionArgument setupExpressionArgument
        )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.argumentInfoExtractor = argumentInfoExtractor;
            this.protectedMock = protectedMock;
            this.setupExpressionArgument = setupExpressionArgument;
        }

        public IMethodExtensionMethods Create()
        {
            return new MethodExtensionMethods(
                methodInvocationExtractor,
                argumentInfoExtractor,
                protectedMock,
                setupExpressionArgument);
        }
    }
}
