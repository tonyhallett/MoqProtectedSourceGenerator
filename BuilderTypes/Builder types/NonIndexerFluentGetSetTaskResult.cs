using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public class NonIndexerFluentGetSetTaskResult<TMock, TLike,TTaskResult> : INonIndexerFluentGetSetTaskResult<TMock,TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly Expression<Func<TLike, Task<TTaskResult>>> getter;
        private readonly ProtectedMock<TMock> protectedMock;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public NonIndexerFluentGetSetTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, Task<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
            Expression<Func<TLike, Task<TTaskResult>>> getter
            )
        {
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
            this.getter = getter;
            this.protectedMock = protectedMock;
            protectedLike = protectedMock.Mock.Protected().As<TLike>();

        }

        public IReturningBuilderTaskResult<TMock, TTaskResult,Action, Func<Task<TTaskResult>>, Func<TTaskResult>> Get()
        {
            return new ReturningBuilderTaskResult<TMock, TTaskResult,Action, Func<Task<TTaskResult>>,Func<TTaskResult>>(
                (_, __) => new SetupTypedResultTaskResult<TMock, TTaskResult,Action, Func<Task<TTaskResult>>, Func<TTaskResult>>(protectedLike.Setup(getter)),
                (_, __) => protectedLike.SetupSequence(getter),
                (_, __, times, failMessage) =>
                {
                    Times t = Times.AtLeastOnce();
                    if (times.HasValue)
                    {
                        t = times.Value;
                    }
                    protectedLike.VerifyGet(getter, t, failMessage);
                });
        }

        public ISetterBuilder<TMock, Task<TTaskResult>> Set(Task<TTaskResult> property)
        {
            var matches = MatcherObserver.GetMatches();
            return new SetterBuilder<TMock, Task<TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTyped<TMock, Action<Task<TTaskResult>>>(
                        protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property))
                    ),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property), times, failMessage)
            );
        }

        public ProtectedMock<TMock> SetupProperty(Task<TTaskResult> initialValue = default)
        {
            protectedLike.SetupProperty(getter, initialValue);
            return protectedMock;
        }
    }

}