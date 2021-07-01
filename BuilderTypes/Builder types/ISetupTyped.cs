using System;
using Moq.Language;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public interface ISetupTyped<TMock, TDelegate> :
        ISetupsTypedBase<TMock>,
        ICallbackDelegate<TDelegate>,
        ICallBase,
        ICallBaseResult,
        ICallbackResult,
        IRaise<TMock>
            where TMock : class
            where TDelegate : Delegate
    { }
}
