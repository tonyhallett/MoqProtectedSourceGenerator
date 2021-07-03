using System;
using System.Threading.Tasks;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> : 
        IFluentInterface, 
        IReturnsTyped<TMock, Task, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {}

    public interface IReturnsAsyncTypedTaskResult<TMock, TTaskType, TResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
         where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TResult value, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TResult value, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random);

        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TResult> valueFunction, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random);

        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random);
    }
    
    public interface IReturnsTypedTaskResult<TMock, TTaskType,TResult,TCallbackDelegate, TReturnsDelegate,TReturnsAsyncDelegate> :
        IFluentInterface,
        IReturnsTyped<TMock, TTaskType, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTaskResult<TMock, TTaskType, TResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
            where TReturnsAsyncDelegate : Delegate
    { }

    public interface IReturnsThrowsTypedTaskResult<TMock,TTaskType, TResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        IFluentInterface,
        IThrowsAsync<TMock, TCallbackDelegate>,
        IReturnsTypedTaskResult<TMock,TTaskType,TResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    { }
}
