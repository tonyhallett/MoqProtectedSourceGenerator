using System;
using System.Threading.Tasks;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
        IFluentInterface,
        IReturnsTyped<TMock, TTask, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    { }
}
