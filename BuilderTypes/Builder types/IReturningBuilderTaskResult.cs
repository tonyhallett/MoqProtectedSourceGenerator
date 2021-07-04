using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate,TReturnsDelegateAsync> :
        ISetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate, TReturnsDelegateAsync>, ISetupSequentialResult<Task<TTaskResult>>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
        where TReturnsDelegateAsync : Delegate
    { }
}
