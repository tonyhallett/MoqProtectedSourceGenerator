using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IExecutingVisitingSourceProvider))]
    public class ProtectedLikeSourceProvider : IExecutingVisitingSourceProvider
    {
        private readonly IProtectedMock protectedTypeIdentifier;
        private readonly IProtectedLikes protectedLikes;
        private readonly Dictionary<string, IProtectedLike> protectedLikeSources = new();
        private GeneratorExecutionContext context;
        private SemanticModel semanticModel;

        [ImportingConstructor]
        public ProtectedLikeSourceProvider(IProtectedLikes protectedLikes, IProtectedMock protectedTypeIdentifier)
        {
            this.protectedLikes = protectedLikes;
            this.protectedTypeIdentifier = protectedTypeIdentifier;
        }

        private IEnumerable<INamespaceSymbol> GetUniqueNamespaces(IProtectedLike protectedLike)
        {
            return protectedLike.Methods.SelectMany(m => m.UniqueNamespaces)
                .Concat(protectedLike.Properties.SelectMany(p => p.UniqueNamespaces))
                .Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default);
        }

        private void GenerateProtectedLikeIfProtected(TypeSyntax mockedType, SemanticModel semanticModel)
        {
            var mockedTypeSymbolInfo = semanticModel.GetSymbolInfo(mockedType);

            if (mockedTypeSymbolInfo.Symbol is ITypeSymbol mockedTypeSymbol && !protectedLikeSources.ContainsKey(mockedTypeSymbol.FullyQualifiedTypeName()))
            {
                var protectedLike = protectedLikes.GetProtectedLikeIfApplicable(mockedTypeSymbol);
                if (protectedLike != null)
                {
                    protectedLikeSources.Add(mockedTypeSymbol.FullyQualifiedTypeName(), protectedLike);
                }
            }

        }

        public void Executing(GeneratorExecutionContext context)
        {
            protectedLikeSources.Clear();

            this.context = context;
        }

        public void AddSource()
        {
            foreach (var kvp in protectedLikeSources)
            {
                var protectedLike = kvp.Value;
                var likeTypeName = protectedLike.MinimallyUniqueLikeTypeName();
                var source = SourceHelper.Create(
                        SourceHelper.CreateUsings(GetUniqueNamespaces(protectedLike)),
                        SourceHelper.CreateInternalInterface(
                            likeTypeName,
                            SourceHelper.CreateMembers(protectedLike.Properties.Select(p => p.Declaration), protectedLike.Methods.Select(m => m.Declaration))
                        )
                    );
                context.AddSource($"{likeTypeName}.cs", source);
            }
        }

        public void OnVisitTree(SyntaxTree syntaxTree)
        {
            semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
        }

        public void OnVisitSyntaxNode(SyntaxNode node)
        {
            var mockedType = protectedTypeIdentifier.GetMockedType(node);
            if (mockedType != null)
            {
                GenerateProtectedLikeIfProtected(mockedType, semanticModel);
            }
        }
    }

}
