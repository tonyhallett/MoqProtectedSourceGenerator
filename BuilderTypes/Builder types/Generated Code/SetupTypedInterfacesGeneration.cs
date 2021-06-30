using System;
using System.ComponentModel;
using Moq;
using Moq.Protected;
using Moq.Language;
using Moq.Language.Flow;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoqProtectedGenerated{

    //applies to ISetup<TMock> and ISetup<TMock,TResult>
    public interface ISetupsTypedBase<TMock> : IFluentInterface, IThrows, IVerifies where TMock:class {}
    #region ICallbackTyped

    public interface ICallbackBase : IFluentInterface {
        ICallbackResult Callback(InvocationAction action);
        ICallbackResult Callback(Delegate callback);//is this really necessary ?
    }

    public interface ICallbackTyped : ICallbackBase {
        ICallbackResult Callback(Action action);
    }

    public interface ICallbackTyped<TArg1> : ICallbackBase {
        ICallbackResult Callback(Action<TArg1> action);
    }

    public interface ICallbackTyped<TArg1,TArg2> : ICallbackBase {
        ICallbackResult Callback(Action<TArg1,TArg2> action);
    }

    public interface ICallbackTyped<TArg1,TArg2,TArg3> : ICallbackBase {
        ICallbackResult Callback(Action<TArg1,TArg2,TArg3> action);
    }
    #endregion
    #region ISetupTyped
    #region Base

    public interface ISetupTypedBase<TMock> : 
        ISetupsTypedBase<TMock>,
        ICallbackBase,
        ICallBase,
        ICallBaseResult,
        ICallbackResult,
        IRaise<TMock> where TMock:class 
    {}

    public abstract class SetupTypedBase<TMock> : ISetupTypedBase<TMock> where TMock : class
    {
        protected readonly ISetup<TMock> actual;

        public SetupTypedBase(ISetup<TMock> actual)
        {
            this.actual = actual;
        }
        
        [Obsolete("To verify this condition, use the overload to Verify that receives Times.AtMostOnce(callCount).")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IVerifies AtMost(int callCount)
        {
            return actual.AtMost(callCount);
        }
    
        [Obsolete("To verify this condition, use the overload to Verify that receives Times.AtMost().")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IVerifies AtMostOnce()
        {
            return actual.AtMostOnce();
        }

        public ICallbackResult Callback(InvocationAction action)
        {
            return actual.Callback(action);
        }

        public ICallbackResult Callback(Delegate callback)
        {
            return actual.Callback(callback);
        }

        public ICallBaseResult CallBase()
        {
            return actual.CallBase();
        }

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

        public override string ToString(){
            return actual.ToString();
        }

    }
    #endregion
    #region 0 args

    public interface ISetupTyped<TMock> : ISetupTypedBase<TMock>, ICallbackTyped where TMock:class { }

    public class SetupTyped<TMock> : SetupTypedBase<TMock>, ISetupTyped<TMock> where TMock:class
    {
        public SetupTyped(ISetup<TMock> actual):base(actual){}
        
        public ICallbackResult Callback(Action action)
        {
            return actual.Callback(action);
        }
    }
    #endregion
    #region 1 arg

    public interface ISetupTyped<TMock,TArg1> : ISetupTypedBase<TMock>, ICallbackTyped<TArg1> where TMock:class {}

    public class SetupTyped<TMock, TArg1> : SetupTypedBase<TMock>, ISetupTyped<TMock, TArg1> where TMock:class
    {
        public SetupTyped(ISetup<TMock> actual):base(actual){}
        
        public ICallbackResult Callback(Action<TArg1> action)
        {
            return actual.Callback(action);
        }
    }
    #endregion
    #region 2 args

    public interface ISetupTyped<TMock,TArg1,TArg2> : ISetupTypedBase<TMock>, ICallbackTyped<TArg1,TArg2> where TMock:class {}

    public class SetupTyped<TMock, TArg1,TArg2> : SetupTypedBase<TMock>, ISetupTyped<TMock, TArg1,TArg2> where TMock:class
    {
        public SetupTyped(ISetup<TMock> actual):base(actual){}
        
        public ICallbackResult Callback(Action<TArg1,TArg2> action)
        {
            return actual.Callback(action);
        }
    }
    #endregion
    #region 3 args

    public interface ISetupTyped<TMock,TArg1,TArg2,TArg3> : ISetupTypedBase<TMock>, ICallbackTyped<TArg1,TArg2,TArg3> where TMock:class {}

    public class SetupTyped<TMock, TArg1,TArg2,TArg3> : SetupTypedBase<TMock>, ISetupTyped<TMock, TArg1,TArg2,TArg3> where TMock:class
    {
        public SetupTyped(ISetup<TMock> actual):base(actual){}
        
        public ICallbackResult Callback(Action<TArg1,TArg2,TArg3> action)
        {
            return actual.Callback(action);
        }
    }
    #endregion
    #endregion
    #region ISetupTypedResult
    #region Base

    public class SetupTypedResultBase<TMock, TResult> : IThrows, IVerifies where TMock : class
    {
        protected readonly ISetup<TMock, TResult> actual;
        public SetupTypedResultBase(ISetup<TMock, TResult> actual)
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
        
        public override string ToString(){
            return actual.ToString();
        }
    
    }

    public class ReturnsThrowsTypedBase<TMock, TResult> : IThrows where TMock : class
    {
        protected IReturnsThrows<TMock, TResult> actual;

        public ReturnsThrowsTypedBase(IReturnsThrows<TMock, TResult> actual)
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
    }

    public class ReturnsResultTypedBase<TMock> : ICallbackBase, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies
    {
        protected readonly IReturnsResult<TMock> actual;

        public ReturnsResultTypedBase(IReturnsResult<TMock> actual)
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

        #region ICallbackBase

        public ICallbackResult Callback(InvocationAction action)
        {
            return actual.Callback(action);
        }

        public ICallbackResult Callback(Delegate callback)
        {
            return actual.Callback(callback);
        }
        #endregion

    }

    #endregion
    #region 0 args

    public interface ISetupTypedResult<TMock,TResult> : 
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock,TResult>,
        IReturnsTyped<TMock,TResult>
        where TMock : class 
    {
        IReturnsThrowsTyped<TMock,TResult> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock,TResult> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock,TResult> Callback(Action action);
    }

    public interface IReturnsResultTyped<TMock> : 
        ICallbackTyped, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies where TMock : class { }
    
    public interface IReturnsThrowsTyped<TMock, TResult> : 
        IReturnsTyped<TMock, TResult>, IFluentInterface, IThrows where TMock : class {}

    public interface IReturnsTyped<TMock, TResult> : IFluentInterface where TMock : class {
        IReturnsResultTyped<TMock> CallBase();
        IReturnsResultTyped<TMock> Returns(TResult value);
        IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction);
        
    }

    public class ReturnsThrowsTyped<TMock,TResult> : ReturnsThrowsTypedBase<TMock, TResult>, IReturnsThrowsTyped<TMock,TResult> where TMock : class
    {
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) { }

        public IReturnsResultTyped<TMock> CallBase()
        {
            return new ReturnsResultTyped<TMock>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

    }

    public class ReturnsResultTyped<TMock> : ReturnsResultTypedBase<TMock>, IReturnsResultTyped<TMock> where TMock : class
    {
        public ReturnsResultTyped(IReturnsResult<TMock> actual) : base(actual) { }

        public ICallbackResult Callback(Action action)
        {
            return actual.Callback(action);
        }
    
    }

    public class SetupTypedResult<TMock, TResult> : SetupTypedResultBase<TMock,TResult>, ISetupTypedResult<TMock, TResult> where TMock:class
    {
        public SetupTypedResult(ISetup<TMock, TResult> actual) : base(actual) { }

        #region Callback
        public IReturnsThrowsTyped<TMock, TResult> Callback(InvocationAction action)
        {
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(action));
        }

        public IReturnsThrowsTyped<TMock, TResult> Callback(Delegate callback)
        {
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(callback));
        }

        public IReturnsThrowsTyped<TMock, TResult> Callback(Action action)
        {
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(action));
        }
        #endregion

        public IReturnsResultTyped<TMock> CallBase()
        {
            return new ReturnsResultTyped<TMock>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }

    }

    #endregion
    #region 1 arg

    public interface ISetupTypedResult<TMock,TArg1,TResult> : 
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock,TArg1,TResult>,
        IReturnsTyped<TMock,TArg1, TResult>
        where TMock : class 
    {
        IReturnsThrowsTyped<TMock,TArg1, TResult> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock,TArg1, TResult> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock,TArg1, TResult> Callback(Action<TArg1> action);
    }

    public interface IReturnsResultTyped<TMock,TArg1> : 
        ICallbackTyped<TArg1>, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies where TMock : class { }
    
    public interface IReturnsThrowsTyped<TMock,TArg1, TResult> : 
        IReturnsTyped<TMock, TArg1, TResult>, IFluentInterface, IThrows where TMock : class {}

    public interface IReturnsTyped<TMock, TArg1, TResult> : IFluentInterface where TMock : class {
        IReturnsResultTyped<TMock,TArg1> CallBase();
        IReturnsResultTyped<TMock,TArg1> Returns(TResult value);
        IReturnsResultTyped<TMock,TArg1> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock,TArg1> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock,TArg1> Returns(Func<TArg1, TResult> valueFunction);
        
    }

    public class ReturnsThrowsTyped<TMock, TArg1, TResult> : ReturnsThrowsTypedBase<TMock, TResult>, IReturnsThrowsTyped<TMock,TArg1, TResult> where TMock : class
    {
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) { }

        public IReturnsResultTyped<TMock, TArg1> CallBase()
        {
            return new ReturnsResultTyped<TMock,TArg1>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock,TArg1> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock,TArg1>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(Func<TArg1, TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

    }

    public class ReturnsResultTyped<TMock,TArg1> : ReturnsResultTypedBase<TMock>, IReturnsResultTyped<TMock, TArg1> where TMock : class
    {
        public ReturnsResultTyped(IReturnsResult<TMock> actual) : base(actual) { }

        public ICallbackResult Callback(Action<TArg1> action)
        {
            return actual.Callback(action);
        }
    
    }

    public class SetupTypedResult<TMock, TArg1, TResult> : SetupTypedResultBase<TMock,TResult>, ISetupTypedResult<TMock, TArg1, TResult> where TMock:class
    {
        public SetupTypedResult(ISetup<TMock, TResult> actual) : base(actual) { }

        #region Callback
        public IReturnsThrowsTyped<TMock, TArg1, TResult> Callback(InvocationAction action)
        {
            return new ReturnsThrowsTyped<TMock, TArg1, TResult>(actual.Callback(action));
        }

        public IReturnsThrowsTyped<TMock,TArg1, TResult> Callback(Delegate callback)
        {
            return new ReturnsThrowsTyped<TMock, TArg1, TResult>(actual.Callback(callback));
        }

        public IReturnsThrowsTyped<TMock, TArg1, TResult> Callback(Action<TArg1> action)
        {
            return new ReturnsThrowsTyped<TMock, TArg1, TResult>(actual.Callback(action));
        }
        #endregion

        public IReturnsResultTyped<TMock, TArg1> CallBase()
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock,TArg1>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1> Returns(Func<TArg1, TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1>(actual.Returns(valueFunction));
        }

    }

    #endregion
    #region 2 args

    public interface ISetupTypedResult<TMock,TArg1,TArg2,TResult> : 
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock,TArg1,TArg2,TResult>,
        IReturnsTyped<TMock,TArg1,TArg2, TResult>
        where TMock : class 
    {
        IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> Callback(Action<TArg1,TArg2> action);
    }

    public interface IReturnsResultTyped<TMock,TArg1,TArg2> : 
        ICallbackTyped<TArg1,TArg2>, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies where TMock : class { }
    
    public interface IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> : 
        IReturnsTyped<TMock, TArg1,TArg2, TResult>, IFluentInterface, IThrows where TMock : class {}

    public interface IReturnsTyped<TMock, TArg1,TArg2, TResult> : IFluentInterface where TMock : class {
        IReturnsResultTyped<TMock,TArg1,TArg2> CallBase();
        IReturnsResultTyped<TMock,TArg1,TArg2> Returns(TResult value);
        IReturnsResultTyped<TMock,TArg1,TArg2> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock,TArg1,TArg2> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock,TArg1,TArg2> Returns(Func<TArg1,TArg2, TResult> valueFunction);
        
    }

    public class ReturnsThrowsTyped<TMock, TArg1,TArg2, TResult> : ReturnsThrowsTypedBase<TMock, TResult>, IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> where TMock : class
    {
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) { }

        public IReturnsResultTyped<TMock, TArg1,TArg2> CallBase()
        {
            return new ReturnsResultTyped<TMock,TArg1,TArg2>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock,TArg1,TArg2> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock,TArg1,TArg2>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(Func<TArg1,TArg2, TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

    }

    public class ReturnsResultTyped<TMock,TArg1,TArg2> : ReturnsResultTypedBase<TMock>, IReturnsResultTyped<TMock, TArg1,TArg2> where TMock : class
    {
        public ReturnsResultTyped(IReturnsResult<TMock> actual) : base(actual) { }

        public ICallbackResult Callback(Action<TArg1,TArg2> action)
        {
            return actual.Callback(action);
        }
    
    }

    public class SetupTypedResult<TMock, TArg1,TArg2, TResult> : SetupTypedResultBase<TMock,TResult>, ISetupTypedResult<TMock, TArg1,TArg2, TResult> where TMock:class
    {
        public SetupTypedResult(ISetup<TMock, TResult> actual) : base(actual) { }

        #region Callback
        public IReturnsThrowsTyped<TMock, TArg1,TArg2, TResult> Callback(InvocationAction action)
        {
            return new ReturnsThrowsTyped<TMock, TArg1,TArg2, TResult>(actual.Callback(action));
        }

        public IReturnsThrowsTyped<TMock,TArg1,TArg2, TResult> Callback(Delegate callback)
        {
            return new ReturnsThrowsTyped<TMock, TArg1,TArg2, TResult>(actual.Callback(callback));
        }

        public IReturnsThrowsTyped<TMock, TArg1,TArg2, TResult> Callback(Action<TArg1,TArg2> action)
        {
            return new ReturnsThrowsTyped<TMock, TArg1,TArg2, TResult>(actual.Callback(action));
        }
        #endregion

        public IReturnsResultTyped<TMock, TArg1,TArg2> CallBase()
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.CallBase());
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(TResult value)
        {
            return new ReturnsResultTyped<TMock,TArg1,TArg2>(actual.Returns(value));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(InvocationFunc valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(Delegate valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

        public IReturnsResultTyped<TMock, TArg1,TArg2> Returns(Func<TArg1,TArg2, TResult> valueFunction)
        {
            return new ReturnsResultTyped<TMock, TArg1,TArg2>(actual.Returns(valueFunction));
        }

    }

    #endregion
    #endregion
    #region Indexer fluent
    #region 1 arg

    public interface IIndexerGetterBuilder<TMock, TArg1,TProperty> :
        ISetupVerifyBuilder<ISetupTypedResult<TMock, TArg1, TProperty>, ISetupSequentialResult<TProperty>>
        where TMock : class { }

    public interface IIndexerSetterBuilder<TMock, TArg1,TProperty> :
        ISetupVerifyBuilder<ISetupTyped<TMock, TArg1,TProperty>, ISetupSequentialAction>
        where TMock : class { }

    public class IndexerGetterBuilder<TMock, TArg1, TProperty> :
        SetupVerifyBuilder<ISetupTypedResult<TMock, TArg1, TProperty>, ISetupSequentialResult<TProperty>>,
        IIndexerGetterBuilder<TMock, TArg1, TProperty>
        where TMock : class
    {
        public IndexerGetterBuilder(
            Func<string, int, ISetupTypedResult<TMock, TArg1, TProperty>> setup,
            Func<string, int, ISetupSequentialResult<TProperty>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }

    public class IndexerSetterBuilder<TMock,TArg1,TProperty> :
        SetupVerifyBuilder<ISetupTyped<TMock, TArg1,TProperty>, ISetupSequentialAction>,
        IIndexerSetterBuilder<TMock, TArg1,TProperty>
        where TMock : class
    {
        public IndexerSetterBuilder(
            Func<string, int, ISetupTyped<TMock,TArg1,TProperty>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }

    public interface IIndexerFluentGet<TMock,TArg1,TProperty> where TMock : class
    {
        IIndexerGetterBuilder<TMock,TArg1, TProperty> Get(TArg1 key1);
    }

    public interface IIndexerFluentSet<TMock, TArg1, TProperty> where TMock : class
    {
        IIndexerSetterBuilder<TMock,TArg1,TProperty> Set(TArg1 key1, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TArg1,TProperty> : 
        IIndexerFluentGet<TMock, TArg1, TProperty>, 
        IIndexerFluentSet<TMock, TArg1, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TArg1, TProperty> : IIndexerFluentGetSet<TMock, TArg1, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TArg1, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TArg1, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TArg1, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TArg1, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IIndexerGetterBuilder<TMock, TArg1, TProperty> Get(TArg1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new IndexerGetterBuilder<TMock, TArg1, TProperty>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock, TArg1, TProperty>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1), t, failMessage);
                });
        }

        public IIndexerSetterBuilder<TMock, TArg1, TProperty> Set(TArg1 key1, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new IndexerSetterBuilder<TMock, TArg1,TProperty>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, TArg1, TProperty>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 2 args

    public interface IIndexerGetterBuilder<TMock, TArg1,TArg2,TProperty> :
        ISetupVerifyBuilder<ISetupTypedResult<TMock, TArg1,TArg2, TProperty>, ISetupSequentialResult<TProperty>>
        where TMock : class { }

    public interface IIndexerSetterBuilder<TMock, TArg1,TArg2,TProperty> :
        ISetupVerifyBuilder<ISetupTyped<TMock, TArg1,TArg2,TProperty>, ISetupSequentialAction>
        where TMock : class { }

    public class IndexerGetterBuilder<TMock, TArg1,TArg2, TProperty> :
        SetupVerifyBuilder<ISetupTypedResult<TMock, TArg1,TArg2, TProperty>, ISetupSequentialResult<TProperty>>,
        IIndexerGetterBuilder<TMock, TArg1,TArg2, TProperty>
        where TMock : class
    {
        public IndexerGetterBuilder(
            Func<string, int, ISetupTypedResult<TMock, TArg1,TArg2, TProperty>> setup,
            Func<string, int, ISetupSequentialResult<TProperty>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }

    public class IndexerSetterBuilder<TMock,TArg1,TArg2,TProperty> :
        SetupVerifyBuilder<ISetupTyped<TMock, TArg1,TArg2,TProperty>, ISetupSequentialAction>,
        IIndexerSetterBuilder<TMock, TArg1,TArg2,TProperty>
        where TMock : class
    {
        public IndexerSetterBuilder(
            Func<string, int, ISetupTyped<TMock,TArg1,TArg2,TProperty>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) { }
    }

    public interface IIndexerFluentGet<TMock,TArg1,TArg2,TProperty> where TMock : class
    {
        IIndexerGetterBuilder<TMock,TArg1,TArg2, TProperty> Get(TArg1 key1,TArg2 key2);
    }

    public interface IIndexerFluentSet<TMock, TArg1,TArg2, TProperty> where TMock : class
    {
        IIndexerSetterBuilder<TMock,TArg1,TArg2,TProperty> Set(TArg1 key1,TArg2 key2, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TArg1,TArg2,TProperty> : 
        IIndexerFluentGet<TMock, TArg1,TArg2, TProperty>, 
        IIndexerFluentSet<TMock, TArg1,TArg2, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TArg1,TArg2, TProperty> : IIndexerFluentGetSet<TMock, TArg1,TArg2, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TArg1,TArg2, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TArg1,TArg2, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TArg1,TArg2, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TArg1,TArg2, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IIndexerGetterBuilder<TMock, TArg1,TArg2, TProperty> Get(TArg1 key1,TArg2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new IndexerGetterBuilder<TMock, TArg1,TArg2, TProperty>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock, TArg1,TArg2, TProperty>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2), t, failMessage);
                });
        }

        public IIndexerSetterBuilder<TMock, TArg1,TArg2, TProperty> Set(TArg1 key1,TArg2 key2, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new IndexerSetterBuilder<TMock, TArg1,TArg2,TProperty>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, TArg1,TArg2, TProperty>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #endregion

}
