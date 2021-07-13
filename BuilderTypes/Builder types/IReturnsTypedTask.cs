using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
        IReturnsTyped<TMock, TTask, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    { }
}
