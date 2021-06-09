using System;
using Moq;
using Moq.Language.Flow;


namespace MoqProtectedGenerated
{
    public class ReturningMethodBuilder<T,TResult> : SetupVerifyBuilder<ISetup<T,TResult>>, IReturningMethodBuilder<T,TResult> where T : class
    {
        public ReturningMethodBuilder(Func<string, int, ISetup<T,TResult>> setup, Action<string, int, Times?, string> verify) : base(setup, verify) { }
    }
}
