using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetTaskResult<TMock,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock, TTaskResult, Action, Func<Task<TTaskResult>>,Func<TTaskResult>> Get();
    }
    
}


