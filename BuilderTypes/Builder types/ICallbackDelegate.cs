using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public interface ICallbackDelegate<TCallbackDelegate> : 
        ISetupTypedCallback<TCallbackDelegate, ICallbackResult>, 
        IFluentInterface 
        where TCallbackDelegate : Delegate
    { }
}
