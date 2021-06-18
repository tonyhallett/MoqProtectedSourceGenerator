using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Generator]
    public class MoqProtectedSourceGenerator : ISourceGenerator
    {
        private CompositionContainer container;

        public void Execute(GeneratorExecutionContext context)
        {
            var mySyntaxReceiver = (context.SyntaxContextReceiver as MoqProtectedSyntaxReceiver);
            foreach (var sourceProvider in mySyntaxReceiver.SourceProviders)
            {
                sourceProvider.AddSource(context);
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
            InitializeContainer();
            context.RegisterForSyntaxNotifications(() => container.GetExportedValue<ISyntaxContextReceiver>());
        }

        private void InitializeContainer()
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            container = new CompositionContainer(assemblyCatalog);
            try
            {
                container.GetExportedValue<ISyntaxContextReceiver>();
            }
            catch (Exception exc)
            {
                var st = "";
            }
        }
    }
}
