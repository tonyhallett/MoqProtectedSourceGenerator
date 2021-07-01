using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IDelegateProvider
    {
        string GetDelegates(MethodDeclarationSyntax methodDeclaration);
    }
}
