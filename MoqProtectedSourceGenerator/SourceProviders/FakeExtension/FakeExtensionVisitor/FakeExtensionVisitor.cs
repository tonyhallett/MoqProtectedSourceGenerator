using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class FakeExtensionVisitor
    {
        private readonly FakeExtensionSetupOrVerify result = new();
        private SemanticModel semanticModel;
        private bool valid;

        public FakeExtensionSetupOrVerify Visit(InvocationExpressionSyntax invocationExpressionSyntax, SemanticModel semanticModel)
        {
            valid = false;
            this.semanticModel = semanticModel;
            PossibleSetupOrVerifyInvocation(invocationExpressionSyntax);

            if (valid)
            {
                return result;
            }
            return null;

        }

        private void PossibleSetupOrVerifyInvocation(InvocationExpressionSyntax invocation)
        {
            if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                var invocationName = memberAccess.Name.ToFullString();
                var isSetup = invocationName == "Setup";
                if (isSetup || invocationName == "Verify")
                {
                    result.IsSetup = isSetup;
                    if (memberAccess.Expression is InvocationExpressionSyntax possibleBuildInvocation)
                    {
                        PossibleBuildInvocation(possibleBuildInvocation);
                    }
                }
            }
        }

        private void PossibleBuildInvocation(InvocationExpressionSyntax invocation)
        {
            if (invocation.Expression is MemberAccessExpressionSyntax memberAccessExpression)
            {
                var invocationName = memberAccessExpression.Name.ToString();
                if (invocationName == "Build")
                {
                    if (memberAccessExpression.Expression is InvocationExpressionSyntax possibleExtensionInvocation)
                    {

                        var textSpan = invocation.ArgumentList.FullSpan;
                        var fileLinePositionSpan = invocation.SyntaxTree.GetLineSpan(textSpan);
                        result.FileLocation = new FileLocation
                        {
                            Line = fileLinePositionSpan.StartLinePosition.Line,
                            FilePath = fileLinePositionSpan.Path
                        };

                        PossibleExtensionInvocation(possibleExtensionInvocation);
                    }
                }
            }
        }

        private void PossibleExtensionInvocation(InvocationExpressionSyntax invocation)
        {
            if (invocation.Expression is MemberAccessExpressionSyntax extensionMemberAccess)
            {
                var mockType = semanticModel.GetTypeInfo(extensionMemberAccess.Expression).Type;
                if (mockType != null && mockType.Name == "Mock")
                {
                    if (mockType is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.IsGenericType)
                    {
                        valid = true;
                        result.MockedType = namedTypeSymbol.TypeArguments[0];

                        result.ExtensionMethod = new ExtensionMethod
                        {
                            Arguments = invocation.ArgumentList,
                            Name = extensionMemberAccess.Name.ToString()
                        };
                    }
                }
            }
        }
    }
}