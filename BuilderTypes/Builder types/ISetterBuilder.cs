using MoqProtectedGenerated;
using Moq.Language;
using System;

public interface ISetterBuilder<T, TProperty> :
        ISetupVerifyBuilder<ISetupTyped<T, Action<TProperty>>, ISetupSequentialAction> where T : class
{ }
