using MoqProtectedTyped;

namespace MoqProtectedGenerated
{
    public interface INonIndexerFluentGetSet<T, TProperty> : INonIndexerFluentGet<T, TProperty>, INonIndexerFluentSet<T, TProperty> where T : class
    {
        // if generate types in the code generator this could be an option - return ProtectedMock or Mock
        // although ProtectedMock.Mock
        ProtectedMock<T> SetupProperty(TProperty initialValue = default(TProperty));
    }
}
