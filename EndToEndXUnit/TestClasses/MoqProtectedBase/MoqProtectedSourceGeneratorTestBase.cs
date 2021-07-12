using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace EndToEndTests
{
    public abstract class MoqProtectedSourceGeneratorTestBase : SourceGeneratorTestBase
    {
        private readonly string outputDirectory;
        private const string MoqDll = "Moq.dll";
        protected abstract string Source { get; }
        protected sealed override string EmitFolder { get; set; }
        protected sealed override ISourceGenerator SourceGenerator => new MoqProtectedSourceGenerator.MoqProtectedSourceGenerator();
        
        protected MoqProtectedSourceGeneratorTestBase()
        {
            var testName = this.GetType().Name;

            var projectDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent.FullName;
            var testOutputContainerDirectory = Path.Combine(projectDirectory, "DynamicTests");
            if (!Directory.Exists(testOutputContainerDirectory))
            {
                Directory.CreateDirectory(testOutputContainerDirectory);
            }
            EmitFolder = Path.Combine(testOutputContainerDirectory, testName);
            if (Directory.Exists(EmitFolder))
            {
                Directory.Delete(EmitFolder, true);
            }

            outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
        }

        protected sealed override void CopyDlls(string emitFolder)
        {
            NUnitCompilationHelper.CopyNunitFramework(emitFolder);
            CopyMoq(emitFolder);
            CopyMoqProtectedTyped(emitFolder);
            CopyAdditionalDlls(emitFolder);
        }

        private void CopyMoq(string emitFolder)
        {
            DllsDirectory.CopyDllToDirectory(emitFolder, "Moq.dll");
            DllsDirectory.CopyDllToDirectory(emitFolder, "Castle.Core.dll");
        }

        private void CopyMoqProtectedTyped(string emitFolder)
        {
            FileHelper.CopyFileToDirectory(outputDirectory, emitFolder, "MoqProtectedTyped.dll");
        }

        protected virtual void CopyAdditionalDlls(string emitFolder)
        {

        }

        protected sealed override Compilation CreateInputCompilation()
        {
            var moqMetadataReference = MetadataReference.CreateFromFile(DllsDirectory.GetDllPath(MoqDll));
            var moqProtectedTypedMetadataReference = MetadataReference.CreateFromFile(Path.Combine(outputDirectory, "MoqProtectedTyped.dll"));
            var linqExpressionsReference = MetadataReferenceHelper.CreateFromAssemblyLoad("System.Linq.Expressions, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var linqReference = MetadataReferenceHelper.CreateFromAssemblyLoad("System.Linq, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var systemCollectionsReference = MetadataReferenceHelper.CreateFromAssemblyLoad("System.Collections, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var metadataReferences = new MetadataReference[] { moqMetadataReference, moqProtectedTypedMetadataReference, systemCollectionsReference,linqReference, linqExpressionsReference }.Concat(AdditionalMetadataReferences()).ToArray();
            return NUnitCompilationHelper.CreateCompilation(Source, metadataReferences);
        }

        protected virtual IEnumerable<MetadataReference> AdditionalMetadataReferences()
        {
            return Enumerable.Empty<MetadataReference>();
        }
    }
}
