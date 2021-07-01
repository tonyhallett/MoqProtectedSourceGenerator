using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate> :
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate>,
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate>
        where TMock: class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(Action action);

        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(TCallbackDelegate callback);
    }
}
