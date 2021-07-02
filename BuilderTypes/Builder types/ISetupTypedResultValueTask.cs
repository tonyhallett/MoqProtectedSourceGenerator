using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultValueTask<TMock,TResult, TCallbackDelegate, TReturnsDelegate> :
        ISetupTypedResultAsync<TMock, ValueTask<TResult>, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {

    }
    
}
