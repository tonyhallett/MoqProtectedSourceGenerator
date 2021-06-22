using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IExecutingVisitingSourceProvider))]
    public class FakeExtensionsSourceProvider : IExecutingVisitingSourceProvider
    {
        private readonly IProtectedLikes protectedLikes;
        private readonly IProtectedMock protectedMock;
        private readonly IProtectedLikeExtensionsFactory protectedLikeExtensionsFactory;
#pragma warning disable RS1024 // Compare symbols correctly - false positive waiting for version 3.3 https://github.com/dotnet/roslyn-analyzers/issues/4845
        private readonly Dictionary<ITypeSymbol, IProtectedLikeExtensions> protectedLikeExtensionsLookup = new(SymbolEqualityComparer.Default);
#pragma warning restore RS1024 // Compare symbols correctly
        private GeneratorExecutionContext context;
        private SemanticModel semanticModel;

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
            protectedLikeExtensionsLookup.Add(
                protectedLike.MockedType,
                protectedLikeExtensionsFactory.Create(protectedLike)
            );
        }

        public void Executing(GeneratorExecutionContext context)
        {
            protectedLikeExtensionsLookup.Clear();

            this.context = context;
        }

        public void AddSource()
        {
            if (protectedLikeExtensionsLookup.Count > 0)
            {
                foreach (var protectedLikeExtensions in protectedLikeExtensionsLookup.Values)
                {
                    protectedLikeExtensions.AddSource(context);
                }
            }
        }

        public void OnVisitTree(SyntaxTree syntaxTree)
        {
            semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
        }

        public void OnVisitSyntaxNode(SyntaxNode node)
        {
            if (protectedLikeExtensionsLookup.Count > 0)
            {
                if (node is InvocationExpressionSyntax invocation)
                {
                    var protectedMockExtension = protectedMock.ProtectedMockExtensionInvocation(invocation, semanticModel);
                    if (protectedMockExtension != null)
                    {
                        var protectedLikeExtensions = protectedLikeExtensionsLookup[protectedMockExtension.MockedType];
                        protectedLikeExtensions.ExtensionInvocation(invocation, protectedMockExtension.ExtensionName, semanticModel,context);
                    }
                }
            }
        }
    }
}
