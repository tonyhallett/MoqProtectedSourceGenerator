using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Generic_Methods : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract T GenericMethod<T>(T t);
    public T InvokeGenericMethod<T>(T t){
        return GenericMethod(t);    
    }
",
            @"
    mock.GenericMethod(1).Build().Setup().Returns(1);
    mock.GenericMethod(""1"").Build().Setup().Returns(""1"");
    Assert.AreEqual(1, mocked.InvokeGenericMethod(1));
    Assert.AreEqual(""1"", mocked.InvokeGenericMethod(""1""));
    
");

        public Setup_Should_Work_With_Generic_Methods(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        protected override void Log(string message)
        {
            testOutputHelper.WriteLine(message);
        }

        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
