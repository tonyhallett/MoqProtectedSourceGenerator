using Xunit;

namespace EndToEndTests {

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

    public class MoqProtectedSourceGeneratorTest_Returns : MoqProtectedSourceGeneratorTestBase
    {
        protected override string Source => @"
using System;
using Moq;
using NUnit.Framework;

namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract string AbstractMethodArgsWithReturn(int value);
        public string InvokeAbstractMethodArgsWithReturn(int value)
        {
            return AbstractMethodArgsWithReturn(value);
        }
    }

    public class ExpectedException : Exception { }

    public class Test
    {
        [Test]
        public void Generate()
        {
            var mock = new Mock<MyProtected>();
            mock.AbstractMethodArgsWithReturn(0).Build().Setup().Returns(""Zero"");
            Assert.AreEqual(null,mock.Object.InvokeAbstractMethodArgsWithReturn(999));

            Assert.AreEqual(""Zero"",mock.Object.InvokeAbstractMethodArgsWithReturn(0));

            void Verify()
            {
                mock.AbstractMethodArgsWithReturn(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify();
            }

            mock.Object.InvokeAbstractMethodArgsWithReturn(999);
            Assert.Throws<MockException>(Verify);

            mock.Object.InvokeAbstractMethodArgsWithReturn(1);
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
