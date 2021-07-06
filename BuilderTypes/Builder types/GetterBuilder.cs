using Moq;
using System;
using Moq.Language.Flow;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public class GetterBuilder<TMock, TProperty> :
            SetupVerifyBuilder<ISetupGetter<TMock, TProperty>, ISetupSequentialResult<TProperty>>,
            IGetterBuilder<TMock, TProperty> where TMock : class
    {
        public GetterBuilder(
            Func<string, int, ISetupGetter<TMock, TProperty>> setup,
            Func<string, int, ISetupSequentialResult<TProperty>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
