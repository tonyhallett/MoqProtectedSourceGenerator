using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Custom_Matchers : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(int i);
    public void InvokeMethodWithParameters(int i){
        MethodWithParameters(i);    
    }
",
            @"
    
    mock.MethodWithParameters(CustomMatcher.Wrap(MyCustomMatcher.GreaterThan, 1000)).Build().Setup().Throws(new ExpectedException());
    mocked.InvokeMethodWithParameters(1000);
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithParameters(1001));
",
            @"
    public static class MyCustomMatcher
    {
        public static int GreaterThan(int value)
        {
            return Match.Create<int>(v => v > value);
        }
    }
");

        public Setup_Should_Work_With_Custom_Matchers(ITestOutputHelper testOutputHelper)
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
