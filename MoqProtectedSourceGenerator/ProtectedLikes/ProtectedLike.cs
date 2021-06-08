using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLike
    {
        public List<MethodDetails> Methods;
        public readonly List<PropertyDetails> Properties = new();
        public string LikeTypeName { get; private set; }
        public string MockedTypeName { get; private set; }
        public ITypeSymbol MockedType { get; private set; }
        public INamespaceSymbol MockedTypeNamespace { get; private set; }
        public void Generate(ITypeSymbol mockedType, List<IMethodSymbol> applicableMethods)
        {
            MockedType = mockedType;
            MockedTypeName = mockedType.Name;
            MockedTypeNamespace = mockedType.ContainingNamespace;
            LikeTypeName = MockedTypeName + "Like";
            var grouped = applicableMethods.GroupBy(m => m.AssociatedSymbol, SymbolEqualityComparer.Default).ToList();
            var types = new List<ITypeSymbol>();
            foreach (var group in grouped)
            {
                if (group.Key == null)
                {
                    Methods = group.Select(m => new MethodDetails(m)).ToList();
                }
                else
                {
                    var accessorMethods = group.ToList();
                    Accessors accessors = accessorMethods.Count == 2 ? Accessors.GetSet : accessorMethods[0].MethodKind == MethodKind.PropertyGet ? Accessors.Get : Accessors.Set;

                    var propertySymbol = group.Key as IPropertySymbol;
                    Properties.Add(new PropertyDetails(propertySymbol, accessors));
                }
            }
        }

    }

}