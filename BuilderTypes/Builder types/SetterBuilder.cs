using Moq;
using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class SetterBuilder<T, TProperty> :
            SetupVerifyBuilder<ISetupTyped<T, Action<TProperty>>, ISetupSequentialAction>,
            ISetterBuilder<T, TProperty> where T : class
    {
        public SetterBuilder(
            Func<string, int, ISetupTyped<T, Action<TProperty>>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
