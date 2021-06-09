using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public static class MethodDeclarationSyntaxExtensions
    {
        public static bool ReturnTypeIsVoid(this MethodDeclarationSyntax methodDeclaration)
        {
            return methodDeclaration.ReturnType is PredefinedTypeSyntax predefinedTypeSyntax && predefinedTypeSyntax.Keyword.IsKind(SyntaxKind.VoidKeyword);
        }
    }
}
