using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class SingleGeneratorDriverTest
    {
        public static ImmutableArray<GeneratedSourceResult> RunTest(Compilation inputCompilation, ISourceGenerator generator)
        {
            Assert.Empty(inputCompilation.GetDiagnostics());

            // Create the driver that will control the generation, passing in our generator
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            // Run the generation pass
            // (Note: the generator driver itself is immutable, and all calls return an updated version of the driver that you should use for subsequent calls)
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);

            // We can now assert things about the resulting compilation:
            Assert.Empty(diagnostics); // there were no diagnostics created by the generators

            // outputCompilation.SyntaxTrees is original and that from the generator
            // can assert number if desired

            // for compilation with added sources
            var outputDiagnostics = outputCompilation.GetDiagnostics();
            // todo reduce the warnings
            AssertionHelpers.NoDiagnosticErrors(outputDiagnostics);

            // Or we can look at the results directly:
            GeneratorDriverRunResult runResult = driver.GetRunResult();

            // The runResult contains the combined results of all generators passed to the driver
            // runResult.GeneratedTrees ........
            //Assert.Empty(runResult.Diagnostics);

            // Or you can access the individual results on a by-generator basis
            GeneratorRunResult generatorResult = runResult.Results[0];
            Assert.Equal(generatorResult.Generator, generator);
            Assert.Empty(generatorResult.Diagnostics);
            Debug.Assert(generatorResult.Exception is null);


            return generatorResult.GeneratedSources;
        }

    }

}