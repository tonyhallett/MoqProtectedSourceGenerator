using System;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IProtectedLikes : IExecuteAware
    {
        event Action<IProtectedLike> NewLikeEvent;
        IProtectedLike GetProtectedLikeIfApplicable(ITypeSymbol mockedType);
    }

}
