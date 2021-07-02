using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, Task<TResult>, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public SetupTypedResultTaskResult(ISetup<TMock, Task<TResult>> actual) : base(actual) { }

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
