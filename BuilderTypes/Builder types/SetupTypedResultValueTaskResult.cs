using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> : 
        SetupTypedResultAsyncResult<TMock, ValueTask<TValueTaskResult>, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>,
        ISetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
            where TReturnsAsyncDelegate : Delegate
    {
        public SetupTypedResultValueTaskResult(ISetup<TMock, ValueTask<TValueTaskResult>> actual) : base(actual) { }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception)
        {
            return actual.ThrowsAsync(exception);
        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay)
        {
            return actual.ThrowsAsync(exception, delay);
        }

        protected override IReturnsResult<TMock> ResultImpl(Func<TValueTaskResult> valueFunction)
        {
            return actual.ReturnsAsync(valueFunction);
        }

        protected override IReturnsResult<TMock> ResultImpl(TReturnsAsyncDelegate valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TValueTaskResult)))
            {
                return ResultImpl(() => default);
            }
            return actual.Returns((IInvocation invocation) =>
            {
                return new ValueTask<TValueTaskResult>(InvokeFromInvocation(invocation, valueFunction));
            });
        }

        protected override IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, Func<TValueTaskResult> valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TValueTaskResult)))
            {
                return DelayedResultImpl(delay,() => default);
            }

            return actual.Returns(() => new ValueTask<TValueTaskResult>(Task.Delay(delay).ContinueWith( t => valueFunction())));
        }

        protected override IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, TReturnsAsyncDelegate valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TValueTaskResult)))
            {
                return DelayedResultImpl(delay, () => default);
            }
            return actual.Returns((IInvocation invocation) =>
            {
                return new ValueTask<TValueTaskResult>(Task.Delay(delay).ContinueWith(t => InvokeFromInvocation(invocation, valueFunction)));
            });
        }

        protected override IReturnsThrowsTypedTaskResult<TMock, ValueTask<TValueTaskResult>, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, ValueTask<TValueTaskResult>> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedTaskResult<TMock, ValueTask<TValueTaskResult>, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>(returnsThrows, throwsAsync, this);
        }
    }
    
}
