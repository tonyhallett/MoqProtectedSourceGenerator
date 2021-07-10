using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Generator]
    public class MoqProtectedSourceGenerator : ISourceGenerator
    {
        [Import]
        internal IMoqBlockingSyntaxTreesVisitors moqBlockingSyntaxTreesVisitors;
        [ImportMany]
        internal IEnumerable<IExecuteAware> executeAwares;
        [ImportMany]
        internal IEnumerable<IExecutingVisitingSourceProvider> sourceProviders;

        public MoqProtectedSourceGenerator()
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(assemblyCatalog);
            container.SatisfyImportsOnce(this);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var executeAware in executeAwares)
            {
                executeAware.Executing();
            }

            foreach (var sourceProvider in sourceProviders)
            {
                sourceProvider.Executing(context);
            }

            moqBlockingSyntaxTreesVisitors.TreeVisitors = sourceProviders;
            moqBlockingSyntaxTreesVisitors.VisitTrees(context.Compilation.SyntaxTrees);

            foreach (var sp in sourceProviders)
            {
                sp.AddSource();
            }

        }

        public void Initialize(GeneratorInitializationContext context)
        {

#pragma warning disable S125 // Sections of code should not be commented out
            /*
                            #if DEBUG
                            if (!Debugger.IsAttached)
                            {
                                Debugger.Launch();
                            }
                            #endif
                        */
#pragma warning restore S125 // Sections of code should not be commented out
        }


    }
}
