using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(MoqBlocker))]
    public class MoqBlocker : IVisitBlocker
    {
        private bool allow;
        public bool Allow(SyntaxNode node)
        {
            if (node is CompilationUnitSyntax compilationUnit)
            {
                allow = compilationUnit.Usings.Any(u => u.Name.ToFullString() == "Moq");
            }
            return allow;
        }
    }
}
