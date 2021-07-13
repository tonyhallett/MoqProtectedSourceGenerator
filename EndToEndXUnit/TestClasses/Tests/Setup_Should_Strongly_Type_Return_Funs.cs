using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Strongly_Type_Return_Funs : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int MethodWithReturnOneParameter(int p1);
    public int InvokeMethodWithReturnOneParameter(int p1){
        return MethodWithReturnOneParameter(p1);    
    }

    protected abstract int MethodWithReturnTwoParameters(int p1, int p2);
    public int InvokeMethodWithReturnTwoParameters(int p1, int p2){
        return MethodWithReturnTwoParameters(p1,p2);    
    }

    protected abstract int OutRefMethodWithReturn(out int outI, ref int refI);
    public int InvokeOutRefMethodWithReturn(out int outI, ref int refI){
        return OutRefMethodWithReturn(out outI, ref refI);
    }
",
            @"

    // it is always possible to return a value without a func

    mock.MethodWithReturnOneParameter(It.IsAny<int>()).Build().Setup().Returns(v => v + 1);
    Assert.AreEqual(1, mocked.InvokeMethodWithReturnOneParameter(0));

    // it is always possible to use Func<TResult>
    mock.MethodWithReturnTwoParameters(0, It.IsAny<int>()).Build().Setup().Returns(() => 9);
    Assert.AreEqual(9, mocked.InvokeMethodWithReturnTwoParameters(0,2));

    // It is always possible to use InvocationFunc
    var invocationFunc = new InvocationFunc(invocation => (int)invocation.Arguments[0] * (int)invocation.Arguments[1]); 
    mock.MethodWithReturnTwoParameters(-1, It.IsAny<int>()).Build().Setup().Returns(invocationFunc);
    Assert.AreEqual(-2, mocked.InvokeMethodWithReturnTwoParameters(-1,2));

    mock.MethodWithReturnTwoParameters(1, It.IsAny<int>()).Build().Setup().Returns((v1,v2) => v1 + v2);
    Assert.AreEqual(3, mocked.InvokeMethodWithReturnTwoParameters(1,2));

    // generated delegate
    mock.OutRefMethodWithReturn(Out.From(1),ref It.Ref<int>.IsAny).Build().Setup()
    .Returns((out int outInt, ref int refInt) => {
        outInt = 1;
        return refInt + 1;
    });
    var refInt = 0;
    Assert.AreEqual(1, mocked.InvokeOutRefMethodWithReturn(out var _, ref refInt));
");

        public Setup_Should_Strongly_Type_Return_Funs(ITestOutputHelper testOutputHelper)
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
