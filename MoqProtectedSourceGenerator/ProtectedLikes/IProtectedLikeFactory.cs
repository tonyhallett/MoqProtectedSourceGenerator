using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikeFactory
    {
        IProtectedLike Generate(ITypeSymbol mockedType, List<IMethodSymbol> applicableMethods);
    }

}
