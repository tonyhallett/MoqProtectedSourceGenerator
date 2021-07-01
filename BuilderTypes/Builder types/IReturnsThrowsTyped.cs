using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> : 
        IFluentInterface, 
        IThrows, 
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {

    }
}
