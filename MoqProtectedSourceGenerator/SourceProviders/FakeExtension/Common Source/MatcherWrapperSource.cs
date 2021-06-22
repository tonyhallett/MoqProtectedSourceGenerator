using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionSource))]
    [Export(typeof(IExecuteAware))]
    public class MatcherWrapperSource : CommonSingleSource, IProtectedLikeExtensionSource
    {
        protected override string HintName => "MatcherWrapper";
        protected override List<string> Usings => new()
        {
            "using System;",
            "using System.Reflection;",
            "using Moq;"
        };
        protected override string Source =>
@"    public static class Matcher
    {
        private static readonly MethodInfo matchesMethod;
        private static readonly MethodInfo wrapMethod;
        
        static Matcher()
        {
            var iMatcherType = typeof(Match).Assembly.GetType(""Moq.IMatcher"");
            matchesMethod = iMatcherType.GetMethod(""Matches"");
            wrapMethod = typeof(Matcher).GetMethod(""Wrap"", BindingFlags.Public | BindingFlags.Static);
        }

        private static bool Matches(this Match match, object toMatchAgainst, Type parameterType)
        {
            return (bool)matchesMethod.Invoke(match, new object[] { toMatchAgainst, parameterType });
        }

        public static T Wrap<T>(this Match match)
        {
            //using this overload permits type matchers
            return Match.Create<T>((v,t) => {
                var matches = match.Matches(v, t);
                return matches;
            },()=>default(T));
        }

        public static MethodInfo GetWrapMethod<T>()
        {
            return wrapMethod.MakeGenericMethod(typeof(T));
        }
    }
";
    }
}
