using System;
using Moq;
using Moq.Language;
using Moq.Language.Flow;


namespace MoqProtectedGenerated
{
    public class ReturningMethodBuilder<T,TResult> : 
        SetupVerifyBuilder<ISetup<T,TResult>, ISetupSequentialResult<TResult>>,
        IReturningMethodBuilder<T,TResult> 
        where T : class
    {
        public ReturningMethodBuilder(
            Func<string, int, ISetup<T,TResult>> setup, 
            Func<string, int, ISetupSequentialResult<TResult>> setupSequence, 
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence,verify) { }
    }
}
