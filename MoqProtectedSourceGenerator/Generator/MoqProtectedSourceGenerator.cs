using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Generator]
    public class MoqProtectedSourceGenerator : ISourceGenerator
    {
        private readonly List<ISourceProvider> alwaysSourceProviders = new();

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var sourceProvider in alwaysSourceProviders)
            {
                sourceProvider.AddSource(context);
            }

            var mySyntaxReceiver = (context.SyntaxContextReceiver as SyntaxReceiver);
            foreach (var sourceProvider in mySyntaxReceiver.SourceProviders)
            {
                sourceProvider.AddSource(context);
            }

        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }
    }
}