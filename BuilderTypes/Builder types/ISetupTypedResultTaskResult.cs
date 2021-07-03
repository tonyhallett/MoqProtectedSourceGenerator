using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate> : 
        IFluentInterface,
        IVerifies,
        IReturnsThrowsTypedAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<
            TCallbackDelegate, 
            IReturnsThrowsTypedAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate>
        >
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
    
    
}
