using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Support_Properties : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    public event EventHandler AnEvent;
    protected abstract int GetSet {get;set;}
    public void SetGetSet(int value){
        GetSet = value;
    }
    public int GetGetSet(){
        return GetSet;
    }

    protected abstract int Get {get;}
    public int GetGet(){
        return Get;
    }

    protected abstract int Set {set;}
    public void SetSet(int value){
        Set = value;
    }
",
            @"
    // get uses Moq ISetupGetter 
    var getGetSetCalled = false;
    mock.GetSet().Get().Build().Setup().Callback(() => getGetSetCalled = true).Returns(1);
    Assert.AreEqual(1,mocked.GetGetSet());
    Assert.True(getGetSetCalled);

    var setGetSetCalled = false;
    mock.GetSet().Set(1).Build().Setup().Callback(() => setGetSetCalled = true);
    mocked.SetGetSet(1);
    Assert.True(setGetSetCalled);
    
    var getSetSetValue = 0;
    mock.GetSet().Set(1).Build().Setup().Callback( v => getSetSetValue = v).Throws(new ExpectedException());
    Assert.Throws<ExpectedException>(()=>mocked.SetGetSet(1));
    Assert.AreEqual(1, getSetSetValue);

    IInvocation invocation = null;
    InvocationAction invocationAction = new InvocationAction(_invocation => invocation = _invocation);
    mock.GetSet().Set(1).Build().Setup().Callback(invocationAction);
");

        public Setup_Should_Support_Properties(ITestOutputHelper testOutputHelper)
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
