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
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
";

        private static string GetTypes(int numTypeArguments)
        {
            var stringBuilder = new StringBuilder();
            AddIndexerFluent(numTypeArguments, stringBuilder);
            return stringBuilder.ToString();
        }

        private static void AddRegion(string regionName,StringBuilder stringBuilder,Action addCode)
        {
            stringBuilder.AppendLine($"    #region {regionName}");
            addCode();
            stringBuilder.AppendLine("    #endregion");
        }
        
        private static string GetTypeArg(int position)
        {
            return $"TKey{position}";
        }

        private static string GetParameterName(int position)
        {
            return $"key{position}";
        }

        private static void AddIndexerFluent(int numTypeArguments, StringBuilder stringBuilder)
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
                var typeArg = GetTypeArg(i);
                typeArgs += typeArg;
                var parameterName = GetParameterName(i);
                getSetParameters += $"{typeArg} {parameterName}";
                getSetArguments += parameterName;

                AddRegion(i == 1 ? "1 arg" : $"{i} args", stringBuilder, () =>
                {
                        
                    stringBuilder.Append($@"
    public interface IIndexerFluentGet<TMock,{typeArgs},TProperty> where TMock : class
    {{
        IReturningBuilder<TMock,TProperty,Action<{typeArgs}>,Func<{typeArgs},TProperty>> Get({getSetParameters});
    }}

    public interface IIndexerFluentGetTask<TMock,{typeArgs}> where TMock : class
    {{
        IReturningBuilderTask<TMock,Action<{typeArgs}>,Func<{typeArgs},Task>> Get({getSetParameters});
    }}

    public interface IIndexerFluentGetValueTask<TMock,{typeArgs}> where TMock : class
    {{
        IReturningBuilderValueTask<TMock,Action<{typeArgs}>,Func<{typeArgs},ValueTask>> Get({getSetParameters});
    }}

    public interface IIndexerFluentGetTaskResult<TMock,{typeArgs},TTaskResult> where TMock : class
    {{
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<{typeArgs}>,Func<{typeArgs},Task<TTaskResult>>,Func<{typeArgs},TTaskResult>> Get({getSetParameters});
    }}

    public interface IIndexerFluentGetValueTaskResult<TMock,{typeArgs},TValueTaskResult> where TMock : class
    {{
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<{typeArgs}>,Func<{typeArgs},ValueTask<TValueTaskResult>>,Func<{typeArgs},TValueTaskResult>> Get({getSetParameters});
    }}

    public interface IIndexerFluentSet<TMock, {typeArgs}, TProperty> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},TProperty>> Set({getSetParameters}, TProperty value);
    }}

    public interface IIndexerFluentSetTask<TMock, {typeArgs}> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},Task>> Set({getSetParameters}, Task value);
    }}

    public interface IIndexerFluentSetValueTask<TMock, {typeArgs}> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},ValueTask>> Set({getSetParameters}, ValueTask value);
    }}
    
    public interface IIndexerFluentSetTaskResult<TMock, {typeArgs},TTaskResult> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},Task<TTaskResult>>> Set({getSetParameters}, Task<TTaskResult> value);
    }}

    public interface IIndexerFluentSetValueTaskResult<TMock, {typeArgs},TValueTaskResult> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},ValueTask<TValueTaskResult>>> Set({getSetParameters}, ValueTask<TValueTaskResult> value);
    }}

    public interface IIndexerFluentGetSet<TMock,{typeArgs},TProperty> : 
        IIndexerFluentGet<TMock, {typeArgs}, TProperty>, 
        IIndexerFluentSet<TMock, {typeArgs}, TProperty> where TMock : class {{}}

    public interface IIndexerFluentGetSetTask<TMock,{typeArgs}> : 
        IIndexerFluentGetTask<TMock, {typeArgs}>, 
        IIndexerFluentSetTask<TMock, {typeArgs}> where TMock : class {{}}

    public interface IIndexerFluentGetSetValueTask<TMock,{typeArgs}> : 
        IIndexerFluentGetValueTask<TMock, {typeArgs}>, 
        IIndexerFluentSetValueTask<TMock, {typeArgs}> where TMock : class {{}}

    public interface IIndexerFluentGetSetTaskResult<TMock,{typeArgs},TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,{typeArgs},TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, {typeArgs},TTaskResult>
        where TMock : class {{}}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,{typeArgs},TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,{typeArgs},TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, {typeArgs},TValueTaskResult>
        where TMock : class {{}}
    
    

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

        public IReturningBuilder<TMock,TProperty, Action<{typeArgs}>,Func<{typeArgs},TProperty>> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<{typeArgs}>,Func<{typeArgs},TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<{typeArgs}>,Func<{typeArgs},TProperty>>(
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

        public IVoidBuilder<TMock, Action<{typeArgs},TProperty>> Set({getSetParameters}, TProperty value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<{typeArgs},TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<{typeArgs},TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }}

    public class IndexerFluentGetSetTask<TMock, TLike, {typeArgs}> : IIndexerFluentGetSetTask<TMock, {typeArgs}>
        where TMock : class
        where TLike : class
    {{
        private readonly Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, {typeArgs}, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, {typeArgs}, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {{
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }}

        public IReturningBuilderTask<TMock, Action<{typeArgs}>,Func<{typeArgs},Task>> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<{typeArgs}>,Func<{typeArgs},Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<{typeArgs}>,Func<{typeArgs},Task>>(
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

        public IVoidBuilder<TMock, Action<{typeArgs},Task>> Set({getSetParameters}, Task value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<{typeArgs},Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<{typeArgs},Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }}

    public class IndexerFluentGetSetValueTask<TMock, TLike, {typeArgs}> : IIndexerFluentGetSetValueTask<TMock, {typeArgs}>
        where TMock : class
        where TLike : class
    {{
        private readonly Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, {typeArgs}, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, {typeArgs}, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {{
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }}

        public IReturningBuilderValueTask<TMock, Action<{typeArgs}>,Func<{typeArgs},ValueTask>> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<{typeArgs}>,Func<{typeArgs},ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<{typeArgs}>,Func<{typeArgs},ValueTask>>(
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

        public IVoidBuilder<TMock, Action<{typeArgs},ValueTask>> Set({getSetParameters}, ValueTask value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<{typeArgs},ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<{typeArgs},ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }}

    public class IndexerFluentGetSetTaskResult<TMock, TLike, {typeArgs}, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, {typeArgs}, TTaskResult>
        where TMock : class
        where TLike : class
    {{
        private readonly Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, {typeArgs}, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, {typeArgs}, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {{
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }}

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<{typeArgs}>,Func<{typeArgs},Task<TTaskResult>>, Func<{typeArgs},TTaskResult>> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<{typeArgs}>,Func<{typeArgs},Task<TTaskResult>>, Func<{typeArgs},TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<{typeArgs}>,Func<{typeArgs},Task<TTaskResult>>,  Func<{typeArgs},TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<{typeArgs},Task<TTaskResult>>> Set({getSetParameters}, Task<TTaskResult> value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<{typeArgs},Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<{typeArgs},Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }}   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, {typeArgs}, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, {typeArgs}, TValueTaskResult>
        where TMock : class
        where TLike : class
    {{
        private readonly Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, {typeArgs}, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, {typeArgs}, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, {typeArgs}, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {{
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }}

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<{typeArgs}>,Func<{typeArgs},ValueTask<TValueTaskResult>>, Func<{typeArgs},TValueTaskResult>> Get({getSetParameters})
        {{
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<{typeArgs}>,Func<{typeArgs},ValueTask<TValueTaskResult>>, Func<{typeArgs},TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<{typeArgs}>,Func<{typeArgs},ValueTask<TValueTaskResult>>,  Func<{typeArgs},TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<{typeArgs},ValueTask<TValueTaskResult>>> Set({getSetParameters}, ValueTask<TValueTaskResult> value)
        {{
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<{typeArgs},ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<{typeArgs},ValueTask<TValueTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, {getSetArguments}, value), times, failMessage)
             );
        }}

    }} 
    
");
                    });
            }
            
        }
    }
}
