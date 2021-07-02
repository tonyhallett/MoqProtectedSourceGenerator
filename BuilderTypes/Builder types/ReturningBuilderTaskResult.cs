using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task<TResult>>>,
        IReturningBuilderTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilderTaskResult(
            Func<string, int, ISetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<Task<TResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
