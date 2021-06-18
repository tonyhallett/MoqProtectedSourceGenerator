using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{

    [Export(typeof(IMethodFakeExtensionFactory))]
    public class MethodFakeExtensionFactory : IMethodFakeExtensionFactory
    {
        private readonly IMethodInvocationExtractor methodInvocationExtractor;
        private readonly IParameterInfoExtractor parameterTypeExtractor;
        private readonly IProtectedMock protectedMock;
        private readonly IMatcherWrapperSource matcherWrapperSource;
        private readonly ISetupExpressionArgumentSource setupExpressionArgumentSource;
        private readonly IParameterInfoSource parameterInfoSource;
        private readonly IBuilderTypesSource builderTypesSource;

        [ImportingConstructor]
        public MethodFakeExtensionFactory(
            IMethodInvocationExtractor methodInvocationExtractor,
            IParameterInfoExtractor parameterTypeExtractor,
            IProtectedMock protectedMock,
            IMatcherWrapperSource matcherWrapperSource,
            ISetupExpressionArgumentSource setupExpressionArgumentSource,
            IParameterInfoSource parameterInfoSource,
            IBuilderTypesSource builderTypesSource
            )
        {
            this.methodInvocationExtractor = methodInvocationExtractor;
            this.parameterTypeExtractor = parameterTypeExtractor;
            this.protectedMock = protectedMock;
            this.matcherWrapperSource = matcherWrapperSource;
            this.setupExpressionArgumentSource = setupExpressionArgumentSource;
            this.parameterInfoSource = parameterInfoSource;
            this.builderTypesSource = builderTypesSource;
        }
        public IFakeExtensionMethod Create(
            IProtectedLike protectedLike,
            ProtectedLikeMethodDetails methodDetails
        )
        {
            var likeAndMethodDetails = new LikeAndMethodDetails
            {
                ProtectedLike = protectedLike,
                MethodDetails = methodDetails
            };

            return new MethodFakeExtensionClass(
                likeAndMethodDetails,
                methodInvocationExtractor,
                parameterTypeExtractor,
                protectedMock,
                matcherWrapperSource,
                setupExpressionArgumentSource,
                parameterInfoSource,
                builderTypesSource
            );
        }
    }
}
