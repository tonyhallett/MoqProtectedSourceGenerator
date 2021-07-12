using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsTypedTaskResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsAsyncDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
            where TReturnsAsyncDelegate : Delegate
    { }

}
