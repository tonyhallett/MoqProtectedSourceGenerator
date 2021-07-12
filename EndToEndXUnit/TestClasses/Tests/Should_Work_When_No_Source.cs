using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace EndToEndTests
{
    public class Should_Work_When_No_Source : MoqProtectedSourceGeneratorTestBase
    {
        private readonly string protectedDllPath;
        private readonly string outputFolder;
        private readonly ITestOutputHelper testOutputHelper;
        private const string ProtectedDllDllName = "ProtectedDll.dll";
        public Should_Work_When_No_Source(ITestOutputHelper testOutputHelper)
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
using IFace;
using Moq;
using NUnit.Framework;
using OtherNamespace;
using MoqProtectedTyped;

namespace ClassLibrary1
{
    public class ExpectedException : Exception { }
    public class Implementation : IInterface { }

    public class Test
    {
        [Test]
        public void Generate()
        {
            var mockDll = new ProtectedMock<ProtectedDll.DllProtected>();
            mockDll.ProtectedMethod(It.IsAny<Other>(), ""match"").Build().Setup().Throws(new ExpectedException());

            mockDll.Object.CallProtectedMethod(new Other(), ""not a match"");
            Assert.Throws<ExpectedException>(() => mockDll.Object.CallProtectedMethod(new Other(), ""match""));
            
            mockDll.ProtectedGenericMethod(It.IsAny<Implementation>(), It.IsAny<Implementation>());
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
