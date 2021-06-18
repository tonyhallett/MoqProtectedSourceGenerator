using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;

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
            string likeTypeName,
            string mockedTypeName,
            INamespaceSymbol mockedTypeNamespace,
            ProtectedLikeMethodDetails methodDetails
        )
        {
            var typeAndMethodDetails = new TypeAndMethodDetails
            {
                LikeTypeName = likeTypeName,
                MockedTypeName = mockedTypeName,
                MockedTypeNamespace = mockedTypeNamespace,
                MethodDetails = methodDetails
            };

            return new MethodFakeExtensionClass(
                typeAndMethodDetails,
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
