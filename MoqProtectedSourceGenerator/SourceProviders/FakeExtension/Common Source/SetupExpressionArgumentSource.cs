﻿using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(ISetupExpressionArgument))]
    [Export(typeof(IExecuteAware))]
    [Export(typeof(IProtectedLikeExtensionSource))]
    public class SetupExpressionArgumentSource : CommonSingleSource, ISetupExpressionArgument, IProtectedLikeExtensionSource
    {
        public static readonly string className = "SetupExpressionArgument";
        public static readonly string methodName = "Create";
        public string ClassName { get { return className; } }
        public string MethodName { get { return methodName; } }
        protected override string HintName => "SetupExpressionArgument";
        protected override List<string> Usings => new()
        {
            "using Moq;",
            "using System.Linq.Expressions;",
            "using System.Collections.Generic;"
        };
        protected override string Source =>
@$"    public class {className}
    {{
        private int matchCount = 0;
        private readonly List<Match> matches;

        public SetupExpressionArgument(List<Match> matches){{
            this.matches = matches;
        }}

        public Expression {methodName}<TArg>(TArg t, ArgumentInfo argumentInfo)
        {{
            Expression expression = null;
            switch (argumentInfo.Type)
            {{
                case ArgumentType.UseValue:
                case ArgumentType.Out:
                    expression = Expression.Constant(t);
                    if (t == null)
                    {{
                        expression = Expression.Convert(expression, typeof(TArg));
                    }}
                    break;
                case ArgumentType.Match:
                    expression = Expression.Call(Matcher.GetWrapMethod<TArg>(), Expression.Constant(this.matches[matchCount]));
                    matchCount++;
                    break;
            }}
         
            return expression;
        }}
    }}
";

    }
}
