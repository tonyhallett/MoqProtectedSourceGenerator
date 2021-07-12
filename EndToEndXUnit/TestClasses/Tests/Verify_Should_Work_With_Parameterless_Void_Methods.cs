using Xunit;

namespace EndToEndTests
{
    public class Verify_Should_Work_With_Parameterless_Void_Methods : MoqProtectedSourceGeneratorTestBase
    {
        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void VoidMethod();
    public void InvokeVoidMethod(){
        VoidMethod();    
    }
",
            @"
    void Verify(){
        mock.VoidMethod().Build().Verify();
    }
    
    Assert.Throws<MockException>(Verify);
    mocked.InvokeVoidMethod();
    Verify();

");
        
        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
