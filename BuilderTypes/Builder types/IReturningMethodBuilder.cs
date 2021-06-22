using Moq.Language;
using Moq.Language.Flow;


namespace MoqProtectedGenerated
{
    public interface IReturningMethodBuilder<T,TResult> : 
        ISetupVerifyBuilder<ISetup<T,TResult>, 
        ISetupSequentialResult<TResult>> where T : class
    { }
}
