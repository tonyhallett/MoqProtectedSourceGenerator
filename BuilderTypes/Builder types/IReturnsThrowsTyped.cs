using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        IThrows, 
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
