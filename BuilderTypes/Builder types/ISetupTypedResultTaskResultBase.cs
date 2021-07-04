using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTaskResultBase<TMock, TResult, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
       IFluentInterface,
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
