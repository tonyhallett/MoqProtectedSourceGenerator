using Xunit;
using Xunit.Abstractions;

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

    public class Setup_Should_Work_With_Arguments_That_Are_Not_Matchers : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(string s);
    public void InvokeMethodWithParameters(string s){
        MethodWithParameters(s);    
    }
",
            @"
    mock.MethodWithParameters(""throw"").Build().Setup().Throws(new ExpectedException());
    mocked.InvokeMethodWithParameters(""dont"");
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithParameters(""throw""));
");

        public Setup_Should_Work_With_Arguments_That_Are_Not_Matchers(ITestOutputHelper testOutputHelper)
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

    public class Setup_Should_Work_With_It_Matchers : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(string s);
    public void InvokeMethodWithParameters(string s){
        MethodWithParameters(s);    
    }
",
            @"
    mock.MethodWithParameters(It.Is<string>(v => v==""throw"")).Build().Setup().Throws(new ExpectedException());
    mocked.InvokeMethodWithParameters(""dont"");
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithParameters(""throw""));
");

        public Setup_Should_Work_With_It_Matchers(ITestOutputHelper testOutputHelper)
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

    public class Setup_Should_Work_With_Custom_Matchers : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(int i);
    public void InvokeMethodWithParameters(int i){
        MethodWithParameters(i);    
    }
",
            @"
    
    mock.MethodWithParameters(CustomMatcher.Wrap(MyCustomMatcher.GreaterThan, 1000)).Build().Setup().Throws(new ExpectedException());
    mocked.InvokeMethodWithParameters(1000);
    Assert.Throws<ExpectedException>(() => mocked.InvokeMethodWithParameters(1001));
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

        public Setup_Should_Work_With_Custom_Matchers(ITestOutputHelper testOutputHelper)
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

    public class Setup_Should_Work_With_Out_Parameters : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        protected override string Source => TestSource.ProtectedInSource(
            @"
    protected abstract void MethodWithParameters(out int o,int i);
    public void InvokeMethodWithParameters(out int o,int i){
        MethodWithParameters(out o,i);    
    }
",
            @"
    
    mock.MethodWithParameters(Out.From(1),1).Build().Setup();
    mock.MethodWithParameters(Out.From(2),2).Build().Setup();
    mocked.InvokeMethodWithParameters(out var out1, 1);
    mocked.InvokeMethodWithParameters(out var out2, 2);
    Assert.AreEqual(2, out2);
");

        public Setup_Should_Work_With_Out_Parameters(ITestOutputHelper testOutputHelper)
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
