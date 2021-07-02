using System;

namespace MoqProtectedGenerated
{
    public interface IThrowsAsync<TMock,TCallbackDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
    {
        IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception);
        // not present on ReturnsExtensions
        IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync<TException>() where TException : Exception, new();
        IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan delay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay);
        IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay, Random random);
    }
    
}
