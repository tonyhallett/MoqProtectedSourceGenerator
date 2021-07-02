using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsTypedBase<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : IReturnsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        protected readonly IReturnsThrows<TMock, TResult> actual;

        public ReturnsTypedBase(IReturnsThrows<TMock, TResult> actual)
        {
            this.actual = actual;
        }
        public IReturnsResultTyped<TMock, TCallbackDelegate> CallBase()
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.CallBase());
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

        public IReturnsResultTyped<TMock, TCallbackDelegate> Returns(TReturnsDelegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.Returns(valueFunction));
        }

    }

}
