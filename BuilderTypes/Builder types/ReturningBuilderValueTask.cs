using System;
using System.Threading.Tasks;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class ReturningBuilderValueTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        SetupVerifyBuilder<ISetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate>, ISetupSequentialResult<ValueTask>>,
        IReturningBuilderValueTask<TMock, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturningBuilderValueTask(
            Func<string, int, ISetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate>> setup,
            Func<string, int, ISetupSequentialResult<ValueTask>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
