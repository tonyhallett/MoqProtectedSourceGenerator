using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class ExtensionMethod
    {
        public string Name { get; set; }
        public ArgumentListSyntax Arguments { get; set; }

    }
}