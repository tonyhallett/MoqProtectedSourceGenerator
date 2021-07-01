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

    public interface IIndexerFluentSet<TMock, {typeArgs}, TProperty> where TMock : class
    {{
        IVoidBuilder<TMock,Action<{typeArgs},TProperty>> Set({getSetParameters}, TProperty value);
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
    
");
                    });
                }
            });
        }
    }
}
