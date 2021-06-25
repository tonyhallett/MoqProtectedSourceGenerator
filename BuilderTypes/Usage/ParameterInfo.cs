using System.Linq.Expressions;
using Moq;
using System.Collections.Generic;
using MoqProtectedTyped;
using System.Reflection;
using System;

namespace MoqProtectedGenerated
{
    public enum ParameterType { UseValue, Match, Out, RefAny }

    public class ParameterInfo
    {
        public ParameterType Type { get; set; }
        public Expression RefAny { get; set; }
    }

    public static class Matcher
    {
        private static readonly MethodInfo matchesMethod;
        private static readonly MethodInfo wrapMethod;

        static Matcher()
        {
            var iMatcherType = typeof(Match).Assembly.GetType("Moq.IMatcher");
            matchesMethod = iMatcherType.GetMethod("Matches");
            wrapMethod = typeof(Matcher).GetMethod("Wrap", BindingFlags.Public | BindingFlags.Static);
        }

        private static bool Matches(this Match match, object toMatchAgainst, Type parameterType)
        {
            return (bool)matchesMethod.Invoke(match, new object[] { toMatchAgainst, parameterType });
        }

        public static T Wrap<T>(this Match match)
        {
            //using this overload permits type matchers
            return Match.Create<T>((v, t) => {
                var matches = match.Matches(v, t);
                return matches;
            }, () => default(T));
        }

        public static MethodInfo GetWrapMethod<T>()
        {
            return wrapMethod.MakeGenericMethod(typeof(T));
        }
    }

    public class SetupExpressionArgument
    {
        private int matchCount = 0;
        private readonly List<Match> matches;

        public SetupExpressionArgument(List<Match> matches)
        {
            this.matches = matches;
        }

        public Expression Create<TArg>(TArg t, ParameterInfo parameterInfo)
        {
            Expression expression = null;
            switch (parameterInfo.Type)
            {
                case ParameterType.UseValue:
                case ParameterType.Out:
                    expression = Expression.Constant(t);
                    if (t == null)
                    {
                        expression = Expression.Convert(expression, typeof(TArg));
                    }
                    break;
                case ParameterType.Match:
                    expression = Expression.Call(Matcher.GetWrapMethod<TArg>(), Expression.Constant(this.matches[matchCount]));
                    matchCount++;
                    break;
            }

            return expression;
        }
    }

}
