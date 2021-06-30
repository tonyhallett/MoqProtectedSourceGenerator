using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IExtractionDiagnostics
    {
        Diagnostic BuildHasArguments(Location buildLocation);
        Diagnostic FluentNotCompleted(Location buildLocation);
    }
}
