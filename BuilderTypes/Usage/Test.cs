using System;
using Moq;
using MoqProtectedTyped;

namespace ANamespace
{
    public class Test
    {
        public void Generate()
        {
            var mock = new ProtectedMock<MyProtected>();
            mock.AbstractMethod().Build().Setup();
            mock.GetSet().Get().Build().Setup().Returns(9);
            mock.GetSet().Set(It.IsAny<int>()).Build().Setup().Throws(new Exception());
        }

    }
}
