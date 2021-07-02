using System;
using Moq;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public abstract class SetupTypedResultAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> : 
        ISetupTypedResultAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    {
        private static readonly Random random = new Random();
        protected readonly ISetup<TMock, TResult> actual;
        public SetupTypedResultAsync(ISetup<TMock, TResult> actual)
        {
            this.actual = actual;
        }

        private TimeSpan GetDelay(TimeSpan minDelay, TimeSpan maxDelay, Random random)
        {
            if (minDelay >= maxDelay)
            {
                throw new ArgumentException("Min delay must be less than max delay");
            }
            int ticks = (int)minDelay.Ticks;
            int maxValue = (int)maxDelay.Ticks;
            return new TimeSpan((long)random.Next(ticks, maxValue));
        }

        public IReturnsResultTyped<TMock, TCallbackDelegate> ThrowsAsync<TException>() where TException : Exception, new()
        {
            return ThrowsAsync<TException>();
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
        public IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(InvocationAction action)
        {
            return new ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>(actual.Callback(action), this);
        }

        public IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(Delegate callback)
        {
            return new ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>(actual.Callback(callback), this);
        }

        public IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(Action action)
        {
            return new ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>(actual.Callback(action), this);
        }

        public IReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate> Callback(TCallbackDelegate callback)
        {
            return new ReturnsThrowsTypedAsync<TMock, TResult, TCallbackDelegate, TReturnsDelegate>(actual.Callback(callback), this);
        }
        #endregion

        public IReturnsResultTyped<TMock, TCallbackDelegate> CallBase()
        {
            return new ReturnsResultTyped<TMock, TCallbackDelegate>(actual.CallBase());
        }

        #region Returns

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
    }
    
}
