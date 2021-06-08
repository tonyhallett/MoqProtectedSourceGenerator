using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikes
    {
        public event Action<ProtectedLike> NewLikeEvent;
        public readonly List<ProtectedLike> ProtectedLikesList = new();

        private bool IsCandidateType(ITypeSymbol mockedType)
        {
            return mockedType.TypeKind == TypeKind.Class && !mockedType.IsSealed;
        }

        private List<IMethodSymbol> GetApplicableMethods(ITypeSymbol mockedType)
        {
            var methods = mockedType.GetMembers().OfType<IMethodSymbol>();
            return methods.Where(m => m.IsProtected() && (m.IsAbstract || m.IsVirtual)).ToList();
        }

        public ProtectedLike TryGetProtectedLike(ITypeSymbol mockedType)
        {
            if (IsCandidateType(mockedType))
            {
                var applicableMethods = GetApplicableMethods(mockedType);
                if (applicableMethods.Count > 0)
                {
                    var protectedLike = new ProtectedLike();
                    protectedLike.Generate(mockedType, applicableMethods);
                    ProtectedLikesList.Add(protectedLike);
                    NewLikeEvent?.Invoke(protectedLike);
                    return protectedLike;
                }
            }
            return null;
        }

    }

}
