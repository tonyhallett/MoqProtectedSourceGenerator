using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Out_Parameters : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(out int o,int i);
    public void InvokeMethodWithParameters(out int o,int i){
        MethodWithParameters(out o,i);    
    }
",
            @"
    
    mock.MethodWithParameters(Out.From(1),1).Build().Setup();
    mock.MethodWithParameters(Out.From(2),2).Build().Setup();
    mocked.InvokeMethodWithParameters(out var out1, 1);
    mocked.InvokeMethodWithParameters(out var out2, 2);
    Assert.AreEqual(2, out2);
");

        public Setup_Should_Work_With_Out_Parameters(ITestOutputHelper testOutputHelper)
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
