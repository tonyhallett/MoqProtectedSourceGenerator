using System;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public abstract class SetupTypedResultTaskNoResult<TMock, TTask, TCallbackDelegate, TReturnsDelegate> :
        SetupTypedResultAsync<TMock, TTask, TCallbackDelegate, TReturnsDelegate, IReturnsThrowsTypedTaskNoResult<TMock, TTask, TCallbackDelegate, TReturnsDelegate>>,
        ISetupTypedResultTaskNoReturn<TMock, TTask, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public SetupTypedResultTaskNoResult(ISetup<TMock, TTask> actual) : base(actual) { }
        
        public IReturnsResultTyped<TMock, TCallbackDelegate> ReturnsAsync(TimeSpan delay)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(ReturnsAsyncImpl(delay));
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

        protected abstract IReturnsResult<TMock> ReturnsAsyncImpl(TimeSpan delay);
    }
}
