using System;
using System.Threading.Tasks;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        ReturnsThrowsTypedAsync<TMock, Task, TCallbackDelegate, TReturnsDelegate>,
        IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        private readonly IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> returnsAsyncProvider;

        public ReturnsThrowsTypedTask(
            IReturnsThrows<TMock, Task> actual,
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
