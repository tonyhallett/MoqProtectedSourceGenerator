using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MoqProtectedSourceGenerator
{

    public class BlockingSyntaxTreesVisitors : CSharpSyntaxWalker, IBlockingSyntaxTreesVisitors
    {
        private class DoNotBlock : IVisitBlocker
        {
            public bool Allow(SyntaxNode node)
            {
                return true;
            }
        }

        private bool visitedTree;
        private SyntaxTree currentTree;
        public IEnumerable<ITreeVisitor> TreeVisitors { get; set; }
        public IVisitBlocker VisitBlocker { get; set; } = new DoNotBlock();

        public void VisitTrees(IEnumerable<SyntaxTree> trees)
        {
            foreach (var tree in trees)
            {
                visitedTree = false;
                currentTree = tree;

                var root = tree.GetRoot();
                this.Visit(root);

            }

        }

        public override void DefaultVisit(SyntaxNode node)
        {
            var allow = VisitBlocker.Allow(node);
            if (allow)
            {
                foreach (var sourceProvider in TreeVisitors)
                {
                    if (!visitedTree)
                    {
                        sourceProvider.OnVisitTree(currentTree);
                    }
                    sourceProvider.OnVisitSyntaxNode(node);
                }
                visitedTree = true;
                base.DefaultVisit(node);
            }

        }
    }
}
