using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate> :
       ISetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TValueTaskResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<ValueTask<TValueTaskResult>>>
       where TMock : class
       where TCallbackDelegate : Delegate
       where TReturnsDelegate : Delegate
    { }
}
