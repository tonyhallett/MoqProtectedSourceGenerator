using Moq;
using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class SetterBuilder<TMock, TProperty> :
            SetupVerifyBuilder<ISetupTyped<TMock, Action<TProperty>>, ISetupSequentialAction>,
            ISetterBuilder<TMock, TProperty> where TMock : class
    {
        public SetterBuilder(
            Func<string, int, ISetupTyped<TMock, Action<TProperty>>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
