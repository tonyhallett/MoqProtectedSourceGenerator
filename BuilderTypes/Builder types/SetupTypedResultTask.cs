using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, Task, TCallbackDelegate, TReturnsDelegate, IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>>,
        ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {

        public SetupTypedResultTask(ISetup<TMock, Task> actual) : base(actual) { }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan delay)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(delegate
            {
                return Task.Delay(delay);
            }));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay)
        {
            TimeSpan delay = GetDelay(minDelay, maxDelay, random);
            return ReturnsAsync(delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            TimeSpan delay = GetDelay(minDelay, maxDelay, random);
            return ReturnsAsync(delay);
        }

        protected override IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, Task> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>(returnsThrows, throwsAsync, this);
        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception)
        {
            return actual.ThrowsAsync(exception);
        }

        // not present on ReturnsExtensions
        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay)
        {
            return actual.Returns(delegate
            {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                Task.Delay(delay).ContinueWith(delegate (Task task)
                {
                    tcs.SetException(exception);
                });
                return tcs.Task;
            });
        }

    }
}
