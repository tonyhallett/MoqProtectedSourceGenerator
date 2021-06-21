using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface ISyntaxTreesVisitors
    {
        IEnumerable<ITreeVisitor> TreeVisitors { get; set; }
        void VisitTrees(IEnumerable<SyntaxTree> trees);
    }
}
