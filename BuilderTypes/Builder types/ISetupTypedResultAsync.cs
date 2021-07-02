using System;
using Moq;
using Moq.Language;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        IThrowsAsync<TMock,TCallbackDelegate>, // instead of IThrows from ISetupsTypedBase
        IFluentInterface,// ISetupsTypedBase
        IVerifies, // ISetupsTypedBase
        ISetupTypedCallback<TCallbackDelegate, IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>>
        where TMock:class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    { }
}
