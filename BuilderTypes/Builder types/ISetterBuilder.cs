using Moq.Language;
using System;

namespace MoqProtectedGenerated
{
    public interface ISetterBuilder<T, TProperty> :
            ISetupVerifyBuilder<ISetupTyped<T, Action<TProperty>>, ISetupSequentialAction> where T : class
    { }
}
