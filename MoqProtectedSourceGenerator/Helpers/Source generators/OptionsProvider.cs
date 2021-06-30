using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IOptionsProvider))]
    public class OptionsProvider : IOptionsProvider
    {
        public bool IndexerExtensionNameFromIndexerNameAttribute(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            return GetGlobalOption(configOptionProvider, "IndexerExtensionNameFromIndexerNameAttribute", true);
        }

        public bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            return GetGlobalOption(configOptionProvider, "_GlobalExtensions", true);
        }

        private T GetGlobalOption<T>(AnalyzerConfigOptionsProvider optionsProvider, string optionName, T defaultValue)
        {
            return GetOption<T>(optionsProvider.GlobalOptions, optionName, defaultValue);
        }

        private T GetOption<T>(AnalyzerConfigOptions options,string optionName, T defaultValue)
        {
            var option= new Option<T> { Key = $"{nameof(MoqProtectedSourceGenerator)}_{optionName}", Value = defaultValue };
            options.GetOption(option);
            return option.Value;
        }
        
    }
}
