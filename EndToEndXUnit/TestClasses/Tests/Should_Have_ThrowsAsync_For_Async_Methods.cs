using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Should_Have_ThrowsAsync_For_Async_Methods : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract Task<int> TaskInt();
    public Task<int> InvokeTaskInt()
    {
        return TaskInt();
    }
    protected abstract Task Task();
    public Task InvokeTask()
    {
        return Task();
    }
    protected abstract ValueTask<int> ValueTaskInt();
    public ValueTask<int> InvokeValueTaskInt()
    {
        return ValueTaskInt();
    }

    protected abstract ValueTask ValueTask();
    public ValueTask InvokeValueTask()
    {
        return ValueTask();
    }
",
            @"
    Action noopCallback = () => {};    
    var random = new Random();    

    mock.Task().Build().Setup().ThrowsAsync<ExpectedException>();
    Assert.True(mocked.InvokeTask().IsCompleted);
    
    void AssertDelayedFaultedTask(Task task){
        Assert.False(task.IsCompleted);
        Assert.ThrowsAsync<ExpectedException>(async () => await task);
    }
    
    void ThrowAsync(dynamic setup,Func<Task> invokeMocked){
        ThrowAsyncThrowable(setup, invokeMocked);
        var throwable2 = setup.Callback(noopCallback);
        ThrowAsyncThrowable(throwable2, invokeMocked);
    }

    void ThrowAsyncThrowable(dynamic throwable,Func<Task> invokeMocked){
        throwable.ThrowsAsync<ExpectedException>();
        Assert.ThrowsAsync<ExpectedException>(async () => await invokeMocked());
        throwable.ThrowsAsync(new ExpectedException());
        Assert.ThrowsAsync<ExpectedException>(async () => await invokeMocked());
        throwable.ThrowsAsync(new ExpectedException(),TimeSpan.FromMilliseconds(200));
        AssertDelayedFaultedTask(invokeMocked());
        throwable.ThrowsAsync(new ExpectedException(),TimeSpan.FromMilliseconds(200),TimeSpan.FromMilliseconds(400));
        AssertDelayedFaultedTask(invokeMocked());
        throwable.ThrowsAsync(new ExpectedException(),TimeSpan.FromMilliseconds(200),TimeSpan.FromMilliseconds(400),random);
        AssertDelayedFaultedTask(invokeMocked());
    }

    ThrowAsync(mock.ValueTask().Build().Setup(),() => mocked.InvokeValueTask().AsTask());
    ThrowAsync(mock.ValueTaskInt().Build().Setup(), () => mocked.InvokeValueTaskInt().AsTask());
    ThrowAsync(mock.TaskInt().Build().Setup(), () => mocked.InvokeTaskInt());
    ThrowAsync(mock.Task().Build().Setup(), () => mocked.InvokeTask());
    
", "", "using System.Threading.Tasks;");

        public Should_Have_ThrowsAsync_For_Async_Methods(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        protected override void Log(string message)
        {
            testOutputHelper.WriteLine(message);
        }

        protected override IEnumerable<MetadataReference> AdditionalMetadataReferences()
        {
            return DynamicKeywordMetadataReference.Single;
        }

        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
