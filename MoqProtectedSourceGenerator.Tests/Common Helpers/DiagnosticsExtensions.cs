using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class DiagnosticsExtensions
    {
        public static bool NoErrors(this ImmutableArray<Diagnostic> diagnostics)
        {
            return diagnostics.Count(d => d.Severity == DiagnosticSeverity.Error) == 0;
        }
    }
}
