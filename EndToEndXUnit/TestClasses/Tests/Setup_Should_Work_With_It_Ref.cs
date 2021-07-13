using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_It_Ref : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract int RefIntMethod(ref int i);
    public int InvokeRefIntMethod(ref int i){
        return RefIntMethod(ref i);    
    }
    protected abstract string GenericRefMethod<T>(ref T t, ref T t2);
    public string InvokeGenericRefMethod<T>(ref T t, ref T t2){
        return GenericRefMethod(ref t, ref t2);
    }
",
            @"
    
    mock.RefIntMethod(ref It.Ref<int>.IsAny).Build().SetupSequence().Returns(1).Returns(2).Throws(new ExpectedException());
    var refInt = 0;
    var refInt2 = 0;
    Assert.AreEqual(1, mocked.InvokeRefIntMethod(ref refInt));
    Assert.AreEqual(2, mocked.InvokeRefIntMethod(ref refInt2));
    Assert.Throws<ExpectedException>(() => mocked.InvokeRefIntMethod(ref refInt2));

    mock.GenericRefMethod(ref It.Ref<GenericParameterIsIntOrString>.IsAny,ref It.Ref<GenericParameterIsIntOrString>.IsAny).Build().Setup().Returns(""any type where generic parameter is int or string"");
    float f1 = 0F;
    float f2 = 0F;
    List<string> stringList = null;
    IEnumerable<int> intEnumerable = null;
    List<float> floatList = null;
    Assert.Null(mocked.InvokeGenericRefMethod(ref f1, ref f2));
    Assert.Null(mocked.InvokeGenericRefMethod(ref floatList, ref floatList));
    Assert.AreEqual(""any type where generic parameter is int or string"",mocked.InvokeGenericRefMethod(ref intEnumerable, ref intEnumerable));
    Assert.AreEqual(""any type where generic parameter is int or string"",mocked.InvokeGenericRefMethod(ref stringList, ref stringList));
", @"
    [TypeMatcher]
    public sealed class GenericParameterIsIntOrString : ITypeMatcher
    {
        public bool Matches(Type typeArgument)
        {
            if (typeArgument != this.GetType() && typeArgument.IsGenericType)
            {
                var genericArgument = typeArgument.GetGenericArguments()[0];
                var match = genericArgument == typeof(int) || genericArgument == typeof(string);
                return match;
            }
            return false;
        }
    }
", "using System.Collections.Generic;");

        public Setup_Should_Work_With_It_Ref(ITestOutputHelper testOutputHelper)
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
