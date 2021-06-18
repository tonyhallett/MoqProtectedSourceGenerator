using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IBuilderTypesSource))]
    public class BuilderTypesSource : IBuilderTypesSource
    {
        private bool addedSource;
        public void AddSource(GeneratorExecutionContext context)
        {
            if (!addedSource)
            {
                Dictionary<string, string> builderTypes = ManifestResourceStringReader.Read("BuilderTypes");
                foreach (var kvp in builderTypes)
                {
                    context.AddSource($"{kvp.Key}.cs", kvp.Value);
                }
                addedSource = true;
            }

        }

    }

}
