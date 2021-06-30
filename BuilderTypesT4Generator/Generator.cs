using System;
using System.Text;

namespace BuilderTypesT4Generator
{
    public class BuilderTypesGenerator
    {
        public static string GenerateTypes(int numTypeArguments)
        {
            return $@"{Usings}
{WithNamespace(GetTypes(numTypeArguments))}
";
        }

        private static string WithNamespace(string interfaces)
        {
            return $@"namespace MoqProtectedGenerated{{
{interfaces}
}}";
        }

        private static string Usings =>
@"using System;
using System.ComponentModel;
using Moq;
using Moq.Protected;
using Moq.Language;
using Moq.Language.Flow;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;
";

        private static string GetTypes(int numTypeArguments)
        {
            var stringBuilder = new StringBuilder(@"
    //applies to ISetup<TMock> and ISetup<TMock,TResult>
    public interface ISetupsTypedBase<TMock> : IFluentInterface, IThrows, IVerifies where TMock:class {}
");
            AddICallbackTyped(numTypeArguments + 1, stringBuilder);
            AddISetupTyped(numTypeArguments + 1, stringBuilder);
            AddISetupTypedResult(numTypeArguments, stringBuilder);
            AddIndexerFluent(numTypeArguments, stringBuilder);
            return stringBuilder.ToString();
        }

        private static void AddRegion(string regionName,StringBuilder stringBuilder,Action addCode)
        {
            stringBuilder.AppendLine($"    #region {regionName}");
            addCode();
            stringBuilder.AppendLine("    #endregion");
        }
        
        private static void AddICallbackTyped(int numTypeArguments, StringBuilder stringBuilder)
        {
            AddRegion("ICallbackTyped", stringBuilder, () =>
              {
                  stringBuilder.Append(@"
    public interface ICallbackBase : IFluentInterface {
        ICallbackResult Callback(InvocationAction action);
        ICallbackResult Callback(Delegate callback);//is this really necessary ?
    }
");
                  stringBuilder.Append(@"
    public interface ICallbackTyped : ICallbackBase {
        ICallbackResult Callback(Action action);
    }
");
                  var typeArgs = "";
                  for (var i = 1; i < numTypeArguments + 1; i++)
                  {
                      if (i != 1)
                      {
                          typeArgs += ",";
                      }
                      typeArgs += $"TArg{i}";
                      stringBuilder.Append($@"
    public interface ICallbackTyped<{typeArgs}> : ICallbackBase {{
        ICallbackResult Callback(Action<{typeArgs}> action);
    }}
");
                  }


              });
        }
        
        private static void AddISetupTyped(int numTypeArguments, StringBuilder stringBuilder)
        {
            AddRegion("ISetupTyped", stringBuilder, () =>
            {
                AddRegion("Base", stringBuilder, () =>
                {
                    stringBuilder.Append(@"
    public interface ISetupTypedBase<TMock> : 
        ISetupsTypedBase<TMock>,
        ICallbackBase,
        ICallBase,
        ICallBaseResult,
        ICallbackResult,
        IRaise<TMock> where TMock:class 
    {}
");
                    stringBuilder.Append(GetISetupTypedBaseImplementation());

                });
                AddRegion("0 args", stringBuilder, () =>
                {
                    stringBuilder.Append($@"
    public interface ISetupTyped<TMock> : ISetupTypedBase<TMock>, ICallbackTyped where TMock:class {{ }}

    public class SetupTyped<TMock> : SetupTypedBase<TMock>, ISetupTyped<TMock> where TMock:class
    {{
        public SetupTyped(ISetup<TMock> actual):base(actual){{}}
        
        public ICallbackResult Callback(Action action)
        {{
            return actual.Callback(action);
        }}
    }}
");
                });
                

                var typeArgs = "";
                for (var i = 1; i < numTypeArguments + 1; i++)
                {
                    if (i != 1)
                    {
                        typeArgs += ",";
                    }
                    typeArgs += $"TArg{i}";

                    AddRegion(i == 1 ? "1 arg" : $"{i} args",stringBuilder, () =>
                    {
                        stringBuilder.Append($@"
    public interface ISetupTyped<TMock,{typeArgs}> : ISetupTypedBase<TMock>, ICallbackTyped<{typeArgs}> where TMock:class {{}}

    public class SetupTyped<TMock, {typeArgs}> : SetupTypedBase<TMock>, ISetupTyped<TMock, {typeArgs}> where TMock:class
    {{
        public SetupTyped(ISetup<TMock> actual):base(actual){{}}
        
        public ICallbackResult Callback(Action<{typeArgs}> action)
        {{
            return actual.Callback(action);
        }}
    }}
");
                    });
                }
            });

        }

        private static string GetISetupTypedBaseImplementation()
        {
            return @"
    public abstract class SetupTypedBase<TMock> : ISetupTypedBase<TMock> where TMock : class
    {
        protected readonly ISetup<TMock> actual;

        public SetupTypedBase(ISetup<TMock> actual)
        {
            this.actual = actual;
        }
        
        [Obsolete(""To verify this condition, use the overload to Verify that receives Times.AtMostOnce(callCount)."")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IVerifies AtMost(int callCount)
        {
            return actual.AtMost(callCount);
        }
    
        [Obsolete(""To verify this condition, use the overload to Verify that receives Times.AtMost()."")]
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
";
        }

        private static void AddISetupTypedResult(int numTypeArguments, StringBuilder stringBuilder)
        {
            AddRegion("ISetupTypedResult", stringBuilder, () =>
            {
                AddRegion("Base", stringBuilder, () =>
                {
                    stringBuilder.Append(@"
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

");
                });


                AddRegion("0 args", stringBuilder, () =>
                {
                    stringBuilder.Append($@"
    public interface ISetupTypedResult<TMock,TResult> : 
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock,TResult>,
        IReturnsTyped<TMock,TResult>
        where TMock : class 
    {{
        IReturnsThrowsTyped<TMock,TResult> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock,TResult> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock,TResult> Callback(Action action);
    }}

    public interface IReturnsResultTyped<TMock> : 
        ICallbackTyped, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies where TMock : class {{ }}
    
    public interface IReturnsThrowsTyped<TMock, TResult> : 
        IReturnsTyped<TMock, TResult>, IFluentInterface, IThrows where TMock : class {{}}

    public interface IReturnsTyped<TMock, TResult> : IFluentInterface where TMock : class {{
        IReturnsResultTyped<TMock> CallBase();
        IReturnsResultTyped<TMock> Returns(TResult value);
        IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction);
        
    }}

    public class ReturnsThrowsTyped<TMock,TResult> : ReturnsThrowsTypedBase<TMock, TResult>, IReturnsThrowsTyped<TMock,TResult> where TMock : class
    {{
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) {{ }}

        public IReturnsResultTyped<TMock> CallBase()
        {{
            return new ReturnsResultTyped<TMock>(actual.CallBase());
        }}

        public IReturnsResultTyped<TMock> Returns(TResult value)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(value));
        }}

        public IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock> Returns(Delegate valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

    }}

    public class ReturnsResultTyped<TMock> : ReturnsResultTypedBase<TMock>, IReturnsResultTyped<TMock> where TMock : class
    {{
        public ReturnsResultTyped(IReturnsResult<TMock> actual) : base(actual) {{ }}

        public ICallbackResult Callback(Action action)
        {{
            return actual.Callback(action);
        }}
    
    }}

    public class SetupTypedResult<TMock, TResult> : SetupTypedResultBase<TMock,TResult>, ISetupTypedResult<TMock, TResult> where TMock:class
    {{
        public SetupTypedResult(ISetup<TMock, TResult> actual) : base(actual) {{ }}

        #region Callback
        public IReturnsThrowsTyped<TMock, TResult> Callback(InvocationAction action)
        {{
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(action));
        }}

        public IReturnsThrowsTyped<TMock, TResult> Callback(Delegate callback)
        {{
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(callback));
        }}

        public IReturnsThrowsTyped<TMock, TResult> Callback(Action action)
        {{
            return new ReturnsThrowsTyped<TMock, TResult>(actual.Callback(action));
        }}
        #endregion

        public IReturnsResultTyped<TMock> CallBase()
        {{
            return new ReturnsResultTyped<TMock>(actual.CallBase());
        }}

        public IReturnsResultTyped<TMock> Returns(TResult value)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(value));
        }}

        public IReturnsResultTyped<TMock> Returns(InvocationFunc valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock> Returns(Delegate valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock> Returns(Func<TResult> valueFunction)
        {{
            return new ReturnsResultTyped<TMock>(actual.Returns(valueFunction));
        }}

    }}

");
                });


                var typeArgs = "";
                for (var i = 1; i < numTypeArguments + 1; i++)
                {
                    if (i != 1)
                    {
                        typeArgs += ",";
                    }
                    typeArgs += $"TArg{i}";
                    AddRegion(i == 1 ? "1 arg" : $"{i} args", stringBuilder, () =>
                    {
                        stringBuilder.Append($@"
    public interface ISetupTypedResult<TMock,{typeArgs},TResult> : 
        ISetupsTypedBase<TMock>,
        IReturnsThrowsTyped<TMock,{typeArgs},TResult>,
        IReturnsTyped<TMock,{typeArgs}, TResult>
        where TMock : class 
    {{
        IReturnsThrowsTyped<TMock,{typeArgs}, TResult> Callback(InvocationAction action);
        IReturnsThrowsTyped<TMock,{typeArgs}, TResult> Callback(Delegate callback);
        IReturnsThrowsTyped<TMock,{typeArgs}, TResult> Callback(Action<{typeArgs}> action);
    }}

    public interface IReturnsResultTyped<TMock,{typeArgs}> : 
        ICallbackTyped<{typeArgs}>, IFluentInterface, IOccurrence, IRaise<TMock>, IVerifies where TMock : class {{ }}
    
    public interface IReturnsThrowsTyped<TMock,{typeArgs}, TResult> : 
        IReturnsTyped<TMock, {typeArgs}, TResult>, IFluentInterface, IThrows where TMock : class {{}}

    public interface IReturnsTyped<TMock, {typeArgs}, TResult> : IFluentInterface where TMock : class {{
        IReturnsResultTyped<TMock,{typeArgs}> CallBase();
        IReturnsResultTyped<TMock,{typeArgs}> Returns(TResult value);
        IReturnsResultTyped<TMock,{typeArgs}> Returns(InvocationFunc valueFunction);
        IReturnsResultTyped<TMock,{typeArgs}> Returns(Delegate valueFunction);
        IReturnsResultTyped<TMock,{typeArgs}> Returns(Func<{typeArgs}, TResult> valueFunction);
        
    }}

    public class ReturnsThrowsTyped<TMock, {typeArgs}, TResult> : ReturnsThrowsTypedBase<TMock, TResult>, IReturnsThrowsTyped<TMock,{typeArgs}, TResult> where TMock : class
    {{
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) {{ }}

        public IReturnsResultTyped<TMock, {typeArgs}> CallBase()
        {{
            return new ReturnsResultTyped<TMock,{typeArgs}>(actual.CallBase());
        }}

        public IReturnsResultTyped<TMock,{typeArgs}> Returns(TResult value)
        {{
            return new ReturnsResultTyped<TMock,{typeArgs}>(actual.Returns(value));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(InvocationFunc valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(Delegate valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(Func<{typeArgs}, TResult> valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

    }}

    public class ReturnsResultTyped<TMock,{typeArgs}> : ReturnsResultTypedBase<TMock>, IReturnsResultTyped<TMock, {typeArgs}> where TMock : class
    {{
        public ReturnsResultTyped(IReturnsResult<TMock> actual) : base(actual) {{ }}

        public ICallbackResult Callback(Action<{typeArgs}> action)
        {{
            return actual.Callback(action);
        }}
    
    }}

    public class SetupTypedResult<TMock, {typeArgs}, TResult> : SetupTypedResultBase<TMock,TResult>, ISetupTypedResult<TMock, {typeArgs}, TResult> where TMock:class
    {{
        public SetupTypedResult(ISetup<TMock, TResult> actual) : base(actual) {{ }}

        #region Callback
        public IReturnsThrowsTyped<TMock, {typeArgs}, TResult> Callback(InvocationAction action)
        {{
            return new ReturnsThrowsTyped<TMock, {typeArgs}, TResult>(actual.Callback(action));
        }}

        public IReturnsThrowsTyped<TMock,{typeArgs}, TResult> Callback(Delegate callback)
        {{
            return new ReturnsThrowsTyped<TMock, {typeArgs}, TResult>(actual.Callback(callback));
        }}

        public IReturnsThrowsTyped<TMock, {typeArgs}, TResult> Callback(Action<{typeArgs}> action)
        {{
            return new ReturnsThrowsTyped<TMock, {typeArgs}, TResult>(actual.Callback(action));
        }}
        #endregion

        public IReturnsResultTyped<TMock, {typeArgs}> CallBase()
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.CallBase());
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(TResult value)
        {{
            return new ReturnsResultTyped<TMock,{typeArgs}>(actual.Returns(value));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(InvocationFunc valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(Delegate valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

        public IReturnsResultTyped<TMock, {typeArgs}> Returns(Func<{typeArgs}, TResult> valueFunction)
        {{
            return new ReturnsResultTyped<TMock, {typeArgs}>(actual.Returns(valueFunction));
        }}

    }}

");

                    });
                }
            });

        }

        private static void AddIndexerFluent(int numTypeArguments, StringBuilder stringBuilder)
        {
            AddRegion("Indexer fluent", stringBuilder, () =>
            {
                var typeArgs = "";
                var getSetParameters = "";
                var getSetArguments = "";
                for (var i = 1; i < numTypeArguments + 1; i++)
                {
                    if (i != 1)
                    {
                        typeArgs += ",";
                        getSetParameters += ",";
                        getSetArguments += ",";

                    }
                    var typeArg = $"TArg{i}";
                    typeArgs += typeArg;
                    getSetParameters += $"{typeArg} key{i}";
                    getSetArguments += $"key{i}";

                    AddRegion(i == 1 ? "1 arg" : $"{i} args", stringBuilder, () =>
                    {
                        stringBuilder.Append($@"
    public interface IIndexerGetterBuilder<TMock, {typeArgs},TProperty> :
        ISetupVerifyBuilder<ISetupTypedResult<TMock, {typeArgs}, TProperty>, ISetupSequentialResult<TProperty>>
        where TMock : class {{ }}

    public interface IIndexerSetterBuilder<TMock, {typeArgs},TProperty> :
        ISetupVerifyBuilder<ISetupTyped<TMock, {typeArgs},TProperty>, ISetupSequentialAction>
        where TMock : class {{ }}

    public class IndexerGetterBuilder<TMock, {typeArgs}, TProperty> :
        SetupVerifyBuilder<ISetupTypedResult<TMock, {typeArgs}, TProperty>, ISetupSequentialResult<TProperty>>,
        IIndexerGetterBuilder<TMock, {typeArgs}, TProperty>
        where TMock : class
    {{
        public IndexerGetterBuilder(
            Func<string, int, ISetupTypedResult<TMock, {typeArgs}, TProperty>> setup,
            Func<string, int, ISetupSequentialResult<TProperty>> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) {{ }}
    }}

    public class IndexerSetterBuilder<TMock,{typeArgs},TProperty> :
        SetupVerifyBuilder<ISetupTyped<TMock, {typeArgs},TProperty>, ISetupSequentialAction>,
        IIndexerSetterBuilder<TMock, {typeArgs},TProperty>
        where TMock : class
    {{
        public IndexerSetterBuilder(
            Func<string, int, ISetupTyped<TMock,{typeArgs},TProperty>> setup,
            Func<string, int, ISetupSequentialAction> setupSequence,
            Action<string, int, Times?, string> verify
        ) : base(setup, setupSequence, verify) {{ }}
    }}

    public interface IIndexerFluentGet<TMock,{typeArgs},TProperty> where TMock : class
    {{
        IIndexerGetterBuilder<TMock,{typeArgs}, TProperty> Get({getSetParameters});
    }}

    public interface IIndexerFluentSet<TMock, {typeArgs}, TProperty> where TMock : class
    {{
        IIndexerSetterBuilder<TMock,{typeArgs},TProperty> Set({getSetParameters}, TProperty value);
    }}
    
    public interface IIndexerFluentGetSet<TMock,{typeArgs},TProperty> : 
        IIndexerFluentGet<TMock, {typeArgs}, TProperty>, 
        IIndexerFluentSet<TMock, {typeArgs}, TProperty> where TMock : class {{}}

    public class IndexerFluentGetSet<TMock, TLike, {typeArgs}, TProperty> : IIndexerFluentGetSet<TMock, {typeArgs}, TProperty>
        where TMock : class
        where TLike : class
    {{
        private readonly Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, {typeArgs}, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, {typeArgs}, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {{
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }}

        public IIndexerGetterBuilder<TMock, {typeArgs}, TProperty> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new IndexerGetterBuilder<TMock, {typeArgs}, TProperty>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock, {typeArgs}, TProperty>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments})),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {{
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {{
                        t = times.Value;
                    }}
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}), t, failMessage);
                }});
        }}

        public IIndexerSetterBuilder<TMock, {typeArgs}, TProperty> Set({getSetParameters}, TProperty value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new IndexerSetterBuilder<TMock, {typeArgs},TProperty>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, {typeArgs}, TProperty>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }}
    
");
                    });
                }
            });
        }
    }
}
