using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetTask<TMock> where TMock : class
    {
        IReturningBuilderTask<TMock,Action, Func<Task>> Get();
    }
    
}


