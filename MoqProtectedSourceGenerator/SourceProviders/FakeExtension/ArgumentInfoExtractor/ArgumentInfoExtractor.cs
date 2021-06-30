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

               if (argument.RefKindKeyword.IsKind(SyntaxKind.RefKeyword))
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
               else if (argument.Expression is InvocationExpressionSyntax invocation)
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

               return argumentInfo;
           }).ToList();
            return new ArgumentInfoExtraction { ArgumentInfos = argumentInfos, Diagnostics = diagnostics };
        }
        private bool IsWrappedCustomMatcher(InvocationExpressionSyntax invocation)
        {
            return invocation.ToFullString().StartsWith("CustomMatcher.Wrap");
        }
        private bool IsItArgument(InvocationExpressionSyntax invocation)
        {
            var isIt = false;
            if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                isIt = memberAccess.Expression.ToFullString() == "It";
            }
            return isIt;
        }

    }
}
