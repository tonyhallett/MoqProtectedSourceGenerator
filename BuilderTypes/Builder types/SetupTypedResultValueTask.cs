using System;
using System.Threading.Tasks;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        SetupTypedResultTaskNoResult<TMock, ValueTask, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public SetupTypedResultValueTask(ISetup<TMock, ValueTask> actual) : base(actual) { }

        protected override IReturnsResult<TMock> ReturnsAsyncImpl(TimeSpan delay)
        {
            return actual.Returns(new ValueTask(Task.Delay(delay)));
        }

        protected override IReturnsThrowsTypedTaskNoResult<TMock, ValueTask, TCallbackDelegate, TReturnsDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, ValueTask> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedTaskNoResult<TMock, ValueTask, TCallbackDelegate, TReturnsDelegate>(returnsThrows, throwsAsync, this);
        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception)
        {
            return actual.Returns(delegate {
                TaskCompletionSource<object> source = new TaskCompletionSource<object>();
                source.SetException(exception);
                return new ValueTask(source.Task);
            });

        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay)
        {
            return actual.Returns(delegate {
                TaskCompletionSource<object> source = new TaskCompletionSource<object>();
                Task.Delay(delay).ContinueWith(delegate (Task task)
                {
                    source.SetException(exception);
                });
                return new ValueTask(source.Task);
            });
        }
    }
}
