using System;
using System.ComponentModel;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsResultTyped<TMock, TCallbackDelegate> : IReturnsResultTyped<TMock, TCallbackDelegate>
        where TMock : class
        where TCallbackDelegate : Delegate
    {
        private readonly IReturnsResult<TMock> actual;

        public ReturnsResultTyped(IReturnsResult<TMock> actual)
        {
            this.actual = actual;
        }

        #region IOccurrence
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IVerifies AtMost(int callCount)
        {
            return actual.AtMost(callCount);
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IVerifies AtMostOnce()
        {
            return actual.AtMostOnce();
        }

        #endregion

        #region IVerifies

        public void Verifiable()
        {
            actual.Verifiable();
        }

        public void Verifiable(string failMessage)
        {
            actual.Verifiable(failMessage);
        }

        #endregion

        #region IRaise
        public IVerifies Raises(Action<TMock> eventExpression, EventArgs args)
        {
            return actual.Raises(eventExpression, args);
        }

        public IVerifies Raises(Action<TMock> eventExpression, Func<EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises(Action<TMock> eventExpression, params object[] args)
        {
            return actual.Raises(eventExpression, args);
        }

        public IVerifies Raises<T1>(Action<TMock> eventExpression, Func<T1, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2>(Action<TMock> eventExpression, Func<T1, T2, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3>(Action<TMock> eventExpression, Func<T1, T2, T3, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<TMock> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, EventArgs> func)
        {
            return actual.Raises(eventExpression, func);
        }

        #endregion

        #region ICallbackDelegate
        public ICallbackResult Callback(Action action)
        {
            return actual.Callback(action);
        }

        public ICallbackResult Callback(InvocationAction action)
        {
            return actual.Callback(action);
        }

        public ICallbackResult Callback(Delegate callback)
        {
            return actual.Callback(callback);
        }

        public ICallbackResult Callback(TCallbackDelegate callback)
        {
            return actual.Callback(callback);
        }
        #endregion

    }
}
