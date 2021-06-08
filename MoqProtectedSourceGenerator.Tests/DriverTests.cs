//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Moq;
//using Xunit;

//namespace MoqProtectedSourceGenerator.Tests
//{
//    public class DriverTest
//    {
//        [Fact]
//        public void DriverTestExample()
//        {
//            // Create the 'input' compilation that the generator will act on
//            Compilation inputCompilation = CreateCompilation(@"

//");
//            var inputDiagnostics = inputCompilation.GetDiagnostics();
//            foreach (var d in inputDiagnostics)
//            {
//                Debug.WriteLine(d.GetMessage());
//            }
//            var generator = new MoqProtectedSourceGenerator();

//            // Create the driver that will control the generation, passing in our generator
//            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

//            // Run the generation pass
//            // (Note: the generator driver itself is immutable, and all calls return an updated version of the driver that you should use for subsequent calls)
//            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);

//            // We can now assert things about the resulting compilation:
//            Debug.Assert(diagnostics.IsEmpty); // there were no diagnostics created by the generators
//            Debug.Assert(outputCompilation.SyntaxTrees.Count() == 2); // we have two syntax trees, the original 'user' provided one, and the one added by the generator

//            Debug.Assert(outputCompilation.GetDiagnostics().IsEmpty); // verify the compilation with the added source has no diagnostics

//            // Or we can look at the results directly:
//            GeneratorDriverRunResult runResult = driver.GetRunResult();

//            // The runResult contains the combined results of all generators passed to the driver
//            Debug.Assert(runResult.GeneratedTrees.Length == 1);
//            Debug.Assert(runResult.Diagnostics.IsEmpty);

//            // Or you can access the individual results on a by-generator basis
//            GeneratorRunResult generatorResult = runResult.Results[0];
//            Debug.Assert(generatorResult.Generator == generator);
//            Debug.Assert(generatorResult.Diagnostics.IsEmpty);
//            Debug.Assert(generatorResult.GeneratedSources.Length == 1);
//            Debug.Assert(generatorResult.Exception is null);
//        }

//        /*
//            If doing test of protected type from dll then add
//            MetadataReference.CreateFromFile(protectedDllPath)
//        */
//        private static Compilation CreateCompilation(string source)
//            => CSharpCompilation.Create("compilation",
//                new[] { CSharpSyntaxTree.ParseText(source) },
//                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location),
//                    MetadataReference.CreateFromFile(typeof(Mock).GetTypeInfo().Assembly.Location),
//                    MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51").Location)
//                },
//                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
//    }
//}