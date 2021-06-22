using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IMethodExtensionMethodsFactory))]
    public class MethodExtensionMethodsFactory : IMethodExtensionMethodsFactory
    {
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IParameterInfoExtractor parameterInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly ISetupExpressionArgument setupExpressionArgument;

        [ImportingConstructor]
        public MethodExtensionMethodsFactory(
            IMethodInvocationExtractor methodInvocationExtractor,
            IParameterInfoExtractor parameterInfoExtractor,
            IProtectedMock protectedMock,
            ISetupExpressionArgument setupExpressionArgument
        )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.parameterInfoExtractor = parameterInfoExtractor;
            this.protectedMock = protectedMock;
            this.setupExpressionArgument = setupExpressionArgument;
        }

        public IMethodExtensionMethods Create()
        {
            return new MethodExtensionMethods(
                methodInvocationExtractor, 
                parameterInfoExtractor, 
                protectedMock, 
                setupExpressionArgument);
        }
    }
}
