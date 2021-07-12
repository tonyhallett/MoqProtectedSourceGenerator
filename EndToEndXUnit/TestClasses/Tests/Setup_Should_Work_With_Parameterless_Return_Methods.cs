using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Parameterless_Return_Methods : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int MethodWithReturn();
    public int InvokeMethodWithReturn(){
        return MethodWithReturn();    
    }
",
            @"
    mock.MethodWithReturn().Build().Setup().Returns(123);
    Assert.AreEqual(123,mocked.InvokeMethodWithReturn());
");

        public Setup_Should_Work_With_Parameterless_Return_Methods(ITestOutputHelper testOutputHelper)
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
