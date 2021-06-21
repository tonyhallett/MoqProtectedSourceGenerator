using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionsFactory))]
    public class ProtectedLikeExtensionFactory : IProtectedLikeExtensionsFactory
    {
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IParameterInfoExtractor parameterInfoExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly IMatcherWrapperSource matcherWrapperSource;
        private readonly ISetupExpressionArgumentSource setupExpressionArgumentSource;
        private readonly IParameterInfoSource parameterInfoSource;
        private readonly IBuilderTypesSource builderTypesSource;

        [ImportingConstructor]
        public ProtectedLikeExtensionFactory(
            IMethodInvocationExtractor methodInvocationExtractor,
            IParameterInfoExtractor parameterInfoExtractor,
            IProtectedMock protectedMock,
            IMatcherWrapperSource matcherWrapperSource,
            ISetupExpressionArgumentSource setupExpressionArgumentSource,
            IParameterInfoSource parameterInfoSource,
            IBuilderTypesSource builderTypesSource
        )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.parameterInfoExtractor = parameterInfoExtractor;
            this.protectedMock = protectedMock;
            this.matcherWrapperSource = matcherWrapperSource;
            this.setupExpressionArgumentSource = setupExpressionArgumentSource;
            this.parameterInfoSource = parameterInfoSource;
            this.builderTypesSource = builderTypesSource;
        }
        public IProtectedLikeExtensions Create(IProtectedLike protectedLike)
        {
            return new ProtectedLikeExtension(
                protectedLike,
                methodInvocationExtractor,
                parameterInfoExtractor,
                protectedMock,
                matcherWrapperSource,
                setupExpressionArgumentSource,
                parameterInfoSource,
                builderTypesSource);
        }
    }
}
