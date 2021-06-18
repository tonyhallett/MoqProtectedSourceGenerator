using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IMoqBlocker
    {
        bool Allow(SyntaxNode node);
    }

    [Export(typeof(IMoqBlocker))]
    public class MoqBlocker : IMoqBlocker
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
