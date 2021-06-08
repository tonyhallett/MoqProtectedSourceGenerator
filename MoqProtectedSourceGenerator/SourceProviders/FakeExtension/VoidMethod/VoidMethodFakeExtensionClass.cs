using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using MoqProtectedSourceGenerator.Helpers.GenerationHelpers;

namespace MoqProtectedSourceGenerator
{
    public class VoidMethodFakeExtensionClass : CSharpSyntaxRewriter, IFakeExtensionMethodClass
    {
        private CompilationUnitSyntax compilationUnitSyntax;
        private readonly string extensionMethodSignature;
        private bool visitingCorrectDictionary = false;
        private bool isSetup;
        private ArgumentListSyntax arguments;
        private FileLocation fileLocation;
        private string LikeTypeName { get; }
        private string MockedTypeName { get; }
        private INamespaceSymbol MockedTypeNamespace { get; }
        private MethodDeclarationSyntax Method { get; }
        private List<string> MethodNamespaces { get; set; }

        public VoidMethodFakeExtensionClass(string likeTypeName, string mockedTypeName, INamespaceSymbol mockedTypeNamespace, MethodDetails methodDetails)
        {
            LikeTypeName = likeTypeName;
            MockedTypeName = mockedTypeName;
            MockedTypeNamespace = mockedTypeNamespace;
            Method = methodDetails.Declaration;


            MethodNamespaces = methodDetails.UniqueNamespaces.Select(ns => ns.FullNamespace()).ToList();

            var extensionMethod = Method.MakeExtension($"Mock<{MockedTypeName}>", "mock")
                .WithReturnType(SyntaxFactory.ParseTypeName($"IVoidMethodBuilder<{MockedTypeName}>"))
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None))
                .WithModifiers(
                    new SyntaxTokenList(
                        new SyntaxToken[]{
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                            SyntaxFactory.Token(SyntaxKind.StaticKeyword)
                        }
                    )
                ).NormalizeWhitespace();
            extensionMethodSignature = extensionMethod.ToFullString();
            GenerateSyntax();
        }

        private string FilePathAndLine()
        {
            return "@\"" + $"{fileLocation.FilePath}_{fileLocation.Line + 1}" + "\"";
        }

        private string LambdaExpression()
        {
            return $"like => like.{Method.Identifier.Text}{arguments.ToFullString()}";
        }

        private ExpressionSyntax SetupOrVerifyInitializerEntry(bool isFirst)
        {
            var complexInitializerExpression = CSharpSyntaxFactory.ComplexInitializer(FilePathAndLine(), LambdaExpression());
            if (!isFirst)
            {
                complexInitializerExpression = complexInitializerExpression.WithLeadingNewline();
            }

            return complexInitializerExpression;
        }

        public override SyntaxNode VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            return node.AddExpressions(SetupOrVerifyInitializerEntry(node.Expressions.Count == 0));
        }

        public override SyntaxNode VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            var dictionaryName = node.Identifier.Text;
            var requiredDictionaryName = isSetup ? "Setups" : "Verifications";
            visitingCorrectDictionary = dictionaryName == requiredDictionaryName;
            if (visitingCorrectDictionary)
            {
                return base.VisitVariableDeclarator(node);
            }
            return node;

        }

        private string GetUniqueMethodName()
        {
            //for now
            return Method.Identifier.ToString();
        }

        private string GetClassName()
        {
            return $"{MockedTypeName}_{GetUniqueMethodName()}";
        }

        private void GenerateSyntax()
        {
            List<string> requiredUsings = new()
            {
                "System",
                "System.Collections.Generic",
                "System.Linq.Expressions",
                "Moq",
                "Moq.Protected",
                MockedTypeNamespace.FullNamespace()
            };
            var namespaces = requiredUsings.Concat(MethodNamespaces);

            var namespaceBuilder = new StringBuilder();
            foreach (var ns in namespaces)
            {
                namespaceBuilder.AppendLine($"using {ns};");
            }

            compilationUnitSyntax = SyntaxFactory.ParseSyntaxTree(@$"
{namespaceBuilder}
namespace {MoqProtectedGenerated.NamespaceName}{{
	public static class {GetClassName()}
	{{
		private static readonly Dictionary<string, Expression<Action<{LikeTypeName}>>> Setups =
			new Dictionary<string, Expression<Action<{LikeTypeName}>>>
		{{

        }};
        private static readonly Dictionary<string, Expression<Action<{LikeTypeName}>>> Verifications =
            new Dictionary<string, Expression<Action<{LikeTypeName}>>>
            {{
            }};

        private static string GetKey(string sourceFileInfo, int sourceLineNumber)
        {{
            return sourceFileInfo + ""_"" + sourceLineNumber;
        }}
        {extensionMethodSignature}
        {{
            return new VoidMethodBuilder<{MockedTypeName}>(
                (sourceFileInfo, sourceLineNumber) => mock.Protected().As<{LikeTypeName}>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
                (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<{LikeTypeName}>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
            );
        }}
    }}
}}
").GetRoot() as CompilationUnitSyntax;
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            PossiblyMakeGlobal(context.AnalyzerConfigOptions);
            var source = compilationUnitSyntax.ToFullString();
            context.AddSource($"{GetClassName()}.cs", source);
        }
        private void PossiblyMakeGlobal(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            if (IsGlobalExtensionClass(configOptionProvider))
            {
                var namespaceDeclaration = compilationUnitSyntax.Members.OfType<NamespaceDeclarationSyntax>().First();
                var extensionClass = namespaceDeclaration.Members.First().WithLeadingTrivia(SyntaxFactory.ParseLeadingTrivia(Environment.NewLine + Environment.NewLine));
                var generatedUsing = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(MoqProtectedGenerated.NamespaceName)).NormalizeWhitespace();
                compilationUnitSyntax = compilationUnitSyntax.AddUsings(generatedUsing)
                    .WithMembers(SyntaxFactory.SingletonList(extensionClass));

            }
        }
        private bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            var globalExtensionsOption = new Option<bool> { Key = $"{nameof(MoqProtectedSourceGenerator)}_GlobalExtensions", Value = true };
            configOptionProvider.GlobalOptions.GetOption(globalExtensionsOption);
            return globalExtensionsOption.Value;
        }

        public void AddSetupOrVerify(bool isSetup, ArgumentListSyntax arguments, FileLocation fileLocation)
        {
            this.isSetup = isSetup;
            this.arguments = arguments;
            this.fileLocation = fileLocation;
            compilationUnitSyntax = this.VisitCompilationUnit(compilationUnitSyntax) as CompilationUnitSyntax;
        }
    }
}
