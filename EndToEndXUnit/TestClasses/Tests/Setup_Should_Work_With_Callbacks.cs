using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Setup_Should_Work_With_Callbacks : MoqProtectedSourceGeneratorTestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        private void GenerateMethodSignature(StringBuilder stringBuilder,string methodName,bool isProtected, string signature,string returnType = "void")
        {
            stringBuilder.Append($"{(isProtected ? "protected abstract" : "public")} {returnType} {methodName}({signature})");
        }
        
        private void GenerateProtectedAndInvoke(StringBuilder stringBuilder, string protectedName,string signature, string parameterNames,string returnType = "void")
        {
            var invokeProtectedName = InvokeProtectedName(protectedName);
            GenerateMethodSignature(stringBuilder, protectedName, true, signature, returnType);
            stringBuilder.AppendLine(";");
            GenerateMethodSignature(stringBuilder, invokeProtectedName, false, signature, returnType);
            stringBuilder.Append(@$"{{
                {(returnType == "void" ? "" : "return ")}{protectedName}({parameterNames});  
            }}
");
        }

        private string InvokeProtectedName(string protectedMethodName)
        {
            return $"Invoke{protectedMethodName}";
        }

        private string VoidMethodName(int numParameters)
        {
            return $"VoidMethod{numParameters}";
        }

        private string ReturnMethodName(int numParameters)
        {
            return $"ReturnMethod{numParameters}";
        }


        private void GenerateMethods(StringBuilder methodsStringBuilder,string signature, string parameterNames,int numParameters)
        {
            var voidMethodName = VoidMethodName(numParameters);
            var returnMethodName = ReturnMethodName(numParameters);
            GenerateProtectedAndInvoke(methodsStringBuilder, voidMethodName, signature, parameterNames);
            GenerateProtectedAndInvoke(methodsStringBuilder, returnMethodName, signature, parameterNames, "int");

        }

        private void GenerateCommon(StringBuilder commonStringBuilder,string arguments, int numParameters)
        {
            GenerateCommon(commonStringBuilder, arguments, numParameters, true);
            GenerateCommon(commonStringBuilder, arguments, numParameters, false);
        }
        private void GenerateCommon(StringBuilder commonStringBuilder, string arguments, int numParameters, bool isVoid)
        {
            var protectedMethodName = ProtectedMethodName(numParameters,isVoid);
            commonStringBuilder.Append(@$"
                    Common{(isVoid ? "Void" : "Return")}(
                        () => {SetupMock(arguments, numParameters,isVoid)},
                        () => {InvokeMock(arguments, numParameters, isVoid)},
                        ""{protectedMethodName}""
                    );
                ");
        }
        
        private void GenerateSpecific(
            StringBuilder voidCallbackAssignmentStringBuilder,
            StringBuilder returnBeforeCallbackAssignmentStringBuilder,
            StringBuilder returnAfterCallbackAssignmentStringBuilder,
            StringBuilder specificStringBuilder,
            string parameterNames,
            string parameterName,
            string arguments,
            int numParameters)
        {
            voidCallbackAssignmentStringBuilder.Append($@"
                        callbackArguments[{numParameters - 1}] = {parameterName};");
            returnBeforeCallbackAssignmentStringBuilder.Append($@"
                        beforeCallbackArguments[{numParameters - 1}] = {parameterName};");
            returnAfterCallbackAssignmentStringBuilder.Append($@"
                        afterCallbackArguments[{numParameters - 1}] = {parameterName};");
            
            specificStringBuilder.Append(@$"
                    void SpecificVoidTest{numParameters}(){{
                        var callbackArguments = Enumerable.Repeat(-1, {numParameters}).ToArray();
                        {VoidSetupMock(arguments,numParameters)}.Callback(({parameterNames}) => {{{voidCallbackAssignmentStringBuilder}}});
                        {VoidInvokeMock(arguments,numParameters)};
                        foreach(var callbackArgument in callbackArguments){{
                            Assert.AreEqual(0,callbackArgument);
                        }}
                    }}
                    SpecificVoidTest{numParameters}();");
            
            specificStringBuilder.Append(@$"
                    void SpecificReturnTest{numParameters}(){{
                        var beforeCallbackArguments = Enumerable.Repeat(-1, {numParameters}).ToArray();
                        var afterCallbackArguments = Enumerable.Repeat(-1, {numParameters}).ToArray();
                        {ReturnSetupMock(arguments, numParameters)}.
                            Callback(({parameterNames}) => {{{returnBeforeCallbackAssignmentStringBuilder}}}).
                            Returns(1).
                            Callback(({parameterNames}) => {{{returnAfterCallbackAssignmentStringBuilder}}});
                        {ReturnInvokeMock(arguments, numParameters)};
                        foreach(var callbackArgument in beforeCallbackArguments.Concat(afterCallbackArguments)){{
                            Assert.AreEqual(0,callbackArgument);
                        }}
                    }}
                    SpecificReturnTest{numParameters}();");
        }

        private string VoidSetupMock(string arguments,int numParameters)
        {
            return SetupMock(arguments, numParameters, true);
        }

        private string ReturnSetupMock(string arguments, int numParameters)
        {
            return SetupMock(arguments, numParameters, false);
        }

        private string ProtectedMethodName(int numParameters, bool isVoid)
        {
            return isVoid? VoidMethodName(numParameters) : ReturnMethodName(numParameters);
        }

        private string SetupMock(string arguments, int numParameters,bool isVoid)
        {
            var methodName = ProtectedMethodName(numParameters, isVoid);
            return $"mock.{methodName}({arguments}).Build().Setup()";
        }

        private string VoidInvokeMock(string arguments, int numParameters)
        {
            return InvokeMock(arguments, numParameters, true);
        }

        private string ReturnInvokeMock(string arguments, int numParameters)
        {
            return InvokeMock(arguments, numParameters, false);
        }

        private string InvokeMock(string arguments, int numParameters,bool isVoid)
        {
            var protectedMethodName = ProtectedMethodName(numParameters, isVoid);
            return $"mocked.{InvokeProtectedName(protectedMethodName)}({arguments})";
        }
        
        private void CommaDelimit(params StringBuilder[] stringBuilders)
        {
            foreach(var sb in stringBuilders)
            {
                sb.Append(",");
            }
        }
        private (string methods,string common,string specific) Generate(int numParameters)
        {
            var methodsStringBuilder = new StringBuilder();
            var commonStringBuilder = new StringBuilder();
            var specificStringBuilder = new StringBuilder();
            
            var signatureStringBuilder = new StringBuilder();
            var parameterNamesStringBuilder = new StringBuilder();
            var argumentsStringBuilder = new StringBuilder();
            var voidCallbackAssignmentStringBuilder = new StringBuilder();
            var returnBeforeCallbackAssignmentStringBuilder = new StringBuilder();
            var returnAfterCallbackAssignmentStringBuilder = new StringBuilder();

            for (var i = 0; i < numParameters; i++)
            {
                var parameterName = $"i{i}";

                if (i > 1)
                {
                    CommaDelimit(signatureStringBuilder, parameterNamesStringBuilder, argumentsStringBuilder);
                }

                if(i > 0)
                {
                    signatureStringBuilder.Append($"int {parameterName}");
                    parameterNamesStringBuilder.Append(parameterName);
                    argumentsStringBuilder.Append("0");
                }
                
                var signature = signatureStringBuilder.ToString();
                var parameterNames = parameterNamesStringBuilder.ToString();
                var arguments = argumentsStringBuilder.ToString();

                GenerateMethods(methodsStringBuilder, signature, parameterNames, i);

                GenerateCommon(commonStringBuilder, arguments, i);

                if (i != 0)         
                {
                    GenerateSpecific(
                        voidCallbackAssignmentStringBuilder, 
                        returnBeforeCallbackAssignmentStringBuilder,
                        returnAfterCallbackAssignmentStringBuilder,
                        specificStringBuilder, parameterNames, parameterName, arguments, i
                    );
                }
            }
            return (methodsStringBuilder.ToString(), commonStringBuilder.ToString(), specificStringBuilder.ToString());
        }
        protected override string Source { 
            get {
                var (methods, common, specific) = Generate(17);
                return TestSource.ProtectedInSource(
            @$"

    {methods}
    
    protected abstract int MethodWithOutAndRef(out int outI, ref int refI);
    public int InvokeMethodWithOutAndRef(out int outI, ref int refI){{
        return MethodWithOutAndRef(out outI, ref refI);
    }}
",
            @$"
    
    //int p1Before = 0;
    //int p1After = 0;
    //mock.MethodWithReturnOneParameter(It.IsAny<int>()).Build().Setup()
    //    .Callback(p1 => p1Before = p1).Returns(1).Callback(p1 => p1After = p1);
    //mocked.InvokeMethodWithReturnOneParameter(1);

    //Assert.AreEqual(1, p1Before);
    //Assert.AreEqual(1, p1After);

    {specific}

    // Have to have a fresh setup.  If reuse setup and Returns has been called then 
    // before callback becomes the after callback
    void CommonReturn(Func<dynamic> setup,Action invokeMock,string protectedMethodName){{
        var calledBackBefore = false;
        var calledBackAfter = false;
        Action actionCallbackBefore = () => calledBackBefore = true;
        Action actionCallbackAfter = ()=> calledBackAfter = true;
        setup().Callback(actionCallbackBefore).Returns(1).Callback(actionCallbackAfter);
        invokeMock();
        Assert.True(calledBackBefore);
        Assert.True(calledBackAfter);

        IInvocation invocationBefore = null;
        InvocationAction invocationActionBefore = new InvocationAction(invocation => invocationBefore = invocation);
        IInvocation invocationAfter = null;
        InvocationAction invocationActionAfter = new InvocationAction(invocation => invocationAfter = invocation);
        setup().Callback(invocationActionBefore).Returns(1).Callback(invocationActionAfter);
        invokeMock();
        Assert.AreEqual(protectedMethodName,invocationBefore.Method.Name, ""before invocation failure"");
        Assert.AreEqual(protectedMethodName,invocationAfter.Method.Name, ""after invocation failure"");
    
    }}    
    void CommonVoid(Func<dynamic> setup,Action invokeMock,string protectedMethodName){{
        // Action is always available
        var calledBack = false;
        Action actionCallback = () => calledBack = true;
        setup().Callback(actionCallback);
        invokeMock();
        Assert.True(calledBack);
        // InvocationAction is always available
        IInvocation invocation = null;
        InvocationAction invocationAction = new InvocationAction(_invocation => invocation = _invocation);
        setup().Callback(invocationAction);
        invokeMock();
        Assert.AreEqual(protectedMethodName,invocation.Method.Name);
    }}
    {common}
    
    //delegate generated for ref out parameters
    
    var refBefore = 0;
    var refAfter = 0;
    var refInt = 1;
    mock.MethodWithOutAndRef(Out.From(1), ref It.Ref<int>.IsAny).Build().Setup().
        Callback((out int outInt, ref int refInt) => {{
            outInt = 2;
            refBefore = refInt;
        }}).Returns(1).
        Callback((out int outInt, ref int refInt) => {{
            outInt =3;
            refAfter = refInt;
        }});
    mocked.InvokeMethodWithOutAndRef(out var outInt, ref refInt);
    Assert.AreEqual(refBefore, 1);
    Assert.AreEqual(refAfter, 1);
    Assert.AreEqual(3, outInt); // this is the same behaviour as Moq
","","using System.Linq;");
            } 
        }

        public Setup_Should_Work_With_Callbacks(ITestOutputHelper testOutputHelper)
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
