using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        ISetupTypedResultAsync<TMock, Task<TResult>, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
    
}
