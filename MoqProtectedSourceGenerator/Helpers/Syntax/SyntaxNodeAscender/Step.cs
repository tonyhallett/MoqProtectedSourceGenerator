using System;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class Step<TContext, TNode> : IStep<TContext> where TNode : SyntaxNode
    {
        private readonly Action<TContext, TNode> action;
        public Type ExpectedNodeType { get; set; } = typeof(TNode);

        public void Execute(TContext context, SyntaxNode node)
        {
            action(context, node as TNode);
        }

        public Step(Action<TContext, TNode> action)
        {
            this.action = action;
        }
    }
}
