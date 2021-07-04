using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate,TReturnsAsyncDelegate> :
        SetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>, ISetupSequentialResult<Task<TTaskResult>>>,
        IReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    {
        public ReturningBuilderTaskResult(
            Func<string, int, ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>> setup,
            Func<string, int, ISetupSequentialResult<Task<TTaskResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
