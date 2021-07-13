using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Should_Work_With_Duplicate_Protected_Class_Names : MoqProtectedSourceGeneratorTestBase
    {
        private readonly string protectedDllPath;
        private readonly string outputFolder;
        private readonly ITestOutputHelper testOutputHelper;
        private const string ProtectedDllDllName = "ProtectedDll.dll";
        public Should_Work_With_Duplicate_Protected_Class_Names(ITestOutputHelper testOutputHelper)
        {
            outputFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            protectedDllPath = Path.Combine(outputFolder, ProtectedDllDllName);
            Assert.True(File.Exists(protectedDllPath));
            this.testOutputHelper = testOutputHelper;
        }

        protected override void Log(string message)
        {
            testOutputHelper.WriteLine(message);
        }

        protected override string Source => @"
using System;
using Moq;
using NUnit.Framework;
using MoqProtectedTyped;

namespace ClassLibrary1
{
    public class ExpectedException : Exception { }

    public abstract class Duplicate
    {
        protected abstract string Dupe(int value);
        public string Invoke(int value)
        {
            return Dupe(value);
        }
    }

    public class Test
    {
        [Test]
        public void Generate()
        {
            var mockDuplicate = new ProtectedMock<Duplicate>();
            mockDuplicate.Dupe(0).Build().Setup().Returns(""First"");
            var mockDuplicateDll = new ProtectedMock<ProtectedDll.Duplicate>();
            mockDuplicateDll.Dupe(0).Build().Setup().Returns(""Second"");
            Assert.AreEqual(""First"", mockDuplicate.Object.Invoke(0));
            Assert.AreEqual(""Second"", mockDuplicateDll.Object.Invoke(0));
        }
    }
}

";

        protected override IEnumerable<MetadataReference> AdditionalMetadataReferences()
        {
            return new MetadataReference[] { MetadataReference.CreateFromFile(protectedDllPath) };

        }

        protected override void CopyAdditionalDlls(string emitFolder)
        {
            FileHelper.CopyFileToDirectory(outputFolder, emitFolder, ProtectedDllDllName);
        }

        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
