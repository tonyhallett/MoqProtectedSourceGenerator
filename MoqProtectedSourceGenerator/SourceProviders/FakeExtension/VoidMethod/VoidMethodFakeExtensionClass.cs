using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public class VoidMethodFakeExtensionClass : IFakeExtensionMethodClass
    {
        private static readonly List<string> defaultNamespaces = new()
        {
            "System",
            "System.Collections.Generic",
            "System.Linq.Expressions",
            "Moq",
            "Moq.Protected",
        };
        
        private readonly List<(ArgumentListSyntax arguments, FileLocation fileLocation)> setups = new();
        private readonly List<(ArgumentListSyntax arguments, FileLocation fileLocation)> verifications = new();
        private readonly string extensionMethodSignature;
        private readonly string likeTypeName;
        private readonly string mockedTypeName;
        private readonly string methodName;
        private readonly string uniqueMethodName;
        private readonly string className;
        private readonly List<string> namespaces;
        
        private bool isGlobal;

        public VoidMethodFakeExtensionClass(string likeTypeName, string mockedTypeName, INamespaceSymbol mockedTypeNamespace, MethodDetails methodDetails)
        {
            this.likeTypeName = likeTypeName;
            this.mockedTypeName = mockedTypeName;
            var methodDeclaration = methodDetails.Declaration;
            methodName = methodDeclaration.Identifier.Text;
            //for now
            uniqueMethodName = methodName;
            className = $"{mockedTypeName}_{uniqueMethodName}";

            var MethodNamespaces = methodDetails.UniqueNamespaces.Select(ns => ns.FullNamespace()).ToList();
            namespaces = defaultNamespaces.Concat(MethodNamespaces).ToList();
            namespaces.Add(mockedTypeNamespace.FullNamespace());

            var extensionMethod = methodDeclaration.MakeExtension($"Mock<{mockedTypeName}>", "mock")
                .WithReturnType(SyntaxFactory.ParseTypeName($"IVoidMethodBuilder<{mockedTypeName}>"))
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
        }

        private string FilePathAndLine(FileLocation fileLocation)
        {
            return "@\"" + $"{fileLocation.FilePath}_{fileLocation.Line + 1}" + "\"";
        }

        private string LambdaExpression(ArgumentListSyntax arguments)
        {
            return $"like => like.{methodName}{arguments.ToFullString()}";
        }

        private string GetSetupsInitializer()
        {
            return GetSetupsOrVerificationsInitializer(setups);
        }

        private string GetVerificationsInitializer()
        {
            return GetSetupsOrVerificationsInitializer(verifications);
        }

        private string GetSetupsOrVerificationsInitializer(List<(ArgumentListSyntax arguments, FileLocation fileLocation)> setupsOrVerifications)
        {
            var numSetupsOrVerifications = setupsOrVerifications.Count;
            if (numSetupsOrVerifications == 0)
            {
                return "{}";
            }
            var dictionaryEntryStringBuilder = new StringBuilder();
            dictionaryEntryStringBuilder.AggregateAppendIfLast(setupsOrVerifications, (setUpOrVerification, append, isLast) =>
             {
                 var comma = isLast ? "" : ",";
                 append(@$"            {{
                {FilePathAndLine(setUpOrVerification.fileLocation)},
                {LambdaExpression(setUpOrVerification.arguments)}
            }}{comma}");
             });
            
            return @$"
        {{
{dictionaryEntryStringBuilder}
        }}";
        }

        private string WithNamespace(string extensionClass)
        {
            if (!isGlobal)
            {
                return $@"namespace {MoqProtectedGenerated.NamespaceName}
{{
{extensionClass}
}}";
            }
            else
            {
                return extensionClass;
            }
        }
        
        private string GetExtensionClass()
        {
            var extensionClass = 
$@"public static class {className}
{{
    private static readonly Dictionary<string, Expression<Action<{likeTypeName}>>> Setups =
        new Dictionary<string, Expression<Action<{likeTypeName}>>>{GetSetupsInitializer()};
    private static readonly Dictionary<string, Expression<Action<{likeTypeName}>>> Verifications =
        new Dictionary<string, Expression<Action<{likeTypeName}>>>{GetVerificationsInitializer()};

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {{
        return sourceFileInfo + ""_"" + sourceLineNumber;
    }}

    {extensionMethodSignature}
    {{
        return new VoidMethodBuilder<{mockedTypeName}>(
            (sourceFileInfo, sourceLineNumber) => mock.Protected().As<{likeTypeName}>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<{likeTypeName}>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
        );
    }}
}}";
            if (isGlobal)
            {
                return extensionClass;
            }

            return extensionClass.PrefixEachLine("    ");
        }

        private string GetUsings()
        {
            if (isGlobal)
            {
                namespaces.Add(MoqProtectedGenerated.NamespaceName);
            }
            return SourceHelper.CreateUsings(namespaces);
        }

        private string GetSource()
        {
            string usings = GetUsings();
            string extensionClassAndNamespace = WithNamespace(GetExtensionClass());
            return 
@$"{usings}
{extensionClassAndNamespace}
";
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            isGlobal = IsGlobalExtensionClass(context.AnalyzerConfigOptions);
            var source = GetSource();
            context.AddSource($"{className}.cs", source);
        }
        
        private bool IsGlobalExtensionClass(AnalyzerConfigOptionsProvider configOptionProvider)
        {
            var globalExtensionsOption = new Option<bool> { Key = $"{nameof(MoqProtectedSourceGenerator)}_GlobalExtensions", Value = true };
            configOptionProvider.GlobalOptions.GetOption(globalExtensionsOption);
            return globalExtensionsOption.Value;
        }

        public void AddSetupOrVerify(bool isSetup, ArgumentListSyntax arguments, FileLocation fileLocation)
        {
            var setupsOrVerifications = isSetup ? setups : verifications;
            setupsOrVerifications.Add((arguments, fileLocation));
        }
    
    }
}
