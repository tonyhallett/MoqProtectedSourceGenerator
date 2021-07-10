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
        private bool successfulBuild;
        private Location buildLocation;
        private readonly IStep<MethodStepContext>[] steps;

        [ImportingConstructor]
        public MethodInvocationExtractor(IExtractionDiagnostics extractionDiagnostics)
        {
            this.extractionDiagnostics = extractionDiagnostics;

            var buildMemberAccessStep = new Step<MethodStepContext, MemberAccessExpressionSyntax>(BuildMemberAccessStep);

            var buildInvocationAccessStep = new Step<MethodStepContext, InvocationExpressionSyntax>(BuildInvocationAccessStep);

            var setupOrVerifyMemberAccessStep = new Step<MethodStepContext, MemberAccessExpressionSyntax>(SetupOrVerifyMemberAccessStep);

            var setupOrVerifyInvocationAccessStep = new Step<MethodStepContext, InvocationExpressionSyntax>((context, invocation) => { });

            steps = new IStep<MethodStepContext>[] { buildMemberAccessStep, buildInvocationAccessStep, setupOrVerifyMemberAccessStep, setupOrVerifyInvocationAccessStep };
        }
        private void Reset()
        {
            successfulBuild = false;
            buildLocation = null;
        }

        private void SetupOrVerifyMemberAccessStep(MethodStepContext context, MemberAccessExpressionSyntax memberAccess)
        {
            var invocationName = memberAccess.Name.ToFullString();
            if (!SetupOrVerifyMethodNames.Contains(invocationName))
            {
                context.State = StepContextState.Failed;
            }
        }

        private void BuildMemberAccessStep(MethodStepContext context, MemberAccessExpressionSyntax memberAccess)
        {
            if (memberAccess.Name.ToFullString() != "Build")
            {
                context.State = StepContextState.Failed;
            }
        }

        private void BuildInvocationAccessStep(MethodStepContext context, InvocationExpressionSyntax invocation)
        {
            buildLocation = invocation.GetLocation();
            var numArguments = invocation.ArgumentList.Arguments.Count;
            if (numArguments != 0)
            {
                context.Diagnostic = extractionDiagnostics.BuildHasArguments(buildLocation);
            }
            else
            {
                successfulBuild = true;
                var textSpan = invocation.ArgumentList.FullSpan;
                var fileLinePositionSpan = invocation.SyntaxTree.GetLineSpan(textSpan);
                context.FileLocation = new FileLocation
                {
                    Line = fileLinePositionSpan.StartLinePosition.Line,
                    FilePath = fileLinePositionSpan.Path
                };
            }

        }

        public MethodInvocationExtraction Extract(InvocationExpressionSyntax invocation)
        {
            Reset();

            var methodStepContext = SyntaxNodeStepAscender.Execute(invocation, new MethodStepContext(), steps);

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
