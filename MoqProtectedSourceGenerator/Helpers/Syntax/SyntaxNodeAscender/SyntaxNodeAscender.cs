using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public static class SyntaxNodeAscender
    {
        public static TContext Execute<TContext>(SyntaxNode node, TContext context, params IStep<TContext>[] steps) where TContext : IStepContext
        {
            var count = 0;
            var numSteps = steps.Length;
            var parent = node.Parent;
            while (parent != null)
            {
                var step = steps[count];

                if (step.ExpectedNodeType.IsAssignableFrom(parent.GetType()))
                {
                    step.Execute(context, parent);
                    if (context.State == StepContextState.Complete)
                    {
                        break;
                    }
                }
                else
                {
                    context.State = StepContextState.Failed;
                    break;
                }

                count++;
                if (count == numSteps)
                {
                    break;
                }
                parent = parent.Parent;
            }
            return context;
        }
    }
}
