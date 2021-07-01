using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class SetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate> : ISetupTypedResult<TMock, TResult, TCallbackDelegate, TResultDelegate> 
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {
        private readonly ISetup<TMock, TResult> actual;
        public SetupTypedResult(ISetup<TMock, TResult> actual)
        {
            this.actual = actual;
        }

        public IThrowsResult Throws(Exception exception)
        {
            return actual.Throws(exception);
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            return actual.Throws<TException>();
        }

        public void Verifiable()
        {
            actual.Verifiable();
        }

        public void Verifiable(string failMessage)
        {
            actual.Verifiable(failMessage);
        }

        public override string ToString()
        {
            return actual.ToString();
        }
       

        #region Callback
        public IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(InvocationAction action)
        {
            return new ReturnsThrowsTyped<TMock, TResult,TCallbackDelegate, TResultDelegate>(actual.Callback(action));
        }

        public IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(Delegate callback)
        {
            return new ReturnsThrowsTyped<TMock, TResult,TCallbackDelegate, TResultDelegate>(actual.Callback(callback));
        }

        public IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(Action action)
        {
            return new ReturnsThrowsTyped<TMock, TResult,TCallbackDelegate, TResultDelegate>(actual.Callback(action));
        }

        public IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> Callback(TCallbackDelegate callback)
        {
            return new ReturnsThrowsTyped<TMock, TResult,TCallbackDelegate, TResultDelegate>(actual.Callback(callback));
        }
        #endregion

        public IReturnsResultTyped<TMock, TCallbackDelegate> CallBase()
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Func<TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResultDelegate valueFunction)
        {
            return new ReturnsResultTyped<TMock,TCallbackDelegate>(actual.Returns(valueFunction));
        }

    }
}
