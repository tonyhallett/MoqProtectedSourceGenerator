using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Callbacks : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int MethodWithReturn();
    protected abstract int MethodWithReturnOneParameter(int p1);
    public int InvokeMethodWithReturn(){
        return MethodWithReturn();    
    }
    public int InvokeMethodWithReturnOneParameter(int p1){
        return MethodWithReturnOneParameter(p1);    
    }

    protected abstract void VoidMethod();
    protected abstract void VoidMethodOneParameter(int p1);
    public void InvokeVoidMethod(){
        VoidMethod();
    }
    public void InvokeVoidMethodOneParameter(int p1){
        VoidMethodOneParameter(p1);    
    }

    protected abstract int MethodWithOutAndRef(out int outI, ref int refI);
    public int InvokeMethodWithOutAndRef(out int outI, ref int refI){
        return MethodWithOutAndRef(out outI, ref refI);
    }
",
            @"
    var calledBackBefore = false;
    var calledBackAfter = false;
    mock.MethodWithReturn().Build().Setup().Callback(() => calledBackBefore = true).Returns(1).Callback(()=> calledBackAfter = true);
    mocked.InvokeMethodWithReturn();
    Assert.True(calledBackBefore);
    Assert.True(calledBackAfter);

    int p1Before = 0;
    int p1After = 0;
    mock.MethodWithReturnOneParameter(It.IsAny<int>()).Build().Setup()
        .Callback(p1 => p1Before = p1).Returns(1).Callback(p1 => p1After = p1);
    mocked.InvokeMethodWithReturnOneParameter(1);

    Assert.AreEqual(1, p1Before);
    Assert.AreEqual(1, p1After);

    var calledBack = false;
    mock.VoidMethod().Build().Setup().Callback(() => calledBack = true);
    mocked.InvokeVoidMethod();
    Assert.True(calledBack);

    int p1 = 0;
    mock.VoidMethodOneParameter(1).Build().Setup()
        .Callback(p => p1 = p);
    mocked.InvokeVoidMethodOneParameter(1);
    Assert.AreEqual(1, p1);    
    // Action is always available
    calledBack = false;
    mock.VoidMethodOneParameter(2).Build().Setup().Callback(() => calledBack = true);
    mocked.InvokeVoidMethodOneParameter(2);    
    Assert.True(calledBack);
    // InvocationAction is always available
    IInvocation invocation = null;
    InvocationAction invocationAction = new InvocationAction(_invocation => invocation = _invocation);
    mock.VoidMethodOneParameter(3).Build().Setup().Callback(invocationAction);
    mocked.InvokeVoidMethodOneParameter(3);    
    Assert.AreEqual(3,invocation.Arguments[0]);


    //delegate generated for ref out parameters
    
    var refBefore = 0;
    var refAfter = 0;
    var refInt = 1;
    mock.MethodWithOutAndRef(Out.From(1), ref It.Ref<int>.IsAny).Build().Setup().
        Callback((out int outInt, ref int refInt) => {
            outInt = 2;
            refBefore = refInt;
        }).Returns(1).
        Callback((out int outInt, ref int refInt) => {
            outInt =3;
            refAfter = refInt;
        });
    mocked.InvokeMethodWithOutAndRef(out var outInt, ref refInt);
    Assert.AreEqual(refBefore, 1);
    Assert.AreEqual(refAfter, 1);
    Assert.AreEqual(3, outInt); // this is the same behaviour as Moq
");

        public Setup_Should_Work_With_Callbacks(ITestOutputHelper testOutputHelper)
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
