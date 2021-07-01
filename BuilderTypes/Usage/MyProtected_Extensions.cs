using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ANamespace;
using MoqProtectedTyped;
using System.Reflection;

public static class MyProtected_Extensions
{
    private static readonly Dictionary<string, List<MoqProtectedGenerated.ParameterInfo>> Setups =
        new Dictionary<string, List<MoqProtectedGenerated.ParameterInfo>> {
            { @"C:\Users\tonyh\Source\Repos\MoqProtectedSourceGenerator\BuilderTypes\Usage\Test.cs_12",
                new List<MoqProtectedGenerated.ParameterInfo>{
                    new MoqProtectedGenerated.ParameterInfo { Type = ParameterType.UseValue, RefAny = null },
                    new MoqProtectedGenerated.ParameterInfo { Type = ParameterType.UseValue, RefAny = null }
            } },
            { @"C:\Users\tonyh\Source\Repos\MoqProtectedSourceGenerator\BuilderTypes\Usage\Test.cs_13",
                new List<MoqProtectedGenerated.ParameterInfo>{
                    new MoqProtectedGenerated.ParameterInfo { Type = ParameterType.UseValue, RefAny = null },
                    new MoqProtectedGenerated.ParameterInfo { Type = ParameterType.UseValue, RefAny = null }
            } },
            { @"C:\Users\tonyh\Source\Repos\MoqProtectedSourceGenerator\BuilderTypes\Usage\Test.cs_21",
                new List<MoqProtectedGenerated.ParameterInfo>{
                    new MoqProtectedGenerated.ParameterInfo { Type = ParameterType.UseValue, RefAny = null }
            } }

        };

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {
        return sourceFileInfo + "_" + sourceLineNumber;
    }

    public static INonIndexerFluentGetSet<MyProtected,int> GetSet(this ProtectedMock<MyProtected> protectedMock)
    {
        var likeParameter = Expression.Parameter(typeof(MyProtectedLike));

        Expression<Action<MyProtectedLike>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber,List<Match> matches,int propertyValue)
        {
            PropertyInfo property = typeof(MyProtectedLike).GetProperty("GetSet");
            MethodInfo setMethod = property.GetSetMethod();

            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

            var expressionArg0 = setupExpression.Create((int)propertyValue, parameterInfos[0]);
            
            var body = Expression.Call(likeParameter, setMethod, expressionArg0);
            return Expression.Lambda<Action<MyProtectedLike>>(body, likeParameter);
        }
        return new NonIndexerFluentGetSet<MyProtected, MyProtectedLike, int>(protectedMock, GetSetUpOrVerifyExpression, like => like.GetSet);
    }

    public static IIndexerFluentGetSet<MyProtected, int, string, string> Index(this ProtectedMock<MyProtected> protectedMock)
    {
        var likeParameter = Expression.Parameter(typeof(MyProtectedLike));

        PropertyInfo indexerProperty = typeof(MyProtectedLike).GetProperty("Item", typeof(string), new Type[] { typeof(int), typeof(string) });
        MethodInfo indexerGet = indexerProperty.GetGetMethod();
        MethodInfo indexerSet = indexerProperty.GetSetMethod();

        Expression<T> GetSetterSetUpOrVerifyExpressionBase<T>(string sourceFileInfo, int sourceLineNumber, List<Match> matches, int key1, string key2, Expression valueExpression)
        {
            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

            var expressionArg0 = setupExpression.Create((int)key1, parameterInfos[0]);
            var expressionArg1 = setupExpression.Create((string)key2, parameterInfos[1]);
            var expressions = new List<Expression>{ expressionArg0, expressionArg1 };
            MethodInfo indexerGetOrSet = indexerGet;
            if(valueExpression != null)
            {
                indexerGetOrSet = indexerSet;
                expressions.Add(valueExpression);
            }
            
            var body = Expression.Call(likeParameter, indexerGetOrSet, expressions);
            return Expression.Lambda<T>(body, likeParameter);
        }

        Expression<Action<MyProtectedLike>> GetSetterSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches,int key1,string key2, string value)
        {
            return GetSetterSetUpOrVerifyExpressionBase<Action<MyProtectedLike>>(sourceFileInfo, sourceLineNumber, matches, key1, key2, Expression.Constant(value));
        }

        Expression<Func<MyProtectedLike,string>> GetGetterSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches, int key1, string key2)
        {
            return GetSetterSetUpOrVerifyExpressionBase<Func<MyProtectedLike, string>>(sourceFileInfo, sourceLineNumber, matches, key1, key2, null);
        }

        return new IndexerFluentGetSet<MyProtected,MyProtectedLike, int, string, string>(protectedMock,GetGetterSetUpOrVerifyExpression,GetSetterSetUpOrVerifyExpression);
    }

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

}
