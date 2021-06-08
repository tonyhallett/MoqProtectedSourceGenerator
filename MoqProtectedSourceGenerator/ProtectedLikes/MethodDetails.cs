using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace MoqProtectedSourceGenerator
{
    public class MethodDetails
    {
        public MethodDetails(IMethodSymbol methodSymbol)
        {
            Declaration = ClassToInterface.TransformMethod(methodSymbol);

            var methodTypes = new List<ITypeSymbol>();
            methodTypes.AddRange(new ITypeSymbol[] { methodSymbol.ReturnType }.Concat(methodSymbol.Parameters.Select(p => p.Type)));
            methodTypes.AddRange(methodSymbol.TypeParameters.SelectMany(tp => tp.ConstraintTypes));
            UniqueNamespaces = methodTypes.Select(t => t.ContainingNamespace).Distinct<INamespaceSymbol>(SymbolEqualityComparer.Default).ToList();

            Symbol = methodSymbol;
        }
        public MethodDeclarationSyntax Declaration { get; set; }
        public IMethodSymbol Symbol { get; set; }
        public List<INamespaceSymbol> UniqueNamespaces { get; set; }
    }

}