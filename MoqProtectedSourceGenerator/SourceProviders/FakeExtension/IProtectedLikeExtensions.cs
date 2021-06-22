using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikeExtensions
    {
        void AddSource(GeneratorExecutionContext context);
        void ExtensionInvocation(Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, GeneratorExecutionContext context);
    }
}
