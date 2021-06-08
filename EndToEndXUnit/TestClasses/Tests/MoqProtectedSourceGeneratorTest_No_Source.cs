using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Xunit;

namespace EndToEndTests
{
    [Collection("Prevent locking")]
    public class MoqProtectedSourceGeneratorTest_No_Source : MoqProtectedSourceGeneratorTestBase
    {
        private readonly string projectDllDll;
        private readonly string outputFolder;
        private const string ProjectDllDllName = "ProtectedDll.dll";
        public MoqProtectedSourceGeneratorTest_No_Source()
        {
            outputFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            projectDllDll = Path.Combine(outputFolder, ProjectDllDllName);
            Assert.True(File.Exists(projectDllDll));
        }
        protected override string Source => @"
using System;
using IFace;
using Moq;
using NUnit.Framework;
using OtherNamespace;

namespace ClassLibrary1
{
    public class ExpectedException : Exception { }
    public class Implementation : IInterface { }

    public class Test
    {
        [Test]
        public void Generate()
        {
            var mockDll = new Mock<ProtectedDll.DllProtected>();
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
            return new MetadataReference[] { MetadataReference.CreateFromFile(projectDllDll) };

        }

        protected override void CopyAdditionalDlls(string emitFolder)
        {
            FileHelper.CopyFileToDirectory(outputFolder, emitFolder, ProjectDllDllName);
        }

        [Fact]
        public void Execute()
        {
            Test();
        }
    }
}
