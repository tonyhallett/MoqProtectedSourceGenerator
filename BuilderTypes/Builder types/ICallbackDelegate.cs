using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public interface ICallbackDelegate<TDelegate> : IFluentInterface where TDelegate : Delegate
    {
        ICallbackResult Callback(TDelegate del);
        ICallbackResult Callback(Action action);
        ICallbackResult Callback(InvocationAction action);
        ICallbackResult Callback(Delegate callback);
    }
}
