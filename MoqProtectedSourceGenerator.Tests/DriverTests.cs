using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Moq;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public class Given_Mock_Of_Protected_Class_From_Source : IDisposable
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

            var expectedSource =
@"using System;

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

        [Fact]
        public void Should_Generate_Fake_Extension_Method_Class_With_Same_Name_As_Protected_Method_In_Global_Namespace_By_Default()
        {
            var source = @"
using Moq;
namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void AbstractMethodArgs(int value);
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

            var expectedSource =
@"using ClassLibrary1;
using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public static class MyProtected_AbstractMethodArgs
{
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>{};
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>{};

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
            AssertEqualGeneratedSource(source, "MyProtected_AbstractMethodArgs.cs", expectedSource);
        }

        /*
            note that there is no way to provide AnalyzerConfigFiles with driver tests
            of course this can be achieved with CSharpSourceGeneratorTest but this is all or nothing
            from first observations. Hence the use of the driver.
            Using static property AnalyzerConfigOptionsExtensions.MockAnalyzerConfigOptions
        */
        [Fact]
        public void Should_Generate_In_The_MoqProtectedGenerated_Namespace_When_Set_In_Options()
        {
            var mockAnalyzerConfigOptions = new Mock<AnalyzerConfigOptions>();
            var globalExtensions = "false";
            mockAnalyzerConfigOptions.Setup(o => o.TryGetValue($"{nameof(MoqProtectedSourceGenerator)}_GlobalExtensions", out globalExtensions)).Returns(true);
            AnalyzerConfigOptionsExtensions.MockAnalyzerConfigOptions = mockAnalyzerConfigOptions.Object;
            var source = @"
using Moq;
namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void AbstractMethodArgs(int value);
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

            var expectedSource =
@"using ClassLibrary1;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoqProtectedGenerated
{
    public static class MyProtected_AbstractMethodArgs
    {
        private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
            new Dictionary<string, Expression<Action<MyProtectedLike>>>{};
        private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
            new Dictionary<string, Expression<Action<MyProtectedLike>>>{};
    
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
}
";
            AssertEqualGeneratedSource(source, "MyProtected_AbstractMethodArgs.cs", expectedSource);
        }

        [Fact]
        public void Should_Create_Setup_Expressions_From_Extension_Arguments_And_File_Name_And_Line_Number_When_Build_And_Setup()
        {
            var source = @"
using Moq; // 2
namespace ClassLibrary1 // 3
{ // 4
    public abstract class MyProtected // 5
    { // 6
        protected abstract void AbstractMethodArgs(int value); // 7
    } // 8
    // 9
    public class Test // 10
    { // 11
        public void Generate() // 12
        { // 13
            var mock = new Mock<MyProtected>(); // 14
            mock.AbstractMethodArgs(999).Build().Setup(); // 15
            mock.AbstractMethodArgs(123).Build().Setup(); // 16
        }

    }
}
";

            var expectedSource =
@"using ClassLibrary1;
using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public static class MyProtected_AbstractMethodArgs
{
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>
        {
            {
                @""_15"",
                like => like.AbstractMethodArgs(999)
            },
            {
                @""_16"",
                like => like.AbstractMethodArgs(123)
            }
        };
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>{};

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
            AssertEqualGeneratedSource(source, "MyProtected_AbstractMethodArgs.cs", expectedSource);
        }

        [Fact]
        public void Should_Create_Verify_Expressions_From_Extension_Arguments_And_File_Name_And_Line_Number_When_Build_And_Verify()
        {
            var source = @"
using Moq; // 2
namespace ClassLibrary1 // 3
{ // 4
    public abstract class MyProtected // 5
    { // 6
        protected abstract void AbstractMethodArgs(int value); // 7
    } // 8
    // 9
    public class Test // 10
    { // 11
        public void Generate() // 12
        { // 13
            var mock = new Mock<MyProtected>(); // 14
            mock.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify(); // 15
            mock.AbstractMethodArgs(123).Build().Verify(); // 16
        }

    }
}
";

            var expectedSource =
@"using ClassLibrary1;
using Moq;
using Moq.Protected;
using MoqProtectedGenerated;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public static class MyProtected_AbstractMethodArgs
{
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Setups =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>{};
    private static readonly Dictionary<string, Expression<Action<MyProtectedLike>>> Verifications =
        new Dictionary<string, Expression<Action<MyProtectedLike>>>
        {
            {
                @""_15"",
                like => like.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive))
            },
            {
                @""_16"",
                like => like.AbstractMethodArgs(123)
            }
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
            AssertEqualGeneratedSource(source, "MyProtected_AbstractMethodArgs.cs", expectedSource);
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

        private void AssertEqualGeneratedSource(string source, string hintName, string expectedSource, string failFileName = null, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            var options = new AssertEqualGeneratedSourceOptions
            {
                WriteToFileIfFails = failFileName == null ? GetGeneratedFilePath(memberName) : GetGeneratedFilePath(failFileName)
            };
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

        public void Dispose()
        {
            AnalyzerConfigOptionsExtensions.MockAnalyzerConfigOptions = null;
        }
    }
    
}
