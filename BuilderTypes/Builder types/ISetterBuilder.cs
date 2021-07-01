using MoqProtectedGenerated;
using Moq.Language;

public interface ISetterBuilder<T, TProperty> :
        ISetupVerifyBuilder<ISetupTyped<T, TProperty>, ISetupSequentialAction> where T : class
{ }
