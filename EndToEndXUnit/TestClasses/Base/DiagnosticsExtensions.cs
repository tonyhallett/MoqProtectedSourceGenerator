using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace EndToEndTests
{
    public static class DiagnosticsExtensions
    {
        public static bool NoErrors(this ImmutableArray<Diagnostic> diagnostics)
        {
            return diagnostics.All(d => d.Severity != DiagnosticSeverity.Error);
        }
    }
}
