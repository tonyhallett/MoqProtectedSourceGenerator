using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<Task>>,
        IReturningBuilderTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilderTask(
            Func<string, int, ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<Task>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
