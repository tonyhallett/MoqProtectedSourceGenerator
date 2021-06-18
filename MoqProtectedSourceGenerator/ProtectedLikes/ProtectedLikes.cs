using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikes))]
    public class ProtectedLikes : IProtectedLikes
    {
        private const string FullyQualifiedSeparator = "_";
        private readonly List<ProtectedLike> protectedLikes = new();
        private readonly Dictionary<ProtectedLike,string> minimallyUniqueLikeTypeNames = new();

        public event Action<IProtectedLike> NewLikeEvent;

        public class ProtectedLike : IProtectedLike
        {
            private readonly ProtectedLikes protectedLikes;
            

            public ProtectedLike(ProtectedLikes protectedLikes)
            {
                this.protectedLikes = protectedLikes;
            }
            public List<ProtectedLikeMethodDetails> Methods { get; set; }
            public List<PropertyDetails> Properties { get; set; } = new();
            public ITypeSymbol MockedType { get; set; }

            public string MinimallyUniqueLikeTypeName()
            {
                return protectedLikes.MinimallyUniqueLikeTypeName(this);
            }

        }

        private List<IMethodSymbol> GetApplicableMethods(ITypeSymbol mockedType)
        {
            var methods = mockedType.GetMembers().OfType<IMethodSymbol>();
            return methods.Where(m => m.IsProtected() && (m.IsAbstract || m.IsVirtual)).ToList();
        }

        public IProtectedLike GetProtectedLikeIfApplicable(ITypeSymbol mockedType)
        {
            if (IsCandidateType(mockedType))
            {
                //includes accessors
                var applicableMethods = GetApplicableMethods(mockedType);
                if (applicableMethods.Count > 0)
                {
                    var protectedLike = Generate(mockedType, applicableMethods);
                    protectedLikes.Add(protectedLike);
                    NewLikeEvent?.Invoke(protectedLike);
                    return protectedLike;
                }
            }
            return null;
        }

        private ProtectedLike Generate(ITypeSymbol mockedType, List<IMethodSymbol> applicableMockedTypeMethods)
        {
            var protectedLike = new ProtectedLike(this)
            {
                MockedType = mockedType
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

        private string MinimallyUniqueLikeTypeName(ProtectedLike protectedLike)
        {
            if (minimallyUniqueLikeTypeNames.Count == 0)
            {
                GenerateMinimallyUniqueLikeTypeNames();
            }
            return minimallyUniqueLikeTypeNames[protectedLike];
        }
        private string GetLikeTypeName(string simpleMockTypeName)
        {
            return simpleMockTypeName + "Like";
        }
        private void GenerateMinimallyUniqueLikeTypeNames()
        {
            var groupedByName = protectedLikes.GroupBy(l => l.MockedType.Name);
            foreach (var group in groupedByName)
            {
                if (group.Count() == 1)
                {
                    var mockTypeName = group.Key;
                    minimallyUniqueLikeTypeNames.Add(group.First(), GetLikeTypeName(mockTypeName));
                }
                else
                {
                    foreach (var protectedLike in group)
                    {
                        var mockedType = protectedLike.MockedType;
                        
                        var suffix = $"{FullyQualifiedSeparator}{ mockedType.ContainingNamespace.JoinNamespaces(FullyQualifiedSeparator)}";
                        var likeTypeName = $"{GetLikeTypeName(mockedType.Name)}{suffix}";

                        minimallyUniqueLikeTypeNames.Add(protectedLike, likeTypeName);
                    }
                }
            }
        }

        private bool IsCandidateType(ITypeSymbol mockedType)
        {
            return mockedType.TypeKind == TypeKind.Class && !mockedType.IsSealed;
        }

    }

}
