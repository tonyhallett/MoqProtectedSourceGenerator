using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class ParameterInfoExtraction
    {
        public List<ParameterInfo> ParameterInfos { get; set; }
        public List<Diagnostic> Diagnostics { get; set; }
    }

    public interface IParameterInfoExtractor
    {
        ParameterInfoExtraction Extract(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel);
    }
}
