using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay, Random random);
    }
}
