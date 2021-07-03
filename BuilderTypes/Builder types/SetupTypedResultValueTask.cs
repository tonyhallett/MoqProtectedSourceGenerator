using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate, IReturnsThrowsTypedAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate>>,
        ISetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {
        public SetupTypedResultValueTask(ISetup<TMock, ValueTask<TValueTaskResult>> actual) : base(actual) { }

        protected override IReturnsThrowsTypedAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, ValueTask<TValueTaskResult>> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedAsync<TMock, ValueTask<TValueTaskResult>, TCallbackDelegate, TReturnsDelegate>(returnsThrows, throwsAsync);
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
