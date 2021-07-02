using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultValueTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, ValueTask<TResult>, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedResultAsync<TMock, ValueTask<TResult>, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {
        public SetupTypedResultValueTaskResult(ISetup<TMock, ValueTask<TResult>> actual) : base(actual) { }

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
