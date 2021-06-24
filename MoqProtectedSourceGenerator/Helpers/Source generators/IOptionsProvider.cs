using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public interface IOptionsProvider
    {
        bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider);
    }
}
