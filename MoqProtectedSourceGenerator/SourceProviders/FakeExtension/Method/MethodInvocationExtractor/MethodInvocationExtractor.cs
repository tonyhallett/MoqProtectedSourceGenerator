using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{

    [Export(typeof(IMethodInvocationExtractor))]
    public class MethodInvocationExtractor : IMethodInvocationExtractor
    {
        private readonly IExtractionDiagnostics extractionDiagnostics;
        //todo - common code
        private static readonly List<string> SetupOrVerifyMethodNames = new() { "Setup", "SetupSequence", "Verify" };

        [ImportingConstructor]
        public MethodInvocationExtractor(IExtractionDiagnostics extractionDiagnostics)
        {
            this.extractionDiagnostics = extractionDiagnostics;
        }

        public MethodInvocationExtraction Extract(InvocationExpressionSyntax invocationExpression)
        {
            var buildMemberAccessStep = new Step<MethodStepContext, MemberAccessExpressionSyntax>((context, memberAccess) =>
            {
                if (memberAccess.Name.ToFullString() != "Build")
                {
                    context.State = StepContextState.Failed;
                }
            });
            var successfulBuild = false;
            Location buildLocation = null;
            var buildInvocationAccessStep = new Step<MethodStepContext, InvocationExpressionSyntax>((context, invocation) =>
            {
                buildLocation = invocation.GetLocation();
                var numArguments = invocation.ArgumentList.Arguments.Count;
                if (numArguments != 0)
                {
                    context.Diagnostic = extractionDiagnostics.BuildHasArguments(buildLocation);
                    return;
                }
                successfulBuild = true;
                var textSpan = invocation.ArgumentList.FullSpan;
                var fileLinePositionSpan = invocation.SyntaxTree.GetLineSpan(textSpan);
                context.FileLocation = new FileLocation
                {
                    Line = fileLinePositionSpan.StartLinePosition.Line,
                    FilePath = fileLinePositionSpan.Path
                };
            });

            var setUpOrVerifyMemberAccessStep = new Step<MethodStepContext, MemberAccessExpressionSyntax>((context, memberAccess) =>
            {
                var invocationName = memberAccess.Name.ToFullString();
                if (!SetupOrVerifyMethodNames.Contains(invocationName))
                {
                    context.State = StepContextState.Failed;
                }
            });

            var setUpOrVerifyInvocationAccessStep = new Step<MethodStepContext, InvocationExpressionSyntax>((context, invocation) =>
            {

            });

            var methodStepContext = SyntaxNodeAscender.Execute(invocationExpression, new MethodStepContext(), buildMemberAccessStep, buildInvocationAccessStep, setUpOrVerifyMemberAccessStep, setUpOrVerifyInvocationAccessStep);
            if (successfulBuild && methodStepContext.State == StepContextState.Failed)
            {
                methodStepContext.Diagnostic = extractionDiagnostics.FluentNotCompleted(buildLocation);
            }

            return new MethodInvocationExtraction
            {
                Success = successfulBuild,
                FileLocation = methodStepContext.FileLocation,
                Diagnostic = methodStepContext.Diagnostic
            };
        }
    }
}
