using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoqProtectedTyped;
using Moq.Language.Flow;

public class NonIndexerFluentGetSet<T,TLike, TProperty> : INonIndexerFluentGetSet<T, TProperty> 
    where T : class
    where TLike : class
{
    private readonly Func<string, int, List<Match>,TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression;
    private readonly Expression<Func<TLike, TProperty>> getter;
    private readonly IProtectedAsMock<T, TLike> protectedLike;

    public NonIndexerFluentGetSet(
        ProtectedMock<T> protectedMock, 
        Func<string,int, List<Match>,TProperty, Expression<Action<TLike>>> setterGetSetUpOrVerifyExpression,
        Expression<Func<TLike, TProperty>> getter
        )
    {
        this.setterGetSetUpOrVerifyExpression = setterGetSetUpOrVerifyExpression;
        this.getter = getter;
        protectedLike = protectedMock.Mock.Protected().As<TLike>();

    }

    public IGetterBuilder<T, TProperty> Get()
    {
        //should be able to create the getter by property name -  Expression<Func<TLike, TProperty>>
        
        return new GetterBuilder<T, TProperty>(
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

    public ISetterBuilder<T, TProperty> Set(TProperty property)
    {
        //SetupSet does not exist - will use SetUp ( this would not work with indexer )
        var matches = MatcherObserver.GetMatches();
        return new SetterBuilder<T, TProperty>(
            (sourceFileInfo, sourceLineNumber) => protectedLike.Setup(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)) as ISetupSetter<T,TProperty>,
            (sourceFileInfo, sourceLineNumber) => protectedLike.SetupSequence(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property)),
            (sourceFileInfo, sourceLineNumber, times,failMessage) => protectedLike.Verify(setterGetSetUpOrVerifyExpression(sourceFileInfo, sourceLineNumber, matches, property),times,failMessage)
        );
    }

    public void SetupProperty(TProperty initialValue = default)
    {
        protectedLike.SetupProperty(getter,initialValue);
        // determine the return 
    }
}
