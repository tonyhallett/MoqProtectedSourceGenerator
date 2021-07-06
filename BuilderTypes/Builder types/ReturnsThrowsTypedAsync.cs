using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public abstract class ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ReturnsTypedBase<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IFluentInterface,
        IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        private readonly IThrowsAsync<TMock, TCallbackDelegate> throwsAsync;
        public ReturnsThrowsTypedAsync(
            IReturnsThrows<TMock, TResult> actual,
            IThrowsAsync<TMock, TCallbackDelegate> throwsAsync
        ) : base(actual)
        {
            this.throwsAsync = throwsAsync;
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception)
        {
            return throwsAsync.ThrowsAsync(exception);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync<TException>() where TException : Exception, new()
        {
            return ThrowsAsync<TException>();
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan delay)
        {
            return ThrowsAsync(exception, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return ThrowsAsync(exception, minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return ThrowsAsync(exception, minDelay, maxDelay, random);
        }


    }
}
