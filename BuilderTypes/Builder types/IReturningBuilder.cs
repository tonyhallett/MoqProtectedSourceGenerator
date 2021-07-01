using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilder<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupVerifyBuilder<ISetupTypedResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<TResult>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
