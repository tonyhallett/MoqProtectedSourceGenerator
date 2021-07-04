using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public abstract class SetupTypedResultAsyncResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        SetupTypedResultAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate, IReturnsThrowsTypedTaskResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>>,
        ISetupTypedResultTaskResultBase<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        public SetupTypedResultAsyncResult(
            ISetup<TMock, TResult> actual
        ) : base(actual) { }

        private IReturnsResultTyped<TMock, TCallbackDelegate> Wrap(IReturnsResult<TMock> returnsResult)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(returnsResult);
        }

        protected TTaskResult InvokeFromInvocation(IInvocation invocation, TReturnsAsyncDelegate valueFunction)
        {
            var args = invocation.Arguments;
            return (TTaskResult)valueFunction.DynamicInvoke((args as object[]) ?? args?.ToArray());
        }

        protected bool IsNullResult(Delegate valueFunction, Type resultType)
        {
            if (valueFunction != null)
            {
                return false;
            }
            if (resultType.IsValueType)
            {
                return (Nullable.GetUnderlyingType(resultType) != null);
            }
            return true;
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value)
        {
            return ReturnsAsync(() => value);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan delay)
        {
            return ReturnsAsync(() => value, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return ReturnsAsync(() => value, minDelay, maxDelay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TTaskResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            return ReturnsAsync(() => value, minDelay, maxDelay, random);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction)
        {
            return Wrap(ResultImpl(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan delay)
        {
            Guard.Positive(delay);

            return Wrap(DelayedResultImpl(delay, valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return ReturnsAsync(valueFunction, minDelay, maxDelay, random);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(Func<TTaskResult> valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            var delay = GetDelay(minDelay, maxDelay, random);
            return ReturnsAsync(valueFunction, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction)
        {
            return Wrap(ResultImpl(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan delay)
        {
            Guard.Positive(delay);

            return Wrap(DelayedResultImpl(delay, valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay)
        {
            return ReturnsAsync(valueFunction, minDelay, maxDelay, random);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TReturnsAsyncDelegate valueFunction, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            var delay = GetDelay(minDelay, maxDelay, random);
            return ReturnsAsync(valueFunction, delay);
        }

        protected abstract IReturnsResult<TMock> ResultImpl(Func<TTaskResult> valueFunction);
        protected abstract IReturnsResult<TMock> ResultImpl(TReturnsAsyncDelegate valueFunction);
        protected abstract IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, Func<TTaskResult> valueFunction);
        protected abstract IReturnsResult<TMock> DelayedResultImpl(TimeSpan delay, TReturnsAsyncDelegate valueFunction);
    }
}
