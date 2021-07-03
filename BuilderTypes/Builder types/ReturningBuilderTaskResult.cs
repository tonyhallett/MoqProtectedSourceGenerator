using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task<TTaskResult>>>,
        IReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilderTaskResult(
            Func<string, int, ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<Task<TTaskResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
