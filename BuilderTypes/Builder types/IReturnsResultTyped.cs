using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface IReturnsResultTyped<TMock, TCallbackDelegate> :
        ICallbackDelegate<TCallbackDelegate>, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies 
        where TMock : class
        where TCallbackDelegate : Delegate
    { }
}
