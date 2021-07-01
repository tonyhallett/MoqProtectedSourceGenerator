using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IVoidBuilder<TMock, TCallbackDelegate> :
            ISetupVerifyBuilder<ISetupTyped<TMock, TCallbackDelegate>, ISetupSequentialAction>
            where TMock : class
            where TCallbackDelegate : Delegate
    { }
}
