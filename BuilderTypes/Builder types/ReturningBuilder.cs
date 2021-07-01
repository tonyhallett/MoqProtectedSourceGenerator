using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilder<TMock, TResult, TCallbackDelegate, TResultDelegate> :
        SetupVerifyBuilder<ISetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate>, ISetupSequentialResult<TResult>>,
        IReturningBuilder<TMock, TResult, TCallbackDelegate, TResultDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {
        public ReturningBuilder(
            Func<string, int, ISetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate>> setup,
            Func<string, int, ISetupSequentialResult<TResult>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
