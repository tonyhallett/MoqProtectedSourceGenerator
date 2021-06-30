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

        [ImportingConstructor]
        public PropertyInvocationExtractor(IExtractionDiagnostics extractionDiagnostics)
        {
            this.extractionDiagnostics = extractionDiagnostics;
        }
        public PropertyInvocationExtraction Extract(InvocationExpressionSyntax invocationExpression)
        {
            FileLocation fileLocation = null;
            var parent = invocationExpression.Parent;
            bool getOrSetMemberEncountered = false;
            bool getOrSetInvocationEncountered = false;
            SeparatedSyntaxList<ArgumentSyntax> getSetArgs = default;
            if(parent is MemberAccessExpressionSyntax memberAccess)
            {
                var name = memberAccess.Name.ToString();
                switch (name)
                {
                    case "Get":
                    case "Set":
                        getOrSetMemberEncountered = true;
                        break;
                    case "SetProperty":
                        return new PropertyInvocationExtraction { Success = true };
                    default:
                        return new PropertyInvocationExtraction { Success = false };
                }
            }
            if(!getOrSetMemberEncountered)
            {
                return new PropertyInvocationExtraction { Success = false };
            }
            parent = parent.Parent;
            if(parent is InvocationExpressionSyntax getSetInvocation)
            {
                getOrSetInvocationEncountered = true;
                getSetArgs = getSetInvocation.ArgumentList.Arguments;
            }
            if (!getOrSetInvocationEncountered)
            {
                return new PropertyInvocationExtraction { Success = false };
            }
            parent = parent.Parent;
            bool buildEncountered = false;
            if(parent is MemberAccessExpressionSyntax buildMemberAccess)
            {
                var buildName = buildMemberAccess.Name.ToString();
                if(buildName == "Build")
                {
                    buildEncountered = true;
                }
            }
            if (!buildEncountered)
            {
                return new PropertyInvocationExtraction { Success = false };
            }
            parent = parent.Parent;
            Location buildLocation = null;
            if(parent is InvocationExpressionSyntax buildInvocation)
            {
                buildLocation = buildInvocation.GetLocation();
                var numArguments = buildInvocation.ArgumentList.Arguments.Count;
                if (numArguments != 0)
                {
                    return new PropertyInvocationExtraction { 
                        Success = false,
                        Diagnostic = extractionDiagnostics.BuildHasArguments(buildLocation)
                    };

                }
                var textSpan = buildInvocation.ArgumentList.FullSpan;
                var fileLinePositionSpan = buildInvocation.SyntaxTree.GetLineSpan(textSpan);
                fileLocation = new FileLocation
                {
                    Line = fileLinePositionSpan.StartLinePosition.Line,
                    FilePath = fileLinePositionSpan.Path
                };
            }
            if(fileLocation == null)
            {
                return new PropertyInvocationExtraction { Success = false };
            }
            parent = parent.Parent;
            if(parent is MemberAccessExpressionSyntax setUpOrVerify && SetupOrVerifyMethodNames.Contains(setUpOrVerify.Name.ToString()) && setUpOrVerify.Parent is InvocationExpressionSyntax)
            {
                return new PropertyInvocationExtraction
                {
                    Success = true,
                    FileLocation = fileLocation,
                    ArgumentInfoArguments = getSetArgs
                };
            }
            return new PropertyInvocationExtraction
            {
                Success = false,
                Diagnostic = extractionDiagnostics.FluentNotCompleted(buildLocation)
            };
        }
    }
}
