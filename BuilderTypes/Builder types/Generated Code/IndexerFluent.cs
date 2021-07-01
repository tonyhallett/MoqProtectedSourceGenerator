using System;
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoqProtectedGenerated{
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
    #region 3 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 4 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 5 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 6 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 7 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 8 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 9 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 10 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 11 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value), times, failMessage)
             );
        }

    }
    
    #endregion
    #region 12 args

    public interface IIndexerFluentGet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, TProperty value);
    }
    
    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty> where TMock : class {}

    public class IndexerFluentGetSet<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty> : IIndexerFluentGetSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, TProperty>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilder<TMock,TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilder<TMock, TProperty, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResult<TMock,TProperty,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>>(
                        protectedLike.Setup(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12))
                    )
                ,
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12), t, failMessage);
                });
        }

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, TProperty value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value), times, failMessage)
             );
        }

    }
    
    #endregion

}
