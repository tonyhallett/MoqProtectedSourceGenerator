using System;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public abstract class SetupTypedResultAsync<
        TMock, 
        TResult, 
        TCallbackDelegate, 
        TReturnsDelegate,
        TReturnsThrowsTyped
    > : IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        ISetupTypedCallback<
            TCallbackDelegate,
            TReturnsThrowsTyped
        >,
        IVerifies
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {
        protected readonly Random random = new Random();
        protected readonly ISetup<TMock, TResult> actual;

        protected SetupTypedResultAsync(
            ISetup<TMock, TResult> actual 
        )
        {
            this.actual = actual;
        }

        protected abstract TReturnsThrowsTyped ReturnsThrowsTypedFactory(IReturnsThrows<TMock, TResult> returnsThrows, IThrowsAsync<TMock, TCallbackDelegate> throwsAsync);

        protected TimeSpan GetDelay(TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            if (minDelay >= maxDelay)
            {
                throw new ArgumentException("Min delay must be less than max delay");
            }
            int ticks = (int)minDelay.Ticks;
            int maxValue = (int)maxDelay.Ticks;
            return new TimeSpan((long)random.Next(ticks, maxValue));
        }

        #region Throws
        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync<TException>() where TException : Exception, new()
        {
            return ThrowsAsync(new TException());
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception)
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(ThrowsAsyncImpl(exception));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan delay)
        {
            Guard.Positive(delay);
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(ThrowsAsyncImpl(exception, delay));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay)
        {
            TimeSpan delay = GetDelay(minDelay, maxDelay, random);
            return ThrowsAsync(exception, delay);
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync(Exception exception, TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException("random");
            }
            TimeSpan delay = GetDelay(minDelay, maxDelay, random);
            return ThrowsAsync(exception, delay);
        }
        
        protected abstract IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception);

        protected abstract IReturnsResult<TMock> ThrowsAsyncImpl(Exception exception, TimeSpan delay);
        #endregion
        
        #region Returns
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

        #endregion
        
        #region Verifiable
        public void Verifiable()
        {
            actual.Verifiable();
        }

        public void Verifiable(string failMessage)
        {
            actual.Verifiable(failMessage);
        }
        #endregion
        
        public override string ToString()
        {
            return actual.ToString();
        }


        #region Callback
        public TReturnsThrowsTyped Callback(InvocationAction action)
        {
            return ReturnsThrowsTypedFactory(actual.Callback(action), this);
        }

        public TReturnsThrowsTyped Callback(Delegate callback)
        {
            return ReturnsThrowsTypedFactory(actual.Callback(callback), this);
        }

        public TReturnsThrowsTyped Callback(Action action)
        {
            return ReturnsThrowsTypedFactory(actual.Callback(action), this);
        }

        public TReturnsThrowsTyped Callback(TCallbackDelegate callback)
        {
            return ReturnsThrowsTypedFactory(actual.Callback(callback), this);
        }
        #endregion

    }
    
}
