using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(ISyntaxSourceProvider))]
    public class ProtectedLikeSourceProvider : ISyntaxSourceProvider
    {
        private readonly IProtectedMock protectedTypeIdentifier;
        private readonly IProtectedLikes protectedLikes;
        private readonly Dictionary<string, (string Source, string LikeTypeName)> protectedLikeSources = new();

        [ImportingConstructor]
        public ProtectedLikeSourceProvider(IProtectedLikes protectedLikes, IProtectedMock protectedTypeIdentifier)
        {
            this.protectedLikes = protectedLikes;
            this.protectedTypeIdentifier = protectedTypeIdentifier;
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
            var mockedType = protectedTypeIdentifier.GetMockedType(context.Node);
            if (mockedType != null)
            {
                GenerateProtectedLikeIfProtected(mockedType, context.SemanticModel);
            }
        }

        private IEnumerable<INamespaceSymbol> GetUniqueNamespaces(IProtectedLike protectedLike)
        {
            return protectedLike.Methods.SelectMany(m => m.UniqueNamespaces)
                .Concat(protectedLike.Properties.SelectMany(p => p.UniqueNamespaces))
                .Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default);
        }

        private void GenerateProtectedLikeIfProtected(TypeSyntax mockedType, SemanticModel semanticModel)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(mockedType);

            if (symbolInfo.Symbol is ITypeSymbol typeSymbol && !protectedLikeSources.ContainsKey(typeSymbol.Name))
            {
                var protectedLike = protectedLikes.GetProtectedLikeIfApplicable(typeSymbol);
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
