using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MoqProtectedSourceGenerator.Helpers.GenerationHelpers
{
    public static class CSharpSyntaxFactory
    {
        private static readonly SyntaxToken OpenBrace = Token(SyntaxKind.OpenBraceToken);
        private static readonly SyntaxToken CloseBrace = Token(SyntaxKind.CloseBraceToken);
        public static InitializerExpressionSyntax ComplexInitializer(params ExpressionSyntax[] elementExpressions)
        {
            var elementExpressionsList = SeparatedList(elementExpressions);
            return InitializerExpression(SyntaxKind.ComplexElementInitializerExpression, OpenBrace, elementExpressionsList, CloseBrace);
        }

        public static InitializerExpressionSyntax ComplexInitializer(params string[] elementExpressionsToParse)
        {
            return ComplexInitializer(elementExpressionsToParse.Select(e => ParseExpression(e)).ToArray());
        }

        public static TSyntax WithLeadingNewline<TSyntax>(this TSyntax node) where TSyntax : SyntaxNode
        {
            var newlineTrivia = ParseLeadingTrivia(Environment.NewLine);
            return node.WithLeadingTrivia(newlineTrivia);
        }

        public static TSyntax WithTrailingNewline<TSyntax>(this TSyntax node) where TSyntax : SyntaxNode
        {
            var newlineTrivia = ParseTrailingTrivia(Environment.NewLine);
            return node.WithTrailingTrivia(newlineTrivia);
        }
    }

}
