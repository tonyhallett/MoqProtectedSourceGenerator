using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace EndToEndTests
{
    public static class GroupedDiagnosticLogger
    {
        public static void LogDiagnostics(string reason, ImmutableArray<Diagnostic> diagnostics,Action<string> log = null)
        {
            if(log == null)
            {
                log = (msg) => Debug.WriteLine(msg);
            }
            log($"Diagnostics - {reason}");
            var diagnosticsBySeverity = diagnostics.GroupBy(d => d.Severity);
            foreach (var diagnosticBySeverity in diagnosticsBySeverity)
            {
                log(diagnosticBySeverity.Key.ToString());
                foreach (var diagnostic in diagnosticBySeverity)
                {
                    log(diagnostic.GetMessage());
                }
            }

        }
    }
}
