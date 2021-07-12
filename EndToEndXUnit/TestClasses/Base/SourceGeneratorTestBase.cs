using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace EndToEndTests
{
    public abstract class SourceGeneratorTestBase : NUnitCompilationTestBase
    {
        protected bool logOutputCompilation = false;
        protected abstract ISourceGenerator SourceGenerator { get; }
        
        protected sealed override Compilation CreateCompilation()
        {
            return ExecuteGenerator();
        }
        
        protected abstract Compilation CreateInputCompilation();

        private void LogOutputCompilation(Compilation compilation)
        {
            if (logOutputCompilation)
            {
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    Log(syntaxTree.FilePath);
                    Log("----------------------------");
                    Log(syntaxTree.GetText().ToString());
                    Log("****************************");
                }
            }
        }
        
        private Compilation ExecuteGenerator()
        {
            CreateDriver().RunGeneratorsAndUpdateCompilation(CreateInputCompilation(), out var outputCompilation, out var diagnostics);

            Assert.True(diagnostics.IsEmpty, "Generator has diagnostics");

            LogOutputCompilation(outputCompilation);

            return outputCompilation;
        }

        private GeneratorDriver CreateDriver()
        {
            return CSharpGeneratorDriver.Create(SourceGenerator);
        }
    }
}
