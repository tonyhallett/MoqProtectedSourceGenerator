using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public static class ClassToInterface
    {
        private static readonly SymbolDisplayFormat methodSymbolDisplayFormat;

        private static readonly SymbolDisplayFormat propertySymbolDisplayFormat;

        static ClassToInterface()
        {
            methodSymbolDisplayFormat = SetupDisplayFormat(SymbolDisplayFormat.FullyQualifiedFormat);

            //have to use the ctor for property style - missing With
            var fullyQualifiedDisplayFormatWithPropertyAccessors = new SymbolDisplayFormat(SymbolDisplayGlobalNamespaceStyle.Included, SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces, SymbolDisplayGenericsOptions.IncludeTypeParameters, SymbolDisplayMemberOptions.None, SymbolDisplayDelegateStyle.NameOnly, SymbolDisplayExtensionMethodStyle.Default, SymbolDisplayParameterOptions.None, SymbolDisplayPropertyStyle.ShowReadWriteDescriptor, SymbolDisplayLocalOptions.None, SymbolDisplayKindOptions.None, SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers | SymbolDisplayMiscellaneousOptions.UseSpecialTypes);
            propertySymbolDisplayFormat = SetupDisplayFormat(fullyQualifiedDisplayFormatWithPropertyAccessors);
        }
        private static SymbolDisplayFormat SetupDisplayFormat(SymbolDisplayFormat baseFormat)
        {
            return baseFormat.WithMemberOptions(SymbolDisplayMemberOptions.IncludeParameters | SymbolDisplayMemberOptions.IncludeType | SymbolDisplayMemberOptions.IncludeRef).
                WithParameterOptions(SymbolDisplayParameterOptions.IncludeType | SymbolDisplayParameterOptions.IncludeName | SymbolDisplayParameterOptions.IncludeDefaultValue | SymbolDisplayParameterOptions.IncludeParamsRefOut).
                WithGenericsOptions(SymbolDisplayGenericsOptions.IncludeTypeConstraints | SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeVariance).
                WithKindOptions(SymbolDisplayKindOptions.None);
        }

        public static MethodDeclarationSyntax TransformMethod(IMethodSymbol methodSymbol)
        {
            MethodDeclarationSyntax methodDeclaration;
            var declaringSyntaxReferences = methodSymbol.DeclaringSyntaxReferences;
            if (declaringSyntaxReferences.Length > 0)
            {
                methodDeclaration = declaringSyntaxReferences[0].GetSyntax() as MethodDeclarationSyntax;
            }
            else
            {
                var methodDisplayString = methodSymbol.ToDisplayString(methodSymbolDisplayFormat);
                methodDeclaration = SyntaxFactory.ParseMemberDeclaration(methodDisplayString) as MethodDeclarationSyntax;
            }
            return methodDeclaration.WithModifiers(new SyntaxTokenList()).WithBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        public static BasePropertyDeclarationSyntax TransformProperty(IPropertySymbol propertySymbol)
        {
            BasePropertyDeclarationSyntax propertyDeclaration;
            var declaringSyntaxReferences = propertySymbol.DeclaringSyntaxReferences;
            if (declaringSyntaxReferences.Length > 0)
            {
                propertyDeclaration = declaringSyntaxReferences[0].GetSyntax() as BasePropertyDeclarationSyntax;

            }
            else
            {
                propertyDeclaration = SyntaxFactory.ParseMemberDeclaration(propertySymbol.ToDisplayString(propertySymbolDisplayFormat)) as BasePropertyDeclarationSyntax;
            }
            return propertyDeclaration.WithModifiers(new SyntaxTokenList());
        }

    }

}