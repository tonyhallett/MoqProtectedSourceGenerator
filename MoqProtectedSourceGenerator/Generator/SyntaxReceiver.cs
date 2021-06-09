using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class SyntaxReceiver : SymbolVisitor, ISyntaxContextReceiver
    {
        private readonly ProtectedLikes protectedLikes = new();

        private readonly MoqBlocker moqBlocker = new();

        private readonly List<ISyntaxSourceProvider> syntaxSourceProviders;
        public IEnumerable<ISourceProvider> SourceProviders =>
            syntaxSourceProviders.Select(sp => sp as ISourceProvider);

        public SyntaxReceiver()
        {
            syntaxSourceProviders = new List<ISyntaxSourceProvider>
            {
                new ProtectedLikeSourceProvider(protectedLikes),
                new FakeExtensionsSourceProvider(protectedLikes),
            };
        }
        private void VisitSourceProviders(GeneratorSyntaxContext context)
        {
            foreach (var syntaxSourceProvider in syntaxSourceProviders)
            {
                syntaxSourceProvider.OnVisitSyntaxNode(context);
            }
        }

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (moqBlocker.Allow(context.Node))
            {
                VisitSourceProviders(context);
            }
        }

    }
}
