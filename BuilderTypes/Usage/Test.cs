using System;
using MoqProtectedTyped;

namespace ANamespace
{
    public class ExpectedException : Exception { }
    public static class TestBuilderTypes
    {
        public static void Execute()
        {
            var mock = new ProtectedMock<MyProtected>();
            mock.Index().Get(1, "1").Build().Setup().Returns("One");
            mock.Index().Set(2, "2", "Two").Build().Setup().Throws(new ExpectedException());
            
            AssertEquals("One",mock.Object.GetIndex(1, "1"));
            AssertException<ExpectedException>(() => mock.Object.SetIndex(2, "2", "Two"));
            
            //mock.AbstractMethod().Build().Setup();
            mock.GetSet().Get().Build().Setup().Returns(9);
            AssertEquals(9, mock.Object.GetGetSet());
            mock.GetSet().Set(1).Build().Setup().Throws(new ExpectedException());
            mock.Object.SetGetSet(123);
            AssertException<ExpectedException>(() => mock.Object.SetGetSet(1));
        }

        private static void AssertException<T>(Action action)
        {
            Exception exception = null;
            try
            {
                action();
            }
            catch (Exception exc)
            {
                exception = exc;
            }
            if (exception == null)
            {
                throw new Exception("Assertion failed");
            }
            else
            {
                if (exception.GetType() != typeof(T))
                {
                    throw new Exception("Assertion failed");
                }
            }
        }
        private static void AssertEquals<T>(T expected, T actual)
        {
            if (!object.Equals(expected, actual))
            {
                throw new Exception("Assertion failed");
            }
        }

    }
}
