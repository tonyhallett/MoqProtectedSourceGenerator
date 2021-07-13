using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTaskResultBase<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
       IVerifies,
       IReturnsThrowsTypedTaskResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>,
       ISetupTypedCallback<
           TCallbackDelegate,
           IReturnsThrowsTypedTaskResult<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
       >
       where TMock : class
       where TCallbackDelegate : Delegate
       where TReturnsDelegate : Delegate
       where TReturnsAsyncDelegate : Delegate
    { }

}
