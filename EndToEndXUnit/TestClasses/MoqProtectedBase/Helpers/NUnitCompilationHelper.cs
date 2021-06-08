using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace EndToEndTests
{
    public static class NUnitCompilationHelper
    {
        public static void CopyNunitFramework(string emitFolder)
        {
            DllsDirectory.CopyDllToDirectory(emitFolder, "nunit.framework.dll");
        }
        public static Compilation CreateCompilation(string source, params MetadataReference[] additionalMetadatReferences)
        {
            var assemblyNames = new string[]
            {
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51",
                "System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                "System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e",
                "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
            };
            var nUnitFrameworkMetadataReference = MetadataReference.CreateFromFile(DllsDirectory.GetDllPath("nunit.framework.dll"));
            var metadataReferences = new MetadataReference[] { nUnitFrameworkMetadataReference }.Concat(assemblyNames.Select(n => MetadataReferenceHelper.CreateFromAssemblyLoad(n))).Concat(additionalMetadatReferences);
            return
                CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                metadataReferences,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }
    }
}
