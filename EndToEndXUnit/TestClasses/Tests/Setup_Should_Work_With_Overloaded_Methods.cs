using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Overloaded_Methods : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int Overloaded(int i);
    public int InvokeOverloaded(int i){
        return Overloaded(i);    
    }
    protected abstract int Overloaded(string s);
    public int InvokeOverloaded(string s){
        return Overloaded(s);    
    }

",
            @"
    mock.Overloaded(1).Build().Setup().Returns(1);
    mock.Overloaded(""2"").Build().Setup().Returns(2);
    Assert.AreEqual(1,mocked.InvokeOverloaded(1));
    Assert.AreEqual(2,mocked.InvokeOverloaded(""2""));
");

        public Setup_Should_Work_With_Overloaded_Methods(ITestOutputHelper testOutputHelper)
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
