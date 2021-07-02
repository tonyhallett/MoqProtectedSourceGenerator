using System;
using Moq;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedCallback<TCallbackDelegate, TReturn>
        where TCallbackDelegate : Delegate
    {
        TReturn Callback(InvocationAction action);
        TReturn Callback(Delegate callback);
        TReturn Callback(Action action);

        TReturn Callback(TCallbackDelegate callback);
    }
}
