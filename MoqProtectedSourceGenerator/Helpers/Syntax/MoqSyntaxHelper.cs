using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class MoqSyntaxHelper
    {
        public TypeSyntax GetMockedType(SyntaxNode node)
        {
            TypeSyntax mockedType = null;
            if (node is ObjectCreationExpressionSyntax objectCreationExpression)
            {
                var type = objectCreationExpression.Type;
                if (type is GenericNameSyntax genericName && genericName.Identifier.Text == "Mock")
                {
                    mockedType = genericName.TypeArgumentList.Arguments[0];
                }
            }
            return mockedType;
        }
    }
}