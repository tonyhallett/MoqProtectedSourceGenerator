using Xunit;

namespace EndToEndTests
{
    public class SetupSequence_Should_Work_With_Parameterless_Void_Methods : MoqProtectedSourceGeneratorTestBase
    {
        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void VoidMethod();
    public void InvokeVoidMethod(){
        VoidMethod();    
    }
",
            @"
    mock.VoidMethod().Build().SetupSequence().Pass().Pass().Throws(new ExpectedException());
    mocked.InvokeVoidMethod();
    mocked.InvokeVoidMethod();
    Assert.Throws<ExpectedException>(() => mocked.InvokeVoidMethod());
");
        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
