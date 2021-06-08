using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikeSourceProvider : ISyntaxSourceProvider
    {
        private readonly MoqSyntaxHelper mockSyntaxHelper = new();
        private readonly ProtectedLikes protectedLikes;
        private readonly Dictionary<string, (string Source, string LikeTypeName)> protectedLikeSources = new();

        public ProtectedLikeSourceProvider(ProtectedLikes protectedLikes)
        {
            this.protectedLikes = protectedLikes;
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            foreach (var kvp in protectedLikeSources)
            {
                context.AddSource($"{kvp.Value.LikeTypeName}.cs", kvp.Value.Source);
            }
        }

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            var typeSyntax = mockSyntaxHelper.GetMockedType(context.Node);
            if (typeSyntax != null)
            {
                GenerateProtectedLikeIfProtected(typeSyntax, context.SemanticModel);
            }
        }
        private IEnumerable<INamespaceSymbol> GetUniqueNamespaces(ProtectedLike protectedLike)
        {
            return protectedLike.Methods.SelectMany(m => m.UniqueNamespaces).Concat(protectedLike.Properties.SelectMany(p => p.UniqueNamespaces)).Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default);
        }
        private void GenerateProtectedLikeIfProtected(TypeSyntax type, SemanticModel semanticModel)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(type);

            if (symbolInfo.Symbol is ITypeSymbol typeSymbol && !protectedLikeSources.ContainsKey(typeSymbol.Name))
            {
                var protectedLike = protectedLikes.TryGetProtectedLike(typeSymbol);
                if (protectedLike != null)
                {
                    var source = SourceHelper.Create(
                        SourceHelper.CreateUsings(GetUniqueNamespaces(protectedLike)),
                        SourceHelper.CreateInternalInterface(
                            protectedLike.LikeTypeName,
                            SourceHelper.CreateMembers(protectedLike.Properties.Select(p => p.Declaration), protectedLike.Methods.Select(m => m.Declaration))
                        )
                    );

                    protectedLikeSources.Add(typeSymbol.Name, (source, protectedLike.LikeTypeName));
                }
            }

        }
    }

}
