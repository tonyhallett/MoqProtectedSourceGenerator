using MoqProtectedGenerated;
using Moq.Language.Flow;
using Moq.Language;

public interface ISetterBuilder<T, TProperty> :
        ISetupVerifyBuilder<ISetupSetter<T, TProperty>, ISetupSequentialAction> where T : class
{ }
