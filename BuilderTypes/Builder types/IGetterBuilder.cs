using Moq.Language.Flow;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IGetterBuilder<TMock, TProperty> :
            ISetupVerifyBuilder<ISetupGetter<TMock, TProperty>, ISetupSequentialResult<TProperty>> where TMock : class
    { }
}
