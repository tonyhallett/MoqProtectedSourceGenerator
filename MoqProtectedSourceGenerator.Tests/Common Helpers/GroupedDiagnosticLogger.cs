using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class GroupedDiagnosticLogger
    {
        public static void LogDiagnostics(string reason, ImmutableArray<Diagnostic> diagnostics)
        {
            Debug.WriteLine($"Diagnostics - {reason}");
            var diagnosticsBySeverity = diagnostics.GroupBy(d => d.Severity);
            foreach (var diagnosticBySeverity in diagnosticsBySeverity)
            {
                Debug.WriteLine(diagnosticBySeverity.Key);
                foreach (var diagnostic in diagnosticBySeverity)
                {
                    Debug.WriteLine(diagnostic.GetMessage());
                }
            }

        }
    }
}
