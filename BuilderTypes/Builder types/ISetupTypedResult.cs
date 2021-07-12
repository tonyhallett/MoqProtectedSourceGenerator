using System;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<TCallbackDelegate, IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>>
        where TMock: class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
