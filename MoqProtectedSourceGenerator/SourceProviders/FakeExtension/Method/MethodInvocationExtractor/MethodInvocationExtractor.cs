using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IMethodInvocationExtractor))]
    public class MethodInvocationExtractor : IMethodInvocationExtractor
    {
        public static List<string> SetupOrVerifyMethodNames = new() { "Setup", "SetupSequence", "Verify" };
        public BuildSetupOrVerify Extract(InvocationExpressionSyntax invocationExpression)
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
                    context.Diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("MoqProtectedTyped1", "Do not supply arguments to build", "Do not supply arguments to build", "MoqProtectedTyped", DiagnosticSeverity.Error, true, "Do not supply arguments to build"), buildLocation
                    );
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
                methodStepContext.Diagnostic = Diagnostic.Create(
                    new DiagnosticDescriptor("MoqProtectedTyped2", "Build should be followed by Setup, SetupSequence or Verify", "Build should be followed by Setup or Verify", "MoqProtectedTyped", DiagnosticSeverity.Error, true, "Build should be followed by Setup or Verify"), buildLocation
                );
            }
            return new BuildSetupOrVerify
            {
                Success = successfulBuild,
                FileLocation = methodStepContext.FileLocation,
                Diagnostic = methodStepContext.Diagnostic
            };
        }
    }
}
