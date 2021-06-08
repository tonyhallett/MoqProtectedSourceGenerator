using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public enum Accessors { Get, Set, GetSet };
    public static class RoslynExtensions
    {
        private static readonly AccessorDeclarationSyntax GetterSyntax =
            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        private static readonly AccessorDeclarationSyntax SetterSyntax =
            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

        public static BasePropertyDeclarationSyntax WithAccessors(this BasePropertyDeclarationSyntax propertyDeclarationSyntax, Accessors accessors)
        {
            SyntaxList<AccessorDeclarationSyntax> accessorsList = default;
            switch (accessors)
            {
                case Accessors.GetSet:
                    accessorsList = SyntaxFactory.List(new AccessorDeclarationSyntax[] { GetterSyntax, SetterSyntax });
                    break;
                case Accessors.Get:
                    accessorsList = SyntaxFactory.List(new AccessorDeclarationSyntax[] { GetterSyntax });
                    break;
                case Accessors.Set:
                    accessorsList = SyntaxFactory.List(new AccessorDeclarationSyntax[] { SetterSyntax });
                    break;
            }
            var accessorListSyntax = SyntaxFactory.AccessorList(accessorsList);
            return propertyDeclarationSyntax.WithAccessorList(accessorListSyntax);
        }
        public static bool IsProtected(this IMethodSymbol methodSymbol)
        {
            return methodSymbol.DeclaredAccessibility == Accessibility.ProtectedOrInternal || methodSymbol.DeclaredAccessibility == Accessibility.Protected;
        }
        public static MethodDeclarationSyntax MakeExtension(this MethodDeclarationSyntax methodDeclarationSyntax, string thisType, string parameterName)
        {
            ParameterSyntax thisSyntax = SyntaxFactory.Parameter(SyntaxFactory.Identifier(parameterName)).
                WithType(SyntaxFactory.ParseTypeName(thisType)).
                WithModifiers(SyntaxTokenList.Create(SyntaxFactory.Token(SyntaxKind.ThisKeyword))).
                NormalizeWhitespace();

            return methodDeclarationSyntax.WithParameterList(
                methodDeclarationSyntax.ParameterList.WithParameters(
                    methodDeclarationSyntax.ParameterList.Parameters.Insert(0, thisSyntax)
                )
            );
        }
        public static string FullNamespace(this INamespaceSymbol namespaceSymbol)
        {
            var stringBuilder = new StringBuilder();
            var stack = new Stack<string>();
            while (!namespaceSymbol.IsGlobalNamespace)
            {
                stack.Push(namespaceSymbol.Name);
                namespaceSymbol = namespaceSymbol.ContainingNamespace;
            }
            while (stack.Count > 0)
            {
                var ns = stack.Pop();
                stringBuilder.Append(ns);
                if (stack.Count > 0)
                {
                    stringBuilder.Append(".");
                }
            }
            return stringBuilder.ToString();
        }

    }
}