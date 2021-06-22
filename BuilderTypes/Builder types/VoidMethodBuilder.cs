using System;
using Moq;
using Moq.Language;
using Moq.Language.Flow;


namespace MoqProtectedGenerated
{
    public class VoidMethodBuilder<T> : 
        SetupVerifyBuilder<ISetup<T>, ISetupSequentialAction>, 
        IVoidMethodBuilder<T> 
        where T : class
    {
        public VoidMethodBuilder(
            Func<string, int, ISetup<T>> setup, 
            Func<string, int, ISetupSequentialAction> setupSequence, 
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }
}
