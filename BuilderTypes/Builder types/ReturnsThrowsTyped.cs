using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> :
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TResultDelegate> 
        where TMock : class
        where TCallbackDelegate : Delegate
        where TResultDelegate : Delegate
    {
        private readonly IReturnsThrows<TMock, TResult> actual;

        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual)
        {
            this.actual = actual;
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> CallBase()
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.CallBase());
        }

        public IThrowsResult Throws(Exception exception)
        {
            return actual.Throws(exception);
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            return actual.Throws<TException>();
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(Func<TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TResultDelegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(valueFunction));
        }

    }
}
