using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(ISyntaxContextReceiver))]
    public class MoqProtectedSyntaxReceiver : SymbolVisitor, ISyntaxContextReceiver
    {
        private readonly IMoqBlocker moqBlocker;
        private readonly IEnumerable<ISyntaxSourceProvider> syntaxSourceProviders;
        public IEnumerable<ISourceProvider> SourceProviders =>
            syntaxSourceProviders.Select(sp => sp as ISourceProvider);

        [ImportingConstructor]
        public MoqProtectedSyntaxReceiver(IMoqBlocker moqBlocker, [ImportMany] IEnumerable<ISyntaxSourceProvider> syntaxSourceProviders)
        {
            this.moqBlocker = moqBlocker;
            this.syntaxSourceProviders = syntaxSourceProviders;
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
