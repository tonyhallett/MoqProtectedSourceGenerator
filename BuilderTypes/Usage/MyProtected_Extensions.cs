using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ANamespace;
using MoqProtectedTyped;

public static class MyProtected_Extensions
{
    private static readonly Dictionary<string, List<ParameterInfo>> Setups =
        new Dictionary<string, List<ParameterInfo>> { };

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {
        return sourceFileInfo + "_" + sourceLineNumber;
    }

    public static IVoidMethodBuilder<MyProtected> AbstractMethod(this ProtectedMock<MyProtected> protectedMock)
    {
        var mock = protectedMock.Mock;
        var protectedLike = mock.Protected().As<MyProtectedLike>();
        var likeParameter = Expression.Parameter(typeof(MyProtectedLike));
        
        var matches = MatcherObserver.GetMatches();

        Expression<Action<MyProtectedLike>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber)
        {
            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];

            var expressionArgs = new Expression[] { };

            var call = Expression.Call(likeParameter, "AbstractMethod", new Type[] { }, expressionArgs);
            return Expression.Lambda<Action<MyProtectedLike>>(call, likeParameter);
        }

        return new VoidMethodBuilder<MyProtected>(
            (sourceFileInfo, sourceLineNumber) =>
                protectedLike.Setup(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber)),
            (sourceFileInfo, sourceLineNumber) =>
                protectedLike.SetupSequence(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber)),
            (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                protectedLike.Verify(GetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber), times, failMessage)
        );
    }
    
    public static INonIndexerFluentGetSet<MyProtected,int> GetSet(this ProtectedMock<MyProtected> protectedMock)
    {
        //var mock = protectedMock.Mock;
        //var protectedLike = mock.Protected().As<MyProtectedLike>();

        var likeParameter = Expression.Parameter(typeof(MyProtectedLike));

        // this is only pertinent to set - which cannot do yet
        Expression<Action<MyProtectedLike>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber,List<Match> matches,int propertyValue)
        {
            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

            var expressionArg0 = setupExpression.Create((int)propertyValue, parameterInfos[0]);
            
            var body = Expression.Assign(Expression.Property(likeParameter, "GetSet"),expressionArg0);
            return Expression.Lambda<Action<MyProtectedLike>>(body, likeParameter);
        }
        return new NonIndexerFluentGetSet<MyProtected, MyProtectedLike, int>(protectedMock, GetSetUpOrVerifyExpression, like => like.GetSet);
        
    }

    //public static INonIndexerFluentGetSet<MyProtected, int> Index(this ProtectedMock<MyProtected> protectedMock)
    //{
    //    //var mock = protectedMock.Mock;
    //    //var protectedLike = mock.Protected().As<MyProtectedLike>();

    //    var likeParameter = Expression.Parameter(typeof(MyProtectedLike));

    //    // this is only pertinent to set - which cannot do yet
    //    Expression<Action<MyProtectedLike>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches, int propertyValue)
    //    {
    //        var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
    //        var setupExpression = new SetupExpressionArgument(matches);

    //        var expressionArg0 = setupExpression.Create((int)propertyValue, parameterInfos[0]);

    //        var body = Expression.Assign(Expression.Property(likeParameter, "GetSet"), expressionArg0);
    //        return Expression.Lambda<Action<MyProtectedLike>>(body, likeParameter);
    //    }
    //    return new NonIndexerFluentGetSet<MyProtected, MyProtectedLike, int>(protectedMock, GetSetUpOrVerifyExpression, like => like.GetSet);

    //}

    public static INonIndexerFluentGet<MyProtected, int> GetOnly(this ProtectedMock<MyProtected> protectedMock)
    {
        return new NonIndexerFluentGetSet<MyProtected, MyProtectedLike, int>(protectedMock, null, like => like.GetOnly);
    }

    public static INonIndexerFluentSet<MyProtected, int> SetOnly(this ProtectedMock<MyProtected> protectedMock)
    {
        Expression<Action<MyProtectedLike>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches,int propertyValue)
        {
            //var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            //var setupExpression = new SetupExpressionArgument(matches);

            //var expressionArg0 = setupExpression.Create((T)t, parameterInfos[0]);
            //var expressionArgs = new Expression[]{
            //    expressionArg0
            //};

            //var call = Expression.Call(likeParameter, "GenericNoConstraints", new Type[] { typeof(T) }, expressionArgs);
            //return Expression.Lambda<Func<MyProtectedLike, string>>(call, likeParameter);
            return null;
        }
        Expression<Func<MyProtectedLike, int>> setupProperty = like => like.GetOnly;
        return new NonIndexerFluentGetSet<MyProtected, MyProtectedLike, int>(protectedMock, GetSetUpOrVerifyExpression, null);

    }

    //there is no SetupProperty when not get;set !
}
