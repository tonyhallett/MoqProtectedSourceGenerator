using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        IReturnsThrowsTypedTaskNoResult<TMock, Task, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
