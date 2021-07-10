using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IPropertyInvocationExtractor))]
    public class PropertyInvocationExtractor : IPropertyInvocationExtractor
    {
        private static readonly List<string> SetupOrVerifyMethodNames = new() { "Setup", "SetupSequence", "Verify" };
        private readonly IExtractionDiagnostics extractionDiagnostics;
        private PropertyInvocationExtraction propertyInvocationExtraction;
        private SeparatedSyntaxList<ArgumentSyntax> getSetArgs = default;
        private Location buildLocation = null;

        [ImportingConstructor]
        public PropertyInvocationExtractor(IExtractionDiagnostics extractionDiagnostics)
        {
            this.extractionDiagnostics = extractionDiagnostics;
        }

        private void GetSetOrSetPropertyMemberAccess(MemberAccessExpressionSyntax memberAccess)
        {
            var name = memberAccess.Name.ToString();
            switch (name)
            {
                case "Get":
                case "Set":
                    PossibleGetSetInvocation(memberAccess.Parent);
                    break;
                case "SetProperty":
                    propertyInvocationExtraction = new PropertyInvocationExtraction { Success = true };
                    break;
                default:
                    propertyInvocationExtraction = new PropertyInvocationExtraction { Success = false };
                    break;
            }
        }
        private void PossibleGetSetOrSetPropertyMemberAccess(SyntaxNode possibleMemberAccess)
        {
            if (possibleMemberAccess is MemberAccessExpressionSyntax memberAccess)
            {
                GetSetOrSetPropertyMemberAccess(memberAccess);
            }

            propertyInvocationExtraction = new PropertyInvocationExtraction { Success = false };

        }

        private void PossibleGetSetInvocation(SyntaxNode possibleInvocation)
        {
            if (possibleInvocation is InvocationExpressionSyntax getSetInvocation)
            {
                getSetArgs = getSetInvocation.ArgumentList.Arguments;
                PossibleBuildMemberAccess(getSetInvocation.Parent);
            }
            else
            {
                propertyInvocationExtraction = new PropertyInvocationExtraction { Success = false };
            }
        }

        private void PossibleBuildMemberAccess(SyntaxNode possibleBuildMemberAccess)
        {
            bool buildEncountered = false;
            if (possibleBuildMemberAccess is MemberAccessExpressionSyntax buildMemberAccess)
            {
                var buildName = buildMemberAccess.Name.ToString();
                if (buildName == "Build")
                {
                    buildEncountered = true;
                }
            }
            if (!buildEncountered)
            {
                propertyInvocationExtraction = new PropertyInvocationExtraction { Success = false };
            }
            PossibleBuildInvocation(possibleBuildMemberAccess.Parent);
        }

        private void PossibleBuildInvocation(SyntaxNode possibleBuildInvocation)
        {
            FileLocation fileLocation = null;
            if (possibleBuildInvocation is InvocationExpressionSyntax buildInvocation)
            {
                buildLocation = buildInvocation.GetLocation();
                var numArguments = buildInvocation.ArgumentList.Arguments.Count;
                if (numArguments != 0)
                {
                    propertyInvocationExtraction = new PropertyInvocationExtraction
                    {
                        Success = false,
                        Diagnostic = extractionDiagnostics.BuildHasArguments(buildLocation)
                    };
                    return;

                }
                var textSpan = buildInvocation.ArgumentList.FullSpan;
                var fileLinePositionSpan = buildInvocation.SyntaxTree.GetLineSpan(textSpan);
                fileLocation = new FileLocation
                {
                    Line = fileLinePositionSpan.StartLinePosition.Line,
                    FilePath = fileLinePositionSpan.Path
                };
            }
            if (fileLocation == null)
            {
                propertyInvocationExtraction = new PropertyInvocationExtraction { Success = false };
            }
            else
            {
                PossibleSetupOrVerifyMemberAccess(possibleBuildInvocation.Parent, fileLocation);
            }

        }

        private void PossibleSetupOrVerifyMemberAccess(SyntaxNode possibleSetupOrVerifyMemberAccess, FileLocation fileLocation)
        {
            if (
                possibleSetupOrVerifyMemberAccess is MemberAccessExpressionSyntax setUpOrVerify &&
                SetupOrVerifyMethodNames.Contains(setUpOrVerify.Name.ToString()) &&
                setUpOrVerify.Parent is InvocationExpressionSyntax)
            {
                propertyInvocationExtraction = new PropertyInvocationExtraction
                {
                    Success = true,
                    FileLocation = fileLocation,
                    ArgumentInfoArguments = getSetArgs
                };
            }
            else
            {
                propertyInvocationExtraction = new PropertyInvocationExtraction
                {
                    Success = false,
                    Diagnostic = extractionDiagnostics.FluentNotCompleted(buildLocation)
                };
            }

        }

        public PropertyInvocationExtraction Extract(InvocationExpressionSyntax invocationExpression)
        {
            PossibleGetSetOrSetPropertyMemberAccess(invocationExpression.Parent);
            return propertyInvocationExtraction;
        }
    }
}
