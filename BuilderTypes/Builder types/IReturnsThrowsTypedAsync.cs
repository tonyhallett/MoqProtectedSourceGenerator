using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        // removing IThrows
        IThrowsAsync<TMock, TCallbackDelegate>,
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { 
    
    }
}
