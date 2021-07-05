using System;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
        ReturnsThrowsTypedAsync<TMock, TTask, TCallbackDelegate, TReturnsDelegate>,
        IReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        private readonly IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> returnsAsyncProvider;

        public ReturnsThrowsTypedTaskNoResult(
            IReturnsThrows<TMock, TTask> actual,
            IThrowsAsync<TMock, TCallbackDelegate> throwsAsync,
            IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> returnsAsyncProvider
        ) : base(actual, throwsAsync)
        {
            this.returnsAsyncProvider = returnsAsyncProvider;
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan delay)
        {
            return returnsAsyncProvider.ReturnsAsync(delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay)
        {
            return returnsAsyncProvider.ReturnsAsync(minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return returnsAsyncProvider.ReturnsAsync(minDelay,maxDelay, random);
        }
    }
}
