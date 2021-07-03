using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate, IReturnsThrowsTypedAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate>>,
        ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public SetupTypedResultTaskResult(ISetup<TMock, Task<TTaskResult>> actual) : base(actual) { }

        protected override IReturnsThrowsTypedAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate> ReturnsThrowsTypedFactory(IReturnsThrows<TMock, Task<TTaskResult>> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync)
        {
            return new ReturnsThrowsTypedAsync<TMock, Task<TTaskResult>, TCallbackDelegate, TReturnsDelegate>(returnsThrows, throwsAsync);
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
