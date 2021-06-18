using System;
using System.Linq.Expressions;
using Moq;

namespace MoqProtectedTyped
{
    public class ProtectedMock<T> where T : class
    {
        public Mock<T> Mock { get; private set; }
        public ProtectedMock()
        {
            Mock = new Mock<T>();
            MatcherObserver.EnsureInstance();
        }
        public ProtectedMock(MockBehavior behavior)
        {
            Mock = new Mock<T>(behavior);
            MatcherObserver.EnsureInstance();
        }
        public ProtectedMock(MockBehavior behavior, params object[] args)
        {
            Mock = new Mock<T>(behavior, args);
            MatcherObserver.EnsureInstance();
        }
        public ProtectedMock(Expression<Func<T>> newExpression, MockBehavior behavior = MockBehavior.Loose)
        {
            Mock = new Mock<T>(newExpression, behavior);
            MatcherObserver.EnsureInstance();
        }
        public T Object => Mock.Object;
    }

}