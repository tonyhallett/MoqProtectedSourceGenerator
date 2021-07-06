using Moq.Language;
using System;

namespace MoqProtectedGenerated
{
    public interface ISetterBuilder<TMock, TProperty> :
            ISetupVerifyBuilder<ISetupTyped<TMock, Action<TProperty>>, ISetupSequentialAction> where TMock : class
    { }
}
