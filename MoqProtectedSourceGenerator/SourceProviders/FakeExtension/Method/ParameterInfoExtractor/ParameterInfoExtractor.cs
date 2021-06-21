using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IParameterInfoExtractor))]
    public class ParameterInfoExtractor : IParameterInfoExtractor
    {
        public ParameterInfoExtraction Extract(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            List<Diagnostic> diagnostics = new();
            var parameterInfos = arguments.Select(argument =>
           {
               var parameterInfo = new ParameterInfo
               {
                   Type = ParameterType.UseValue
               };

               if (argument.RefKindKeyword.IsKind(SyntaxKind.RefKeyword))
               {
                   var potentialItRef = argument.NormalizeWhitespace().ToString();
                   if (potentialItRef.StartsWith("ref It.Ref<"))
                   {
                       parameterInfo.Type = ParameterType.RefAny;
                       parameterInfo.RefAny = potentialItRef.Substring(4);
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
                       parameterInfo.Type = ParameterType.Match;
                   }
                   else if (IsWrappedCustomMatcher(invocation))
                   {
                       parameterInfo.Type = ParameterType.Match;
                   }
                   else if (OutType.IsOutArgument(invocation))
                   {
                       parameterInfo.Type = ParameterType.Out;
                   }
                   // later provide means of searching syntax for custom matcher
               }

               return parameterInfo;
           }).ToList();
            return new ParameterInfoExtraction { ParameterInfos = parameterInfos, Diagnostics = diagnostics };
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
