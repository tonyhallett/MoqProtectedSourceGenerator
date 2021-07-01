using System;
using Moq.Language;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public interface ISetupTyped<TMock, TCallbackDelegate> :
        ISetupsTypedBase<TMock>,
        ICallbackDelegate<TCallbackDelegate>,
        ICallBase,
        ICallBaseResult,
        ICallbackResult,
        IRaise<TMock>
            where TMock : class
            where TCallbackDelegate : Delegate
    { }
}
