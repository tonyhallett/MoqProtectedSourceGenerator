using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate> :
       ISetupVerifyBuilder<ISetupTypedResultValueTaskResult<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsAsyncDelegate>, ISetupSequentialResult<ValueTask<TValueTaskResult>>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsAsyncDelegate: Delegate
    { }
}
