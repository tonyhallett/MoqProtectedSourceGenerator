using System;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikes
    {
        event Action<IProtectedLike> NewLikeEvent;
        IProtectedLike GetProtectedLikeIfApplicable(ITypeSymbol mockedType);
    }

}
