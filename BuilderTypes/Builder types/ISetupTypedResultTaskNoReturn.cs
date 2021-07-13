using System;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTaskNoReturn<TMock,TTask, TCallbackDelegate, TReturnsDelegate> :
        IVerifies,
        IReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<
            TCallbackDelegate,
            IReturnsThrowsTypedTaskNoResult<TMock,TTask, TCallbackDelegate, TReturnsDelegate>
        >
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    { }

}
