using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> : 
        IFluentInterface,
        IThrowsAsync<TMock, TCallbackDelegate>,
        IReturnsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
