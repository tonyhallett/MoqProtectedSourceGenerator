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
        private readonly IProtectedLikes protectedLikes;
        private readonly IEnumerable<IProtectedLikeCreationDependent> protectedLikeCreationDependents;
        private readonly Dictionary<string, IProtectedLike> protectedLikeSources = new();
        private GeneratorExecutionContext context;
        private SemanticModel semanticModel;

        [ImportingConstructor]
        public ProtectedLikeSourceProvider(
            IProtectedLikes protectedLikes,
            [ImportMany] IEnumerable<IProtectedLikeCreationDependent> protectedLikeCreationDependents
        )
        {
            this.protectedLikes = protectedLikes;
            this.protectedLikeCreationDependents = protectedLikeCreationDependents;
        }

        private IEnumerable<INamespaceSymbol> GetUniqueNamespaces(IProtectedLike protectedLike)
        {
            return protectedLike.Methods.SelectMany(m => m.UniqueNamespaces)
                .Concat(protectedLike.Properties.SelectMany(p => p.UniqueNamespaces))
                .Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default);
        }

        private void GenerateProtectedLikeIfProtected(TypeSyntax mockedType)
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
                        SourceHelper.CreateUsingsFromNamespaces(GetUniqueNamespaces(protectedLike)),
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
            TypeSyntax mockedType = null;
            foreach (var protectedLikeCreationDependent in protectedLikeCreationDependents)
            {
                mockedType = protectedLikeCreationDependent.GetMockedType(node);
                if (mockedType != null)
                {
                    break;
                }
            }
            if (mockedType != null)
            {
                GenerateProtectedLikeIfProtected(mockedType);
            }
        }
    }

}
