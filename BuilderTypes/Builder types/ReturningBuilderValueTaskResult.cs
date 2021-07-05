using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        SetupVerifyBuilder<ISetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>, ISetupSequentialResult<ValueTask<TValueTaskResult>>>,
        IReturningBuilderValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        public ReturningBuilderValueTaskResult(
            Func<string, int, ISetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>> setup,
            Func<string, int, ISetupSequentialResult<ValueTask<TValueTaskResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
