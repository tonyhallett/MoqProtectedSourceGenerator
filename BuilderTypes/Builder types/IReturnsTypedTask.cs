using System;
using System.Threading.Tasks;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> : 
        IFluentInterface, 
        IReturnsTyped<TMock, Task, TCallbackDelegate, TReturnsDelegate>,
        IReturnsAsyncTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {}

}
