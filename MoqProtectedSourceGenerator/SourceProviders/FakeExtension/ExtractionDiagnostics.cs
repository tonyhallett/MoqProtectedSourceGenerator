using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IExtractionDiagnostics))]
    public class ExtractionDiagnostics : IExtractionDiagnostics
    {
        private const string BuildHasArgsMessage = "Do not supply arguments to build";
        private const string FluentNotCompletedMessage = "Build should be followed by Setup, SetupSequence or Verify";
        // todo this is not working - asked in roslyn github if there is well known categories list 
        private const string Category = "MoqProtectedTyped";
        //todo - there is a third diagnostic...
        private const string IdPrefix = "MoqProtectedTyped";

        public Diagnostic BuildHasArguments(Location buildLocation)
        {
            return Diagnostic.Create(
             new DiagnosticDescriptor(
                 $"{IdPrefix}1", 
                 BuildHasArgsMessage, 
                 BuildHasArgsMessage, 
                 Category, 
                 DiagnosticSeverity.Error, 
                 true, 
                 BuildHasArgsMessage), 
             buildLocation
            );
        }

        public Diagnostic FluentNotCompleted(Location buildLocation)
        {
            return Diagnostic.Create(
                new DiagnosticDescriptor(
                    $"{IdPrefix}2", 
                    FluentNotCompletedMessage,
                    FluentNotCompletedMessage, 
                    Category, 
                    DiagnosticSeverity.Error, 
                    true,
                    FluentNotCompletedMessage), 
                buildLocation
            );
        }
    }
}
