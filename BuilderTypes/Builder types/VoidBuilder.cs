using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class VoidBuilder<TMock, TDelegate> :
        SetupVerifyBuilder<ISetupTyped<TMock, TDelegate>, ISetupSequentialAction>,
        IVoidBuilder<TMock, TDelegate>
        where TMock : class
        where TDelegate : Delegate
    {
        public VoidBuilder(
            Func<string, int, ISetupTyped<TMock, TDelegate>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
