using System;
using Moq;

namespace ANamespace
{
    public class Test
    {
        public void Generate()
        {
            var mock = new Mock<MyProtected>();

            mock.AbstractMethodArgs(999).Build().Setup();
            
            mock.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify();

        }

    }
}
