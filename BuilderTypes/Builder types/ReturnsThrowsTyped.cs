using System;
using Moq.Language.Flow;

namespace MoqProtectedGenerated
{
    public class ReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> :
        ReturnsTypedBase<TMock, TResult, TCallbackDelegate, TReturnsDelegate>,
        IReturnsThrowsTyped<TMock, TResult, TCallbackDelegate, TReturnsDelegate> 
        where TMock : class
        where TCallbackDelegate : Delegate
        where TReturnsDelegate : Delegate
    {
        public ReturnsThrowsTyped(IReturnsThrows<TMock, TResult> actual) : base(actual) { }

        public IThrowsResult Throws(Exception exception)
        {
            return actual.Throws(exception);
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            return actual.Throws<TException>();
        }

        
    }
}
