using Xunit;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Parameterless_Void_Methods : MoqProtectedSourceGeneratorTestBase
    {
        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void VoidMethod();
    public void InvokeVoidMethod(){
        VoidMethod();    
    }
",
            @"
    mock.VoidMethod().Build().Setup().Throws(new ExpectedException());
    Assert.Throws<ExpectedException>(() => mocked.InvokeVoidMethod());
");
        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
