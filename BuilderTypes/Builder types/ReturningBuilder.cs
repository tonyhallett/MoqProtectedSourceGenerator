using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilder<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<TResult>>,
        IReturningBuilder<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilder(
            Func<string, int, ISetupTypedResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<TResult>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
