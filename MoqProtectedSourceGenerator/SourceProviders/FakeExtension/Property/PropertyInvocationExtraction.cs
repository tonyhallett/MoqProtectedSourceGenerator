using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class PropertyInvocationExtraction
    {
        public FileLocation FileLocation { get; set; }

        public Diagnostic Diagnostic { get; set; }
        public bool Success { get; set; }

        public SeparatedSyntaxList<ArgumentSyntax> ArgumentInfoArguments { get; set; }
    }
}
