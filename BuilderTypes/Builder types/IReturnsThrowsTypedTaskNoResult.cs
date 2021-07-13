using System;

namespace MoqProtectedGenerated
{
    public interface IReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
       IThrowsAsync<TMock, TCallbackDelegate>,
       IReturnsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate>
       where TMock : class
       where TCallbackDelegate : Delegate
       where TReturnsDelegate : Delegate
    { }
}
