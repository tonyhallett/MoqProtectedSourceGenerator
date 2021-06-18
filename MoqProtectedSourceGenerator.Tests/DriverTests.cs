using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Moq;
using MoqProtectedTyped;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public class Debugging_Test : IDisposable
    {
        private readonly MoqProtectedSourceGenerator moqProtectedSourceGenerator;

        public Debugging_Test()
        {
            moqProtectedSourceGenerator = new MoqProtectedSourceGenerator();
        }

        // this is solely for debugging purposes
        [Fact]
        public void TestExtension()
        {
            var source = @"
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
namespace ClassLibrary1
{

    public abstract class MyProtected
    { 
        //protected abstract void AbstractMethodArgs<T>(T t1, T t2) where T:ConstraintClass;
        //protected abstract void RefMethod(ref int refArg);
        //protected abstract void RefGenericMethod<T>(ref T refArg);
        protected abstract void OutParameter(out int outInt);
    }
    
    public class ConstraintClass{}
    public class SubType1{}
    public class SubType2{}
    public class Test
    {
        public void Generate()
        {
            var mock = new ProtectedMock<MyProtected>();
            mock.OutParameter(     null).Build().Setup();
            //mock.RefGenericMethod(ref It.Ref<It.IsSubtype<SubType2>>.IsAny).Build().Setup();
            //mock.AbstractMethodArgs(1,It.IsAny<int>()).Build().Setup();
            //mock.AbstractMethodArgs(Out.Param(1)).Build().Setup();
        }
        

    }

    public static class CustomMatchers{
        public static int FromStatic(int equalTo){
            return Match.Create<int>(value => value == equalTo);
        }
    }
}

";
            AssertEqualGeneratedSource(source, "", "");
        }

        private Compilation CreateCompilation(string source)
        {
            var assemblyNames = new string[]
            {
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                "System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                "System.Linq.Expressions, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Collections, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            };
            var metadataReferences = new MetadataReference[] {
                MetadataReference.CreateFromFile(typeof(Mock).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(MatcherObserver).GetTypeInfo().Assembly.Location)
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
