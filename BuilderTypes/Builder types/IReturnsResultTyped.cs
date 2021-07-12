using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturnsResultTyped<TMock, TCallbackDelegate> :
        ICallbackDelegate<TCallbackDelegate>, IOccurrence, IRaise<TMock>, IVerifies 
        where TMock : class
        where TCallbackDelegate : Delegate
    { }
}
