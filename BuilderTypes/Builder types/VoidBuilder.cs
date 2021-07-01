using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class VoidBuilder<TMock, TCallbackDelegate> :
        SetupVerifyBuilder<ISetupTyped<TMock, TCallbackDelegate>, ISetupSequentialAction>,
        IVoidBuilder<TMock, TCallbackDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
    {
        public VoidBuilder(
            Func<string, int, ISetupTyped<TMock, TCallbackDelegate>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
