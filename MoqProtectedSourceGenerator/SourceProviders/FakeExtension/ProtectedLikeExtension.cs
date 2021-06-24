﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikeExtension : IProtectedLikeExtensions
    {
        private readonly List<Diagnostic> diagnostics = new();
        private static readonly List<string> defaultUsings = new()
        {
            "System.Collections.Generic",
            "System.Linq.Expressions",
            "Moq",
            "Moq.Protected",
            "MoqProtectedTyped"
        };
        private List<string> usings;
        private readonly IProtectedLike protectedLike;
        private readonly IEnumerable<IProtectedLikeExtensionSource> sources;
        private readonly IMethodExtensionMethods methodExtensionMethods;
        private readonly IGlobalClassFromOptions globalClassFromOptions;
        private readonly List<string> methodNames;

        public ProtectedLikeExtension(
            IProtectedLike protectedLike,
            IEnumerable<IProtectedLikeExtensionSource> sources,
            IMethodExtensionMethods methodExtensionMethods,
            IGlobalClassFromOptions globalClassFromOptions
            )
        {
            this.protectedLike = protectedLike;
            this.sources = sources;
            this.methodExtensionMethods = methodExtensionMethods;
            this.globalClassFromOptions = globalClassFromOptions;
            methodExtensionMethods.Initialize(protectedLike.Methods);
            methodNames = protectedLike.Methods.Select(m => m.Declaration.Identifier.Text).ToList();
            InitializeUsings();
        }

        private void InitializeUsings()
        {
            usings = new List<string>(defaultUsings);
            foreach (var methodDetails in protectedLike.Methods)
            {
                usings.AddRange(methodDetails.UniqueNamespaces.Select(ns => ns.FullNamespace()));
            }
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            var (source, className) = GetSource(context.AnalyzerConfigOptions);
            context.AddSource($"{className}.cs", source);
            AddCommonSources(context);
            ReportDiagnostics(context);
        }

        private (string source, string className) GetSource(AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var likeTypeName = protectedLike.MinimallyUniqueLikeTypeName();
            var mockedTypeName = protectedLike.MockedType.FullyQualifiedTypeName();
            var className = $"{likeTypeName}_FakeExtension";

            var methodExtensionMethodsSource = methodExtensionMethods.GetExtensionMethods(mockedTypeName, likeTypeName);
            var methodSetups = methodExtensionMethods.Setups;
            diagnostics.AddRange(methodExtensionMethods.Diagnostics);

            string usings = GetUsings(methodExtensionMethods.ExtensionsUsingsByFilePath);
            var extensionClass = GetExtensionClass(className, methodSetups, methodExtensionMethodsSource);
            var source = globalClassFromOptions.Get(usings, extensionClass, analyzerConfigOptions);

            return (source, className);
        }

        private string GetDictionary(List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setups)
        {
            return @$"    private static readonly Dictionary<string, List<ParameterInfo>> Setups =
        new Dictionary<string, List<ParameterInfo>>{GetSetupsInitializer(setups)};";
        }

        private string FilePathAndLine(FileLocation fileLocation)
        {
            return "@\"" + $"{fileLocation.FilePath}_{fileLocation.Line + 1}" + "\"";
        }

        private string GetSetupsInitializer(List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setups)
        {
            if (setups.Count == 0)
            {
                return "{}";
            }
            var dictionaryEntryStringBuilder = new StringBuilder();
            dictionaryEntryStringBuilder.AggregateAppendIfLast(setups, (setUpOrVerification, append, isLast) =>
            {
                var comma = isLast ? "" : ",";
                append(@$"            {{
                {FilePathAndLine(setUpOrVerification.fileLocation)},
                {ParameterInfo.SourceList(setUpOrVerification.parameterInfos)}
            }}{comma}");
            });

            return @$"
        {{
{dictionaryEntryStringBuilder}
        }}";
        }

        private string GetExtensionClass(string className, List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> setups, string extensionMethods)
        {
            return
$@"public static class {className}
{{
{GetDictionary(setups)}

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {{
        return sourceFileInfo + ""_"" + sourceLineNumber;
    }}

{extensionMethods}
}}";
        }

        private string GetUsings(Dictionary<string, SyntaxList<UsingDirectiveSyntax>> extensionsUsingsByFilePath)
        {
            List<string> aliases = new List<string>();
            foreach (var kvp in extensionsUsingsByFilePath)
            {
                foreach (var @using in kvp.Value)
                {
                    var usingName = @using.Name.ToString();
                    var alias = @using.Alias;
                    if (alias != null)
                    {
                        aliases.Add(@using.ToString());
                    }
                    else
                    {
                        usings.Add(usingName);
                    }
                }
            }

            var regularUsings = SourceHelper.CreateUsingsFromNamespaces(usings);

            if (aliases.Count == 0)
            {
                return regularUsings;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(regularUsings);
            foreach (var alias in aliases)
            {
                stringBuilder.AppendLine(alias);
            }
            var result = stringBuilder.ToString();
            return result;
        }

        private void AddCommonSources(GeneratorExecutionContext context)
        {
            foreach (var source in sources)
            {
                source.AddSource(context);
            }
        }

        private void ReportDiagnostics(GeneratorExecutionContext context)
        {
            foreach (var diagnostic in diagnostics)
            {
                context.ReportDiagnostic(diagnostic);
            }
        }

        public void ExtensionInvocation(InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, GeneratorExecutionContext context)
        {
            if (methodNames.Contains(extensionName))
            {
                methodExtensionMethods.MethodInvocation(invocation, extensionName, semanticModel);
            }
        }

    }
}
