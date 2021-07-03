using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate> :
        IFluentInterface,
        IVerifies,
        IReturnsThrowsTypedAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<
            TCallbackDelegate, 
            IReturnsThrowsTypedAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate>
        >
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {

    }
}
