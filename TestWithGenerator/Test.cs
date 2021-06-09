using System;
using IFace;
using Moq;
using NUnit.Framework;
using OtherNamespace;

namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void AbstractMethod();
        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }
        protected abstract int SomeProperty { get; }
    }

    public class ExpectedException : Exception { }
    public class Implementation : IInterface { }

    public class Test
    {
        public void Generate()
        {
            var mock = new Mock<MyProtected>();
            mock.AbstractMethod().Build().Setup().Throws(new ExpectedException());
            Assert.Throws<ExpectedException>(() => mock.Object.InvokeAbstractMethod());

            mock.AbstractMethodArgs(999).Build().Setup();
            mock.AbstractMethodArgs(123).Build().Setup();
            void Verify()
            {
                mock.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify();
            }

            mock.Object.InvokeAbstractMethodArgs(999);
            Assert.Throws<MockException>(Verify);

            mock.Object.InvokeAbstractMethodArgs(1);
            Verify();

            var mockDll = new Mock<ProtectedDll.DllProtected>();
            mockDll.ProtectedMethod(It.IsAny<Other>(), "match").Build().Setup().Throws(new ExpectedException());

            mockDll.Object.CallProtectedMethod(new Other(), "not a match");
            Assert.Throws<ExpectedException>(() => mockDll.Object.CallProtectedMethod(new Other(), "match"));

            mockDll.ProtectedGenericMethod(It.IsAny<Implementation>(), It.IsAny<Implementation>());


        }

    }
}
