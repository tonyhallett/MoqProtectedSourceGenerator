using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        SetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>, ISetupSequentialResult<ValueTask<TValueTaskResult>>>,
        IReturningBuilderValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        public ReturningBuilderValueTask(
            Func<string, int, ISetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>> setup,
            Func<string, int, ISetupSequentialResult<ValueTask<TValueTaskResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
