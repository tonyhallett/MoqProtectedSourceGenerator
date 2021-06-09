using Xunit;

namespace EndToEndTests
{
    public class MoqProtectedSourceGeneratorTest_HasSource : MoqProtectedSourceGeneratorTestBase
    {
        protected override string Source => @"
using System;
using Moq;
using NUnit.Framework;

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

    public class Test
    {
        [Test]
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
        }
}
}
";

        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
