using Moq;
using MoqProtectedGenerated;
using System;
using Moq.Language.Flow;
using Moq.Language;

public class GetterBuilder<T, TProperty> :
        SetupVerifyBuilder<ISetupGetter<T, TProperty>, ISetupSequentialResult<TProperty>>,
        IGetterBuilder<T, TProperty> where T : class
{
    public GetterBuilder(
        Func<string, int, ISetupGetter<T, TProperty>> setup,
        Func<string, int, ISetupSequentialResult<TProperty>> setupSequence,
        Action<string, int, Times?, string> verify
    ) : base(setup, setupSequence, verify) { }
}
