using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilder<TMock, TResult, TCallbackDelegate, TResultDelegate> :
        ISetupVerifyBuilder<ISetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate>, ISetupSequentialResult<TResult>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    { }
}
