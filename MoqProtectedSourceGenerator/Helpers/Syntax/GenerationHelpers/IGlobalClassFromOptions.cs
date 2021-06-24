using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public interface IGlobalClassFromOptions
    {
        string Get(string usings, string extensionClass, AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider);
    }
}
