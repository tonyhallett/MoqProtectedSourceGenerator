using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Arguments_That_Are_Not_Matchers : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(string s);
    public void InvokeMethodWithParameters(string s){
        MethodWithParameters(s);    
    }
",
            @"
    mock.MethodWithParameters(""throw"").Build().Setup().Throws(new ExpectedException());
    mocked.InvokeMethodWithParameters(""dont"");
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithParameters(""throw""));
");

        public Setup_Should_Work_With_Arguments_That_Are_Not_Matchers(ITestOutputHelper testOutputHelper)
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
