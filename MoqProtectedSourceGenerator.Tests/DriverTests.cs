using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Moq;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public class Given_Mock_Of_Protected_Class_From_Source
    {
        private readonly MoqProtectedSourceGenerator moqProtectedSourceGenerator;
        
        public Given_Mock_Of_Protected_Class_From_Source()
        {
            moqProtectedSourceGenerator = new MoqProtectedSourceGenerator();
        }
        
        [Fact]
        public void Should_Generate_Protected_Like_Interface_In_MoqProtectedGenerated_Namespace()
        {
            var source = @"
using Moq;
namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void AbstractMethod();
        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }
        protected abstract int SomeProperty { get; }
    }

    public class Test
    {
        public void Generate()
        {
            var mock = new Mock<MyProtected>();
        }

    }
}
";

            var expectedSource = @"
using System;

namespace MoqProtectedGenerated
{

    internal interface MyProtectedLike{
		int SomeProperty { get; }
		void AbstractMethod();
		void AbstractMethodArgs(int value);

    }

}";

            AssertEqualGeneratedSource(source, "MyProtectedLike.cs", expectedSource);
        }

        /*
            this is by default - note that there is no way to provide - AnalyzerConfigFiles
            of course this can be achieved with CSharpSourceGeneratorTest but this is all or nothing
            from first observations. Hence the use of the driver.
            Can add static property to AnalyzerConfigOptionsExtensions, for instance MockConfigOptions
        */
        [Fact]  
        public void Should_Generate_Fake_Extension_Method_Class_With_Same_Name_As_Protected_Method_In_Global_Namespace()
        {
            var source = @"
using Moq;
namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void AbstractMethod();
        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }
        protected abstract int SomeProperty { get; }
    }

    public class Test
    {
        public void Generate()
        {
            var mock = new Mock<MyProtected>();
        }

    }
}
";

            var expectedSource = @"
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Moq.Protected;
using ClassLibrary1;
using System;
using MoqProtectedGenerated;

public static class MyProtected_AbstractMethodArgs
	{
		private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
			new Dictionary<string, Expression<Action<MyProtectedLike>>>
		{

        };
        private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
            new Dictionary<string, Expression<Action<MyProtectedLike>>>
            {
            };

        private static string GetKey(string sourceFileInfo, int sourceLineNumber)
        {
            return sourceFileInfo + ""_"" + sourceLineNumber;
        }
        public static IVoidMethodBuilder<MyProtected> AbstractMethodArgs(this Mock<MyProtected> mock, int value)
        {
            return new VoidMethodBuilder<MyProtected>(
                (sourceFileInfo, sourceLineNumber) => mock.Protected().As<MyProtectedLike>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<MyProtectedLike>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
            );
        }
    }
";

            var hintName = "MyProtected_AbstractMethodArgs.cs";
            var options = new AssertEqualGeneratedSourceOptions
            {
                WriteToFileIfFails = GetGeneratedFilePath(hintName)
            };
            AssertEqualGeneratedSource(source, hintName, expectedSource, options);
        }

        private Compilation CreateCompilation(string source)
        {
            var assemblyNames = new string[]
            {
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                "System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                "System.Linq.Expressions, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            };
            var metadataReferences = new MetadataReference[] {
                MetadataReference.CreateFromFile(typeof(Mock).GetTypeInfo().Assembly.Location),
            }.Concat(assemblyNames.Select(n => MetadataReferenceHelper.CreateFromAssemblyLoad(n)));
            return CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                metadataReferences,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        private void AssertEqualGeneratedSource(string source, string hintName, string expectedSource, AssertEqualGeneratedSourceOptions options = null)
        {
            SingleSourceDriverTest.AssertEqualGeneratedSource(CreateCompilation(source), moqProtectedSourceGenerator, hintName, expectedSource, options);
        }

        private string GetGeneratedFilePath(string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName) + ".gcs";
            var projectDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent;
            var generatedFails = Path.Combine(projectDirectory.FullName, "GeneratedFails");
            if (!Directory.Exists(generatedFails))
            {
                Directory.CreateDirectory(generatedFails);
            }
            return Path.Combine(generatedFails, fileName);
        }

    }

}
