using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IVoidBuilder<TMock, TDelegate> :
            ISetupVerifyBuilder<ISetupTyped<TMock, TDelegate>, ISetupSequentialAction>
            where TMock : class
            where TDelegate : Delegate
    { }
}
