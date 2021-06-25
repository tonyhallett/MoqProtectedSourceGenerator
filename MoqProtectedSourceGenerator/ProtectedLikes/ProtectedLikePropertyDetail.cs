using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikePropertyDetail
    {
        public List<INamespaceSymbol> UniqueNamespaces { get; set; }
        public BasePropertyDeclarationSyntax Declaration { get; set; }
        public IPropertySymbol Symbol { get; set; }
        public ProtectedLikePropertyDetail(IPropertySymbol propertySymbol, Accessors accessors)
        {
            Symbol = propertySymbol;

            SetUniqueNamespaces(propertySymbol);

            Declaration = ClassToInterface.TransformProperty(propertySymbol).WithAccessors(accessors);
        }

        private void SetUniqueNamespaces(IPropertySymbol propertySymbol)
        {
            var types = new List<ITypeSymbol>
            {
                propertySymbol.Type
            };
            if (propertySymbol.IsIndexer)
            {
                types.AddRange(propertySymbol.Parameters.Select(p => p.Type));
            }
            UniqueNamespaces = types.Select(t => t.ContainingNamespace).Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default).ToList();
        }
    }

}
