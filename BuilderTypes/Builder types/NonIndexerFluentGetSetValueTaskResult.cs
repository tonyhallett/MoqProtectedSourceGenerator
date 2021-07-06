using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public class NonIndexerFluentGetSetValueTaskResult<TMock, TLike, TTaskResult> : INonIndexerFluentGetSetValueTaskResult<TMock, TTaskResult>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, ValueTask<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly Expression<Func<TLike, ValueTask<TTaskResult>>> getter;
        private readonly ProtectedMock<TMock> protectedMock;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public NonIndexerFluentGetSetValueTaskResult(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, ValueTask<TTaskResult>, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
            Expression<Func<TLike, ValueTask<TTaskResult>>> getter
            )
        {
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
            this.getter = getter;
            this.protectedMock = protectedMock;
            protectedLike = protectedMock.Mock.Protected().As<TLike>();

        }

        public IReturningBuilderValueTaskResult<TMock, TTaskResult, Action, Func<ValueTask<TTaskResult>>, Func<TTaskResult>> Get()
        {
            return new ReturningBuilderValueTaskResult<TMock, TTaskResult, Action, Func<ValueTask<TTaskResult>>, Func<TTaskResult>>(
                (_, __) => new SetupTypedResultValueTaskResult<TMock, TTaskResult, Action, Func<ValueTask<TTaskResult>>, Func<TTaskResult>>(protectedLike.Setup(getter)),
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

        public ISetterBuilder<TMock, ValueTask<TTaskResult>> Set(ValueTask<TTaskResult> property)
        {
            var matches = MatcherObserver.GetMatches();
            return new SetterBuilder<TMock, ValueTask<TTaskResult>>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTyped<TMock, Action<ValueTask<TTaskResult>>>(
                        protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property))
                    ),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property), times, failMessage)
            );
        }

        public ProtectedMock<TMock> SetupProperty(ValueTask<TTaskResult> initialValue = default)
        {
            protectedLike.SetupProperty(getter, initialValue);
            return protectedMock;
        }
    }

}