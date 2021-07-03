using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TTaskResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task<TTaskResult>>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
