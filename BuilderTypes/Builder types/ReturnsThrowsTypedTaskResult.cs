using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ReturnsTypedBase<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IFluentInterface,
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IThrowsAsync<TMock,TCallbackDelegate>
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
    public class ReturnsThrowsTypedTaskResult<TMock, TResult, TTaskResult,TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IReturnsThrowsTypedTaskResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        private readonly IReturnsAsyncTypedTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsAsyncDelegate> provider;
        public ReturnsThrowsTypedTaskResult(
            IReturnsThrows<TMock, TResult> actual, 
            IThrowsAsync<TMock,TCallbackDelegate> throwsAsync,
            IReturnsAsyncTypedTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsAsyncDelegate> provider
        ) : base(actual,throwsAsync)
        {
            this.provider = provider;
        }

        #region ReturnsAsync
        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value)
        {
            return provider.ReturnsAsync(value);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan delay)
        {
            return provider.ReturnsAsync(value, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return provider.ReturnsAsync(value, minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return provider.ReturnsAsync(value, minDelay, maxDelay, random);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction)
        {
            return provider.ReturnsAsync(valueFunction);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan delay)
        {
            return provider.ReturnsAsync(valueFunction, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return provider.ReturnsAsync(valueFunction, minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return provider.ReturnsAsync(valueFunction, minDelay, maxDelay, random);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction)
        {
            return provider.ReturnsAsync(valueFunction);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan delay)
        {
            return provider.ReturnsAsync(valueFunction, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return provider.ReturnsAsync(valueFunction, minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return provider.ReturnsAsync(valueFunction, minDelay, maxDelay, random);
        }

        #endregion
        
    }
}
