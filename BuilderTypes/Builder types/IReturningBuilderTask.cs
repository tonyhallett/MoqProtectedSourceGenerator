using System;
using System.Threading.Tasks;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturningBuilderTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        ISetupVerifyBuilder<ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task>>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
