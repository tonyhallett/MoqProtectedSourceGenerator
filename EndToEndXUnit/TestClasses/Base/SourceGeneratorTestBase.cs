using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace EndToEndTests
{
    public abstract class SourceGeneratorTestBase : NUnitCompilationTestBase
    {
        protected bool debugOutputCompilation = false;
        protected abstract ISourceGenerator SourceGenerator { get; }
        
        protected sealed override Compilation CreateCompilation()
        {
            return ExecuteGenerator();
        }
        
        protected abstract Compilation CreateInputCompilation();

        private void DebugOutput(Compilation compilation)
        {
            if (debugOutputCompilation)
            {
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    Debug.WriteLine(syntaxTree.FilePath);
                    Debug.WriteLine("----------------------------");
                    Debug.Write(syntaxTree.GetText().ToString());
                    Debug.WriteLine("****************************");
                }
            }
        }
        
        private Compilation ExecuteGenerator()
        {
            CreateDriver().RunGeneratorsAndUpdateCompilation(CreateInputCompilation(), out var outputCompilation, out var diagnostics);

            Assert.True(diagnostics.IsEmpty, "Generator has diagnostics");

            DebugOutput(outputCompilation);

            return outputCompilation;
        }

        private GeneratorDriver CreateDriver()
        {
            return CSharpGeneratorDriver.Create(SourceGenerator);
        }
    }
}
