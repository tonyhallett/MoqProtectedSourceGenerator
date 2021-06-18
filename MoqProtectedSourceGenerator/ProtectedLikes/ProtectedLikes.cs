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
        private readonly IProtectedLikeFactory protectedLikeFactory;

        public event Action<IProtectedLike> NewLikeEvent;

        private bool IsCandidateType(ITypeSymbol mockedType)
        {
            return mockedType.TypeKind == TypeKind.Class && !mockedType.IsSealed;
        }

        private List<IMethodSymbol> GetApplicableMethods(ITypeSymbol mockedType)
        {
            var methods = mockedType.GetMembers().OfType<IMethodSymbol>();
            return methods.Where(m => m.IsProtected() && (m.IsAbstract || m.IsVirtual)).ToList();
        }

        [ImportingConstructor]
        public ProtectedLikes(IProtectedLikeFactory protectedLikeFactory)
        {
            this.protectedLikeFactory = protectedLikeFactory;
        }
        public IProtectedLike GetProtectedLikeIfApplicable(ITypeSymbol mockedType)
        {
            if (IsCandidateType(mockedType))
            {
                //includes accessors
                var applicableMethods = GetApplicableMethods(mockedType);
                if (applicableMethods.Count > 0)
                {
                    var protectedLike = protectedLikeFactory.Generate(mockedType, applicableMethods);
                    NewLikeEvent?.Invoke(protectedLike);
                    return protectedLike;
                }
            }
            return null;
        }

    }

}
