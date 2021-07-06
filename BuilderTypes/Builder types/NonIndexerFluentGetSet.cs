﻿using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;

namespace MoqProtectedGenerated
{
    public class NonIndexerFluentGetSet<TMock, TLike, TProperty> : INonIndexerFluentGetSet<TMock, TProperty>
        where TMock : class
        where TLike : class
    {
        private readonly Func<string, int, List<Match>, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
        private readonly Expression<Func<TLike, TProperty>> getter;
        private readonly ProtectedMock<TMock> protectedMock;
        private readonly IProtectedAsMock<TMock, TLike> protectedLike;

        public NonIndexerFluentGetSet(
            ProtectedMock<TMock> protectedMock,
            Func<string, int, List<Match>, TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
            Expression<Func<TLike, TProperty>> getter
            )
        {
            this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
            this.getter = getter;
            this.protectedMock = protectedMock;
            protectedLike = protectedMock.Mock.Protected().As<TLike>();

        }

        public IGetterBuilder<TMock, TProperty> Get()
        {
            //should be able to create the getter by property name -  Expression<Func<TLike, TProperty>>

            return new GetterBuilder<TMock, TProperty>(
                (_, __) => protectedLike.SetupGet(getter),
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

        public ISetterBuilder<TMock, TProperty> Set(TProperty property)
        {
            var matches = MatcherObserver.GetMatches();
            return new SetterBuilder<TMock, TProperty>(
                (sourceFileInfo, sourceLineNumber) =>
                    new SetupTyped<TMock, Action<TProperty>>(
                        protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property))
                    ),
                (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property), times, failMessage)
            );
        }

        public ProtectedMock<TMock> SetupProperty(TProperty initialValue = default)
        {
            protectedLike.SetupProperty(getter, initialValue);
            return protectedMock;
        }
    }

}