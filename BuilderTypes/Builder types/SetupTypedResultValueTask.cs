using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, ValueTask<TResult>, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedResultValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {
        public SetupTypedResultValueTask(ISetup<TMock, ValueTask<TResult>> actual) : base(actual) { }

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
