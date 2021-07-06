using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public class NonIndexerFluentGetSetTask<TMock, TLike> : INonIndexerFluentGetSetTask<TMock>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly Expression<Func<TLike, Task>> getter;
        private readonly ProtectedMock<TMock> protectedMock;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public NonIndexerFluentGetSetTask(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, Task, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
            Expression<Func<TLike, Task>> getter
            )
        {
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
            this.getter = getter;
            this.protectedMock = protectedMock;
            protectedLike = protectedMock.Mock.Protected().As<TLike>();

        }

        public IReturningBuilderTask<TMock, Action, Func<Task>> Get()
        {
            return new ReturningBuilderTask<TMock, Action, Func<Task>>(
                (_, __) => new SetupTypedResultTask<TMock, Action, Func<Task>>(protectedLike.Setup(getter)),
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

        public ISetterBuilder<TMock, Task> Set(Task property)
        {
            var matches = MatcherObserver.GetMatches();
            return new SetterBuilder<TMock, Task>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTyped<TMock, Action<Task>>(
                        protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property))
                    ),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property), times, failMessage)
            );
        }

        public ProtectedMock<TMock> SetupProperty(Task initialValue = default)
        {
            protectedLike.SetupProperty(getter, initialValue);
            return protectedMock;
        }
    }

}