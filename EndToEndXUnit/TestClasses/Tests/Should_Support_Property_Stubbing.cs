using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Should_Support_Property_Stubbing: MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int Property {get;set;}
    public void SetProperty(int value){
        Property = value;
    }
    public int GetProperty(){
        return Property;
    }
",
            @"
    mock.Property().SetupProperty();
    mocked.SetProperty(1);
    Assert.AreEqual(1, mocked.GetProperty());
");

        public Should_Support_Property_Stubbing(ITestOutputHelper testOutputHelper)
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
