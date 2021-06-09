using System;
using Moq;
using Moq.Language.Flow;


namespace MoqProtectedGenerated
{
    public class VoidMethodBuilder<T> : SetupVerifyBuilder<ISetup<T>>, IVoidMethodBuilder<T> where T : class
    {
        public VoidMethodBuilder(Func<string, int, ISetup<T>> setup, Action<string, int, Times?, string> verify) : base(setup, verify) { }
    }
}
