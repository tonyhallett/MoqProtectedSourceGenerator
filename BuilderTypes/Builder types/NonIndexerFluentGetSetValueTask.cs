using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public class NonIndexerFluentGetSetValueTask<TMock, TLike> : INonIndexerFluentGetSetValueTask<TMock>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly Expression<Func<TLike, ValueTask>> getter;
        private readonly ProtectedMock<TMock> protectedMock;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public NonIndexerFluentGetSetValueTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, ValueTask, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
            Expression<Func<TLike, ValueTask>> getter
            )
        {
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
            this.getter = getter;
            this.protectedMock = protectedMock;
            protectedLike = protectedMock.Mock.Protected().As<TLike>();

        }

        public IReturningBuilderValueTask<TMock, Action, Func<ValueTask>> Get()
        {
            return new ReturningBuilderValueTask<TMock, Action, Func<ValueTask>>(
                (_, __) => new SetupTypedResultValueTask<TMock, Action, Func<ValueTask>>(protectedLike.Setup(getter)),
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

        public ISetterBuilder<TMock, ValueTask> Set(ValueTask property)
        {
            var matches = MatcherObserver.GetMatches();
            return new SetterBuilder<TMock, ValueTask>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTyped<TMock, Action<ValueTask>>(
                        protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property))
                    ),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property), times, failMessage)
            );
        }

        public ProtectedMock<TMock> SetupProperty(ValueTask initialValue = default)
        {
            protectedLike.SetupProperty(getter, initialValue);
            return protectedMock;
        }
    }

}