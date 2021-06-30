using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class ArgumentInfoExtraction
    {
        public List<ArgumentInfo> ArgumentInfos { get; set; }
        public List<Diagnostic> Diagnostics { get; set; }
    }

    public interface IArgumentInfoExtractor
    {
        ArgumentInfoExtraction Extract(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel);
    }
}
