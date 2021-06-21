using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public abstract class CommonSingleSource : IExecuteAware
    {
        private bool addedSource;

        protected abstract string HintName { get; }
        protected abstract List<string> Usings { get; }
        protected abstract string Source { get; }
        public void AddSource(GeneratorExecutionContext context)
        {
            if (!addedSource)
            {
                context.AddSource($"{HintName}.cs", SourceHelper.Create(Usings, Source));
                addedSource = true;
            }

        }

        public void Executing()
        {
            addedSource = false;
        }
    }

}
