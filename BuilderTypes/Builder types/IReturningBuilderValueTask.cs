using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderValueTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        ISetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<ValueTask>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
