using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{

    [Export(typeof(IProtectedMock))]
    [Export(typeof(IProtectedLikeCreationDependent))]
    public class ProtectedMock : IProtectedMock, IProtectedLikeCreationDependent
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

        private string GetExtensionName(MemberAccessExpressionSyntax extensionMemberAccess)
        {
            var extensionNamePossiblyWithTypes = extensionMemberAccess.Name.ToString();
            var extensionName = extensionNamePossiblyWithTypes;
            var leftIndex = extensionNamePossiblyWithTypes.IndexOf("<");
            if (leftIndex != -1)
            {
                extensionName = extensionNamePossiblyWithTypes.Substring(0, leftIndex);
            }
            return extensionName;
        }

        private bool IsProtectedMock(ITypeSymbol possibleProtectedMock)
        {
            return possibleProtectedMock != null && possibleProtectedMock.Name == ProtectedMockTypeName;
        }

        private ITypeSymbol GetMockedType(MemberAccessExpressionSyntax extensionMemberAccess, SemanticModel semanticModel)
        {
            ITypeSymbol mockedType = null;
            var mockType = semanticModel.GetTypeInfo(extensionMemberAccess.Expression).Type;
            if (IsProtectedMock(mockType) && mockType is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
            {
                mockedType = namedTypeSymbol.TypeArguments[0];
            }
            return mockedType;
        }

        private IProtectedMockExtension FromExtensionMemberAccess(MemberAccessExpressionSyntax extensionMemberAccess, SemanticModel semanticModel)
        {
            var mockedType = GetMockedType(extensionMemberAccess, semanticModel);
            if (mockedType != null)
            {
                return new ProtectedMockExtension
                {
                    MockedType = mockedType,
                    ExtensionName = GetExtensionName(extensionMemberAccess)
                };
            }

            return null;
        }
        public IProtectedMockExtension ProtectedMockExtensionInvocation(InvocationExpressionSyntax invocationExpression, SemanticModel semanticModel)
        {
            if (invocationExpression.Expression is MemberAccessExpressionSyntax extensionMemberAccess)
            {
                return FromExtensionMemberAccess(extensionMemberAccess, semanticModel);
            }
            return null;
        }
    }
}
