using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
    ISetupTypedResultTaskResultBase<TMock, ValueTask<TValueTaskResult>, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    { }

}
