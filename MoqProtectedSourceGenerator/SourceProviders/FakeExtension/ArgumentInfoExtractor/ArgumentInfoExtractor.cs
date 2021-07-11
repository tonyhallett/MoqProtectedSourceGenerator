using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IArgumentInfoExtractor))]
    public class ArgumentInfoExtractor : IArgumentInfoExtractor
    {
        public ArgumentInfoExtraction Extract(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            List<Diagnostic> diagnostics = new();
            var argumentInfos = arguments.Select(argument =>
            {
                var argumentInfo = new ArgumentInfo
                {
                    Type = ArgumentType.UseValue
                };

                if (!ItRef(argument, argumentInfo, diagnostics))
                {
                    ConsiderInvocation(argument, argumentInfo);
                }
                return argumentInfo;
            }).ToList();
            return new ArgumentInfoExtraction { ArgumentInfos = argumentInfos, Diagnostics = diagnostics };
        }

        private bool ItRef(ArgumentSyntax argument, ArgumentInfo argumentInfo, List<Diagnostic> diagnostics)
        {
            var isItRef = argument.RefKindKeyword.IsKind(SyntaxKind.RefKeyword);
            if (isItRef)
            {
                var potentialItRef = argument.NormalizeWhitespace().ToString();
                if (potentialItRef.StartsWith("ref It.Ref<"))
                {
                    argumentInfo.Type = ArgumentType.RefAny;
                    argumentInfo.RefAny = potentialItRef.Substring(4);
                }
                else
                {
                    diagnostics.Add(Diagnostic.Create(
                        new DiagnosticDescriptor("MoqProtectedTyped3", "Only supported ref is It.Ref", "Only supported ref is It.Ref", "MoqProtectedTyped", DiagnosticSeverity.Error, true, "Only supported ref is It.Ref"), argument.GetLocation()
                    ));
                }
            }
            return isItRef;
        }

        private void SetArgumentTypeFromInvocation(ArgumentInfo argumentInfo, InvocationExpressionSyntax invocation)
        {
            if (IsItArgument(invocation))
            {
                argumentInfo.Type = ArgumentType.Match;
            }
            else if (IsWrappedCustomMatcher(invocation))
            {
                argumentInfo.Type = ArgumentType.Match;
            }
            else if (OutType.IsOutArgument(invocation))
            {
                argumentInfo.Type = ArgumentType.Out;
            }
            // later provide means of searching syntax for custom matcher
        }
        private void ConsiderInvocation(ArgumentSyntax argument, ArgumentInfo argumentInfo)
        {
            if (argument.Expression is InvocationExpressionSyntax invocation)
            {
                SetArgumentTypeFromInvocation(argumentInfo, invocation);
            }
        }

        private bool IsWrappedCustomMatcher(InvocationExpressionSyntax invocation)
        {
            return invocation.ToString().StartsWith("CustomMatcher.Wrap");
        }

        private bool IsItArgument(InvocationExpressionSyntax invocation)
        {
            var isIt = false;
            if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                isIt = memberAccess.Expression.ToString() == "It";
            }
            return isIt;
        }

    }
}
