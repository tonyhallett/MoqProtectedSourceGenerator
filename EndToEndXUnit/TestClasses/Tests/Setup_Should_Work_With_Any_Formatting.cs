using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Any_Formatting : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int MethodWithParameters(out int o,ref int r,int i, int i2);
    public int InvokeMethodWithParameters(out int o,ref int r, int i, int i2){
        return MethodWithParameters(out o,ref r,i, i2);    
    }
",
            @"
    mock.
        MethodWithParameters(  Out.
            From(1) ,  ref   
            It.
            Ref<int>.
            IsAny , It.
            IsAny<int>(),
            CustomMatcher.
            Wrap(MyCustomMatcher.GreaterThan, 1000)
        ).
        Build().
        Setup().
        Returns(1);
    var refInt = 0;
    var noMatch = mocked.InvokeMethodWithParameters(out var outInt,ref refInt, 0,1000);
    Assert.AreEqual(0, noMatch);
    Assert.AreEqual(0, outInt);
    var match = mocked.InvokeMethodWithParameters(out var outInt2,ref refInt, 0,1001);
    Assert.AreEqual(1, match);
    Assert.AreEqual(1, outInt2);

    mock
        .MethodWithParameters(  Out
            .From(2) ,  ref   
            It
            .Ref<int>
            .IsAny , It
            .IsAny<int>(),
            CustomMatcher
            .Wrap(MyCustomMatcher.GreaterThan, 100)
        )
        .Build()
        .Setup()
        .Returns(2);

    var match2 = mocked.InvokeMethodWithParameters(out var outInt3,ref refInt, 0,101);
    Assert.AreEqual(2, match2);
    Assert.AreEqual(2, outInt3);
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

        public Setup_Should_Work_With_Any_Formatting(ITestOutputHelper testOutputHelper)
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
