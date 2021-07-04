using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultValueTask<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
    ISetupTypedResultTaskResultBase<TMock, ValueTask<TTaskResult>, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate : Delegate
    { }

}
