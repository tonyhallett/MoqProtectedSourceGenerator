using System;
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoqProtectedGenerated{
    #region 1 arg

    public interface IIndexerFluentGet<TMock,TKey1,TProperty> where TMock : class
    {
        IReturningBuilder<TMock,TProperty,Action<TKey1>,Func<TKey1,TProperty>> Get(TKey1 key1);
    }

    public interface IIndexerFluentGetTask<TMock,TKey1> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1>,Func<TKey1,Task>> Get(TKey1 key1);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1>,Func<TKey1,ValueTask>> Get(TKey1 key1);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1>,Func<TKey1,Task<TTaskResult>>,Func<TKey1,TTaskResult>> Get(TKey1 key1);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1>,Func<TKey1,ValueTask<TValueTaskResult>>,Func<TKey1,TValueTaskResult>> Get(TKey1 key1);
    }

    public interface IIndexerFluentSet<TMock, TKey1, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TProperty>> Set(TKey1 key1, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,Task>> Set(TKey1 key1, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,ValueTask>> Set(TKey1 key1, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,Task<TTaskResult>>> Set(TKey1 key1, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,ValueTask<TValueTaskResult>>> Set(TKey1 key1, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TProperty> : 
        IIndexerFluentGet<TMock, TKey1, TProperty>, 
        IIndexerFluentSet<TMock, TKey1, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1> : 
        IIndexerFluentGetTask<TMock, TKey1>, 
        IIndexerFluentSetTask<TMock, TKey1> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1> : 
        IIndexerFluentGetValueTask<TMock, TKey1>, 
        IIndexerFluentSetValueTask<TMock, TKey1> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1> : IIndexerFluentGetSetTask<TMock, TKey1>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1>,Func<TKey1,Task>> Get(TKey1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1>,Func<TKey1,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1>,Func<TKey1,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,Task>> Set(TKey1 key1, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1> : IIndexerFluentGetSetValueTask<TMock, TKey1>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1>,Func<TKey1,ValueTask>> Get(TKey1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1>,Func<TKey1,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1>,Func<TKey1,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,ValueTask>> Set(TKey1 key1, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1>,Func<TKey1,Task<TTaskResult>>, Func<TKey1,TTaskResult>> Get(TKey1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1>,Func<TKey1,Task<TTaskResult>>, Func<TKey1,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1>,Func<TKey1,Task<TTaskResult>>,  Func<TKey1,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,Task<TTaskResult>>> Set(TKey1 key1, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1>,Func<TKey1,ValueTask<TValueTaskResult>>, Func<TKey1,TValueTaskResult>> Get(TKey1 key1)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1>,Func<TKey1,ValueTask<TValueTaskResult>>, Func<TKey1,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1>,Func<TKey1,ValueTask<TValueTaskResult>>,  Func<TKey1,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,ValueTask<TValueTaskResult>>> Set(TKey1 key1, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2>,Func<TKey1,TKey2,Task>> Get(TKey1 key1,TKey2 key2);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask>> Get(TKey1 key1,TKey2 key2);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2>,Func<TKey1,TKey2,Task<TTaskResult>>,Func<TKey1,TKey2,TTaskResult>> Get(TKey1 key1,TKey2 key2);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TValueTaskResult>> Get(TKey1 key1,TKey2 key2);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TProperty>> Set(TKey1 key1,TKey2 key2, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,Task>> Set(TKey1 key1,TKey2 key2, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,ValueTask>> Set(TKey1 key1,TKey2 key2, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2>,Func<TKey1,TKey2,Task>> Get(TKey1 key1,TKey2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2>,Func<TKey1,TKey2,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2>,Func<TKey1,TKey2,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,Task>> Set(TKey1 key1,TKey2 key2, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask>> Get(TKey1 key1,TKey2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,ValueTask>> Set(TKey1 key1,TKey2 key2, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,Task<TTaskResult>>, Func<TKey1,TKey2,TTaskResult>> Get(TKey1 key1,TKey2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,Task<TTaskResult>>, Func<TKey1,TKey2,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,Task<TTaskResult>>,  Func<TKey1,TKey2,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TValueTaskResult>> Get(TKey1 key1,TKey2 key2)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2>,Func<TKey1,TKey2,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3>,Func<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4>,Func<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,ValueTask<TValueTaskResult>>>(
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

    public interface IIndexerFluentGetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class
    {
        IReturningBuilderTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12);
    }

    public interface IIndexerFluentGetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class
    {
        IReturningBuilderValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12);
    }

    public interface IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult> where TMock : class
    {
        IReturningBuilderTaskResult<TMock,TTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12);
    }

    public interface IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult> where TMock : class
    {
        IReturningBuilderValueTaskResult<TMock,TValueTaskResult,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12);
    }

    public interface IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, TProperty value);
    }

    public interface IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, Task value);
    }

    public interface IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, ValueTask value);
    }
    
    public interface IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, Task<TTaskResult> value);
    }

    public interface IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult> where TMock : class
    {
        IVoidBuilder<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, ValueTask<TValueTaskResult> value);
    }

    public interface IIndexerFluentGetSet<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TProperty> : 
        IIndexerFluentGet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty>, 
        IIndexerFluentSet<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TProperty> where TMock : class {}

    public interface IIndexerFluentGetSetTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> : 
        IIndexerFluentGetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>, 
        IIndexerFluentSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class {}

    public interface IIndexerFluentGetSetValueTask<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> : 
        IIndexerFluentGetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>, 
        IIndexerFluentSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> where TMock : class {}

    public interface IIndexerFluentGetSetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult> :
        IIndexerFluentGetTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>,
        IIndexerFluentSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>
        where TMock : class {}

    public interface IIndexerFluentGetSetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult> :
        IIndexerFluentGetValueTaskResult<TMock,TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>,
        IIndexerFluentSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>
        where TMock : class {}
    
    

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

    public class IndexerFluentGetSetTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> : IIndexerFluentGetSetTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, Task>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, Task value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetValueTask<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12> : IIndexerFluentGetSetValueTask<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, ValueTask>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTask<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTask<TMock,Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, ValueTask value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value), times, failMessage)
             );
        }

    }

    public class IndexerFluentGetSetTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TTaskResult> : IIndexerFluentGetSetTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, Task<TTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultTaskResult<TMock,TTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, Task<TTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,Task<TTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value), times, failMessage)
             );
        }

    }   

    public class IndexerFluentGetSetValueTaskResult<TMock, TLike, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TValueTaskResult> : IIndexerFluentGetSetValueTaskResult<TMock, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, TValueTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression;
        private readonly Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public IndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, Expression<Func<TLike, ValueTask<TValueTaskResult>>>> getterGetSetUpOrVerifyExpression,
            Func<string, int, List<Match>, TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12, ValueTask<TValueTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression
        )
        {
            protectedLike = protectedMock.Mock.Protected().As<TLike>();
            this.getterGetSetUpOrVerifyExpression = getterGetSetUpOrVerifyExpression;
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        }

        public IReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>> Get(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12)
        {
            var matches = MatcherObserver.GetMatches();

            return new ReturningBuilderValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>, Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTypedResultValueTaskResult<TMock,TValueTaskResult, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12>,Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>,  Func<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,TValueTaskResult>>(
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

        public IVoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>> Set(TKey1 key1,TKey2 key2,TKey3 key3,TKey4 key4,TKey5 key5,TKey6 key6,TKey7 key7,TKey8 key8,TKey9 key9,TKey10 key10,TKey11 key11,TKey12 key12, ValueTask<TValueTaskResult> value)
        {
            var matches = MatcherObserver.GetMatches();

            return new VoidBuilder<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>>(
                (sourceFileInfo, sourceLineNumber) => new SetupTyped<TMock, Action<TKey1,TKey2,TKey3,TKey4,TKey5,TKey6,TKey7,TKey8,TKey9,TKey10,TKey11,TKey12,ValueTask<TValueTaskResult>>>(
                    protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value))),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, key1,key2,key3,key4,key5,key6,key7,key8,key9,key10,key11,key12, value), times, failMessage)
             );
        }

    } 
    
    #endregion

}
