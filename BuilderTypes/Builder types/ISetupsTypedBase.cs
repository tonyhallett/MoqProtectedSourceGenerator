using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    //applies to ISetup<TMock> and ISetup<TMock,TResult> - not async due to IThrows
    // IFluentInterface does not work https://github.com/kzu/IFluentInterface/issues/5
    public interface ISetupsTypedBase<TMock> : IThrows, IVerifies where TMock : class { }
    
}
