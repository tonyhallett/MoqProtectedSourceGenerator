using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public interface ICallbackDelegate<TCallbackDelegate> : IFluentInterface where TCallbackDelegate : Delegate
    {
        ICallbackResult Callback(TCallbackDelegate del);
        ICallbackResult Callback(Action action);
        ICallbackResult Callback(InvocationAction action);
        ICallbackResult Callback(Delegate callback);
    }
}
