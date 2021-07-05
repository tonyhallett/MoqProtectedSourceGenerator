using System;
using System.Threading.Tasks;
using Moq;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        IReturnsThrowsTypedTaskNoResult<TMock, Task, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }

    public interface IReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
       IFluentInterface,
       IThrowsAsync<TMock, TCallbackDelegate>,
       IReturnsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate>
       where TMock : class
       where TCallbackDelegate : Delegate
       where TReturnsDelegate : Delegate
    { }
}
