using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{

    [Export(typeof(IProtectedMock))]
    public class ProtectedMock : IProtectedMock
    {
        private const string ProtectedMockTypeName = "ProtectedMock";

        public string GetClosedTypeName(string mockedType)
        {
            return $"{ProtectedMockTypeName}<{mockedType}>";
        }
        private class ProtectedMockExtension : IProtectedMockExtension
        {
            public ITypeSymbol MockedType { get; set; }
            public string ExtensionName { get; set; }
        }
        public TypeSyntax GetMockedType(SyntaxNode node)
        {
            TypeSyntax mockedType = null;
            if (node is ObjectCreationExpressionSyntax objectCreationExpression)
            {
                var type = objectCreationExpression.Type;
                if (type is GenericNameSyntax genericName && genericName.Identifier.Text == ProtectedMockTypeName)
                {
                    mockedType = genericName.TypeArgumentList.Arguments[0];
                }
            }
            return mockedType;
        }

        public IProtectedMockExtension ProtectedMockExtensionInvocation(InvocationExpressionSyntax invocationExpression, SemanticModel semanticModel)
        {
            if (invocationExpression.Expression is MemberAccessExpressionSyntax extensionMemberAccess)
            {
                var mockType = semanticModel.GetTypeInfo(extensionMemberAccess.Expression).Type;
                if (mockType != null && mockType.Name == ProtectedMockTypeName)
                {
                    if (mockType is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
                    {
                        var extensionNamePossiblyWithTypes = extensionMemberAccess.Name.ToString();
                        var extensionName = extensionNamePossiblyWithTypes;
                        var leftIndex = extensionNamePossiblyWithTypes.IndexOf("<");
                        if (leftIndex != -1)
                        {
                            extensionName = extensionNamePossiblyWithTypes.Substring(0, leftIndex);
                        }
                        return new ProtectedMockExtension
                        {
                            MockedType = namedTypeSymbol.TypeArguments[0],
                            ExtensionName = extensionName
                        };

                    }
                }
            }
            return null;
        }
    }
}
