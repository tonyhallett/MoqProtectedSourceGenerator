using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class AssertionHelpers
    {
        public static void NoDiagnosticErrors(ImmutableArray<Diagnostic> diagnostics)
        {
            Assert.True(diagnostics.NoErrors(), "Compilation has diagnostic errors");
        }
    }
}
