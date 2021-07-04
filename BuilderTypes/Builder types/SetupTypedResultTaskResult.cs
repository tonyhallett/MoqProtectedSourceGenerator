using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        SetupTypedResultAsyncResult<TMock, Task<TTaskResult>,TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>,
        ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        public SetupTypedResultTaskResult(ISetup<TMock, Task<TTaskResult>> actual) : base(actual) { }

        protected override IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, Func<TTaskResult> valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TTaskResult)))
            {
                return DelayedResultImpl(delay,() => default);
            }

            return actual.Returns(() =>
            {
                return Task.Delay(delay).ContinueWith(t => valueFunction());
            });
        }

        protected override IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, TReturnsAsyncDelegate valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TTaskResult)))
            {
                return DelayedResultImpl(delay, () => default);
            }
            return actual.Returns((IInvocation invocation) =>
            {
                return Task.Delay(delay).ContinueWith(t => InvokeFromInvocation(invocation, valueFunction));
            });
        }

        protected override IReturnsResult<TMock> ResultImpl(Func<TTaskResult> valueFunction)
        {
            return actual.ReturnsAsync(valueFunction);
        }

        protected override IReturnsResult<TMock> ResultImpl(TReturnsAsyncDelegate valueFunction)
        {
            if (IsNullResult(valueFunction, typeof(TTaskResult)))
            {
                return ResultImpl(() => default);
            }

            return actual.Returns((IInvocation invocation) =>
            {
                return Task.FromResult(InvokeFromInvocation(invocation, valueFunction));
            });
        }

        protected override IReturnsThrowsTypedTaskResult<TMock, Task<TTaskResult>, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, Task<TTaskResult>> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedTaskResult<TMock, Task<TTaskResult>, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>(returnsThrows, throwsAsync, this);
        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception)
        {
            return actual.ThrowsAsync(exception);
        }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay)
        {
            return actual.ThrowsAsync(exception, delay);
        }
        
    }
}
