using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedTaskResult<TMock, TResult,TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
        IThrowsAsync<TMock, TCallbackDelegate>,
        IReturnsTypedTaskResult<TMock,TResult,TTaskResult,TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    { }

}
