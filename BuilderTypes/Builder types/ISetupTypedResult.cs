using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock: class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(Action action);

        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(TCallbackDelegate callback);
    }
}
