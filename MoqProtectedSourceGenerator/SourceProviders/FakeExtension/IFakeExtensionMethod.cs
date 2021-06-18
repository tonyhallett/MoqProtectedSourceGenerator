using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IFakeExtensionMethod
    {
        void AddSource(GeneratorExecutionContext context);

        bool ExtensionInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel);
    }
}
