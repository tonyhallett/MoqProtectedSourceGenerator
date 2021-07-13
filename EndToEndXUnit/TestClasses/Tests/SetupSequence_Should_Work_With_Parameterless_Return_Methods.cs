using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class SetupSequence_Should_Work_With_Parameterless_Return_Methods : MoqProtectedSourceGeneratorTestBase
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
    mock.MethodWithReturn().Build().SetupSequence().Returns(1).Returns(2).Throws(new ExpectedException());
    Assert.AreEqual(1,mocked.InvokeMethodWithReturn());
    Assert.AreEqual(2,mocked.InvokeMethodWithReturn());
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithReturn());
");

        public SetupSequence_Should_Work_With_Parameterless_Return_Methods(ITestOutputHelper testOutputHelper)
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
