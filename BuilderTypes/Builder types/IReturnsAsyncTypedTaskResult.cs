using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsAsyncTypedTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random);

        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random);

        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random);
    }

}
