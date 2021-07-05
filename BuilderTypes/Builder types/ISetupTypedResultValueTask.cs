using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultValueTask<TMock, TCallbackDelegate, TReturnsDelegate> :
         ISetupTypedResultTaskNoReturn<TMock, ValueTask, TCallbackDelegate, TReturnsDelegate>

            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    { }

}
