//using System.Reflection;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.CSharp.Testing;
//using Microsoft.CodeAnalysis.Testing;
//using Microsoft.CodeAnalysis.Testing.Verifiers;
//using Microsoft.CodeAnalysis.Text;
//using Moq;
//using MoqProtectedSourceGenerator;
//using Xunit;

//namespace MoqProtectedSourceGenerator.Tests
//{
//    public class Tests
//    {
//        [Fact]
//        public Task ToDo()
//        {
//            return new CSharpSourceGeneratorTest<MoqProtectedSourceGenerator, XUnitVerifier>
//            {
//                TestState =
//                {
//                    Sources =
//                    {
//                        @"
//",

//                    },
//                    AdditionalReferences = {
//                        MetadataReference.CreateFromFile(typeof(Mock).GetTypeInfo().Assembly.Location)
//                    },
//                    GeneratedSources = {
//                    },
//                    AnalyzerConfigFiles =
//                    {
//                        (@"C:\Users\tonyh\Source\Repos\MoqProtectedSourceGenerator\.globalconfig",SourceText.From(@"
//#is_global = true
//MoqProtectedSourceGenerator_GlobalExtensions = true

//"))
//                    }

//                }
//            }.RunAsync();
//        }

//    }

//}