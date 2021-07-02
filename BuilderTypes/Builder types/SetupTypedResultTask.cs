using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate> : 
        SetupTypedResultAsync<TMock, Task, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        
        public SetupTypedResultTask(ISetup<TMock, Task> actual) : base(actual) { }

        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception)
        {
            return actual.ThrowsAsync(exception);
        }

        // not present on ReturnsExtensions
        protected override IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay)
        {
            return actual.Returns(delegate
            {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                Task.Delay(delay).ContinueWith(delegate (Task task)
                {
                    tcs.SetException(exception);
                });
                return tcs.Task;
            });
        }

    }
    
}
