using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupVerifyBuilder<ISetupTypedResultTaskResult<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task<TResult>>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
