using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ANamespace;

public static class MyProtected_AbstractMethodArgs
{
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
        new Dictionary<string, Expression<Action<MyProtectedLike>>> { };
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
        new Dictionary<string, Expression<Action<MyProtectedLike>>> { };

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {
        return sourceFileInfo + "_" + sourceLineNumber;
    }

    public static IVoidMethodBuilder<MyProtected> AbstractMethodArgs(this Mock<MyProtected> mock, int value)
    {
        return new VoidMethodBuilder<MyProtected>(
            (sourceFileInfo, sourceLineNumber) => mock.Protected().As<MyProtectedLike>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<MyProtectedLike>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
        );
    }
}

public static class MyProtected_AbstractMethodWithReturn
{
    private static readonly Dictionary<string, Expression<Func<MyProtectedLike,int>>> Setups =
        new Dictionary<string, Expression<Func<MyProtectedLike,int>>> {
            { "the path", like => like.AbstractMethodWithReturn()}
        
        };
    private static readonly Dictionary<string, Expression<Func<MyProtectedLike,int>>> Verifications =
        new Dictionary<string, Expression<Func<MyProtectedLike,int>>> { };

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {
        return sourceFileInfo + "_" + sourceLineNumber;
    }

    public static IReturningMethodBuilder<MyProtected,int> AbstractMethodWithReturn(this Mock<MyProtected> mock, int value)
    {
        return new ReturningMethodBuilder<MyProtected,int>(
            (sourceFileInfo, sourceLineNumber) => mock.Protected().As<MyProtectedLike>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<MyProtectedLike>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
        );
    }
}