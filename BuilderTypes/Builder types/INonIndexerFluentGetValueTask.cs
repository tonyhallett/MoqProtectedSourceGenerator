using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetValueTask<TMock> where TMock : class
    {
        IReturningBuilderValueTask<TMock, Action, Func<ValueTask>> Get();
    }
    
}


