using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public static class SourceHelper
    {
        public static string CreateUsings(IEnumerable<INamespaceSymbol> namespaceSymbols)
        {
            var namespaces = namespaceSymbols.Select(ns => ns.FullNamespace()).OrderBy(s => s);
            var usingsStringBuilder = new StringBuilder();
            foreach (var ns in namespaces)
            {
                usingsStringBuilder.AppendLine($"using {ns};");
            }
            return usingsStringBuilder.ToString();
        }

        public static string CreateInternalInterface(string name, string members)
        {
            return @$"
    internal interface {name}{{
{members}
    }}
";
        }

        public static string CreateMembers(IEnumerable<BasePropertyDeclarationSyntax> properties, IEnumerable<MethodDeclarationSyntax> methods)
        {
            var memberBuilder = new StringBuilder();
            foreach (var property in properties)
            {
                memberBuilder.AppendLine("\t\t" + property.NormalizeWhitespace().ToFullString());
            }
            foreach (var method in methods)
            {
                memberBuilder.AppendLine("\t\t" + method.NormalizeWhitespace().ToFullString());
            }
            var members = memberBuilder.ToString();
            return members;
        }

        public static string Create(IEnumerable<string> usings, string types)
        {
            var usingsStringBuilder = new StringBuilder();
            foreach (var @using in usings)
            {
                usingsStringBuilder.AppendLine(@using);
            }
            return Create(usingsStringBuilder.ToString(), types);
        }

        public static string Create(string usings, string types)
        {
            return $@"
{usings}
namespace {MoqProtectedGenerated.NamespaceName}
{{
{types}
}}";
        }
    }
}