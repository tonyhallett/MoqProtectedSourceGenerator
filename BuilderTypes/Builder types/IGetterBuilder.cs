using MoqProtectedGenerated;
using Moq.Language.Flow;
using Moq.Language;

public interface IGetterBuilder<T, TProperty> :
        ISetupVerifyBuilder<ISetupGetter<T,TProperty>, ISetupSequentialResult<TProperty>> where T : class
{ }
