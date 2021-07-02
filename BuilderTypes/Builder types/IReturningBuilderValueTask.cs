using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
       ISetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TResult, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<ValueTask<TResult>>>
       where TMock : class
       where TCallbackDelegate : Delegate
       where TReturnsDelegate : Delegate
    { }
}
