using System;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IGlobalClassFromOptions))]
    public class GlobalClassFromOptions : IGlobalClassFromOptions
    {
        private readonly IOptionsProvider optionsProvider;

        [ImportingConstructor]
        public GlobalClassFromOptions(IOptionsProvider optionsProvider)
        {
            this.optionsProvider = optionsProvider;
        }

        public string Get(string usings, string extensionClass, AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider)
        {
            var isGlobal = optionsProvider.IsGlobalExtensionClass(analyzerConfigOptionsProvider);
            usings = GetUsings(usings, isGlobal);
            string extensionClassAndNamespace = WithNamespace(GetExtensionClass(extensionClass, isGlobal), isGlobal);
            var source =
@$"{usings}
{extensionClassAndNamespace}
";
            return source;
        }

        private string GetUsings(string usings, bool isGlobal)
        {
            if (isGlobal && !usings.Contains(MoqProtectedGenerated.Using))
            {
                if (!usings.EndsWith(Environment.NewLine))
                {
                    usings += Environment.NewLine;
                }
                usings += MoqProtectedGenerated.Using + Environment.NewLine;
            }
            return usings;
        }

        private string GetExtensionClass(string extensionClass, bool isGlobal)
        {
            if (isGlobal)
            {
                return extensionClass;
            }

            return extensionClass.PrefixEachLine("    ");
        }

        private string WithNamespace(string extensionClass, bool isGlobal)
        {
            if (!isGlobal)
            {
                return $@"namespace {MoqProtectedGenerated.NamespaceName}
{{
{extensionClass}
}}";
            }
            else
            {
                return extensionClass;
            }
        }
    }
}
