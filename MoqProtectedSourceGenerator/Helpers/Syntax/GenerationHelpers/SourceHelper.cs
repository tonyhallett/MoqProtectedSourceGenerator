using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public static class SourceHelper
    {
        public static string CreateDistinctUsingsFromNamespaces(IEnumerable<INamespaceSymbol> namespaceSymbols)
        {
            var namespaces = namespaceSymbols.Select(ns => ns.FullNamespace()).OrderBy(s => s);
            return CreateDistinctUsingsFromNamespaces(namespaces);
        }

        public static string CreateDistinctUsingsFromNamespaces(IEnumerable<string> namespaces)
        {
            namespaces = namespaces.OrderBy(s => s).Distinct();
            var usingsStringBuilder = new StringBuilder();
            foreach (var ns in namespaces)
            {
                usingsStringBuilder.AppendLine($"using {ns};");
            }
            return usingsStringBuilder.ToString();
        }

        public static string JoinUsings(IEnumerable<string> usings)
        {
            var usingsStringBuilder = new StringBuilder();
            foreach (var @using in usings)
            {
                usingsStringBuilder.AppendLine(@using);
            }
            return usingsStringBuilder.ToString();
        }

        public static string CreateInternalInterface(string name, string members, string prepend = "    ")
        {
            return
@$"{prepend}internal interface {name}{{
{members}
    }}";
        }

        public static string CreateMembers(IEnumerable<BasePropertyDeclarationSyntax> properties, IEnumerable<MethodDeclarationSyntax> methods, string prepend = "        ")
        {
            var memberDeclarations = ((IEnumerable<MemberDeclarationSyntax>)properties).Concat(methods).ToList();

            var memberBuilder = new StringBuilder();
            memberBuilder.AggregateAppendIfLast(memberDeclarations, (memberDecaration, append, _) =>
             {
                 append(prepend + memberDecaration.NormalizeWhitespace().ToFullString());
             });

            return memberBuilder.ToString();
        }

        public static string Create(IEnumerable<string> usings, string types)
        {
            return Create(JoinUsings(usings), types);
        }

        public static string Create(string usings, string types)
        {

            var source = $@"{usings}
namespace {MoqProtectedGenerated.NamespaceName}
{{
{types}
}}";
            return source;
        }

    }
}
