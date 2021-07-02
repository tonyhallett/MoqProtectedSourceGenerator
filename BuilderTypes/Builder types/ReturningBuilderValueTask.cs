using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<ValueTask<TResult>>>,
        IReturningBuilderValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilderValueTask(
            Func<string, int, ISetupTypedResultValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<ValueTask<TResult>>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
