using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetValueTaskResult<TMock, TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock, TValueTaskResult, Action, Func<ValueTask<TValueTaskResult>>, Func<TValueTaskResult>> Get();
    }
    
}


