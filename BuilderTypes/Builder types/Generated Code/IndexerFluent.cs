using System;
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoqProtectedGenerated{
    #region Indexer fluent
    #region 1 arg

    public interface IIndexerFluentGet<TMock,TKey1,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1>,Func<TKey1,TProperty>> Get(TKey1 key1);
    }

    public interface IIndexerFluentSet<TMock, TKey1, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TProperty>> Set(TKey1 key1, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TProperty> : 
        IIndexerFluentGet<TMock, TKey1, TProperty>, 
        IIndexerFluentSet<TMock, TKey1, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1, TProperty> : IIndexerFluentGetSet<TMock, TKey1, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1>,Func<TKey1,TProperty>> Get(TKey1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1>,Func<TKey1,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1>,Func<TKey1,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TProperty>> Set(TKey1 key1, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 2 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2>,Func<TKey1,TKey2,TProperty>> Get(TKey1 key1,TKey2 key2);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TProperty>> Set(TKey1 key1,TKey2 key2, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2>,Func<TKey1,TKey2,TProperty>> Get(TKey1 key1,TKey2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2>,Func<TKey1,TKey2,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2>,Func<TKey1,TKey2,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TProperty>> Set(TKey1 key1,TKey2 key2, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #endregion

}
