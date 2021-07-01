using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> : IFluentInterface
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {
        IReturnsResultTyped<TMock, TCallbackDelegate> CallBase();
        IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResult value);
        IReturnsResultTyped<TMock, TCallbackDelegate> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Func<TResult> valueFunction);
        IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResultDelegate valueFunction); 

    }
}
