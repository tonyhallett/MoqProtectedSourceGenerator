using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate> :
        IFluentInterface,
        IVerifies,
        IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<
            TCallbackDelegate, 
            IReturnsThrowsTypedTask<TMock, TCallbackDelegate, TReturnsDelegate>
        >
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {}
    
}
