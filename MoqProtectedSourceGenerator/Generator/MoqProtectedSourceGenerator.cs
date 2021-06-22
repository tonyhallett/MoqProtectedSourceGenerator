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
        private readonly CompositionContainer container;
        [Import]
        internal IMoqBlockingSyntaxTreesVisitors moqBlockingSyntaxTreesVisitors;
        [ImportMany]
        internal IEnumerable<IExecuteAware> executeAwares;
        [ImportMany] 
        internal IEnumerable<IExecutingVisitingSourceProvider> sourceProviders;

        public MoqProtectedSourceGenerator()
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            container = new CompositionContainer(assemblyCatalog);
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
            //#if DEBUG
            //            if (!Debugger.IsAttached)
            //            {
            //                Debugger.Launch();
            //            }
            //#endif
        }

    }
}
