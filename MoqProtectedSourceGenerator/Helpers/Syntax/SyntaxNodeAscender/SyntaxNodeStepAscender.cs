using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public static class SyntaxNodeStepAscender
    {
        private static bool ExecuteStep<TContext>(IStep<TContext> step, TContext context, SyntaxNode node) where TContext : IStepContext
        {
            var shouldExit = false;
            if (step.ExpectedNodeType.IsAssignableFrom(node.GetType()))
            {
                step.Execute(context, node);
                if (context.State == StepContextState.Complete)
                {
                    shouldExit = true;
                }
            }
            else
            {
                context.State = StepContextState.Failed;
                shouldExit = true;
            }
            return shouldExit;
        }

        public static TContext Execute<TContext>(SyntaxNode node, TContext context, params IStep<TContext>[] steps) where TContext : IStepContext
        {
            var count = 0;
            var numSteps = steps.Length;
            var parent = node.Parent;
            while (parent != null)
            {
                var step = steps[count];
                var shouldExit = ExecuteStep(step, context, parent);
                count++;
                if (shouldExit || count == numSteps)
                {
                    break;
                }
                parent = parent.Parent;
            }
            return context;
        }
    }
}
