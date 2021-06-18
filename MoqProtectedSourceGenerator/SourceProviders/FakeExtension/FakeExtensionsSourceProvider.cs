using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(ISyntaxSourceProvider))]
    public class FakeExtensionsSourceProvider : ISyntaxSourceProvider
    {
        private readonly IProtectedLikes protectedLikes;
        private readonly IProtectedMock protectedMock;
        private readonly IProtectedLikeExtensionsFactory protectedLikeExtensionsFactory;
#pragma warning disable RS1024 // Compare symbols correctly - false positive waiting for version 3.3 https://github.com/dotnet/roslyn-analyzers/issues/4845
        private readonly Dictionary<ITypeSymbol, IProtectedLikeExtensions> protectedLikeExtensionsLookup = new(SymbolEqualityComparer.Default);
#pragma warning restore RS1024 // Compare symbols correctly
        private bool hasProtectedLikes;

        [ImportingConstructor]
        public FakeExtensionsSourceProvider(
            IProtectedLikes protectedLikes,
            IProtectedMock protectedMock,
            IProtectedLikeExtensionsFactory protectedLikeExtensionsFactory)
        {
            this.protectedLikes = protectedLikes;
            this.protectedMock = protectedMock;
            this.protectedLikeExtensionsFactory = protectedLikeExtensionsFactory;
            this.protectedLikes.NewLikeEvent += ProtectedLikes_NewLikeEvent;
        }

        private void ProtectedLikes_NewLikeEvent(IProtectedLike protectedLike)
        {
            hasProtectedLikes = true;
            protectedLikeExtensionsLookup.Add(
                protectedLike.MockedType,
                protectedLikeExtensionsFactory.Create(protectedLike)
            );
        }

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (hasProtectedLikes)
            {
                var node = context.Node;
                if (node is InvocationExpressionSyntax invocation)
                {
                    var protectedMockExtension = protectedMock.ProtectedMockExtensionInvocation(invocation, context.SemanticModel);
                    if (protectedMockExtension != null)
                    {
                        var protectedLikeExtensions = protectedLikeExtensionsLookup[protectedMockExtension.MockedType];
                        protectedLikeExtensions.ExtensionInvocation(invocation, protectedMockExtension.ExtensionName, context.SemanticModel);
                    }
                }
            }
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            if (protectedLikeExtensionsLookup.Count > 0)
            {
                foreach (var protectedLikeExtensions in protectedLikeExtensionsLookup.Values)
                {
                    protectedLikeExtensions.AddSource(context);
                }
            }

        }
    }
}
