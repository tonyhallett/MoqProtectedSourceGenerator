using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeFactory))]
    public class ProtectedLikeFactory : IProtectedLikeFactory
    {
        public class ProtectedLike : IProtectedLike
        {
            public List<ProtectedLikeMethodDetails> Methods { get; set; }
            public List<PropertyDetails> Properties { get; set; }
            public string LikeTypeName { get; set; }
            public string MockedTypeName { get; set; }
            public ITypeSymbol MockedType { get; set; }
            public INamespaceSymbol MockedTypeNamespace { get; set; }
        }
        public IProtectedLike Generate(ITypeSymbol mockedType, List<IMethodSymbol> applicableMockedTypeMethods)
        {
            var protectedLike = new ProtectedLike
            {
                MockedType = mockedType,
                //MockedTypeName = mockedType.Name,
                MockedTypeName = GetFullyQualifiedMockedTypeName(mockedType),
                MockedTypeNamespace = mockedType.ContainingNamespace,
                LikeTypeName = mockedType.Name + "Like",
                Properties = new List<PropertyDetails>()
            };

            var grouped = applicableMockedTypeMethods.GroupBy(m => m.AssociatedSymbol, SymbolEqualityComparer.Default).ToList();
            var types = new List<ITypeSymbol>();
            foreach (var group in grouped)
            {
                if (group.Key == null)
                {
                    protectedLike.Methods = group.Select(m => new ProtectedLikeMethodDetails(m)).ToList();
                }
                else
                {
                    var accessorMethods = group.ToList();
                    Accessors accessors = accessorMethods.Count == 2 ? Accessors.GetSet : accessorMethods[0].MethodKind == MethodKind.PropertyGet ? Accessors.Get : Accessors.Set;

                    var propertySymbol = group.Key as IPropertySymbol;
                    protectedLike.Properties.Add(new PropertyDetails(propertySymbol, accessors));
                }
            }
            return protectedLike;
        }
        private string GetFullyQualifiedMockedTypeName(ITypeSymbol mockedType)
        {
            var fullNamespace = mockedType.ContainingNamespace.FullNamespace();
            if(fullNamespace != "")
            {
                fullNamespace += ".";
            }
            return $"{fullNamespace}{mockedType.Name}";
        }
    }

}
