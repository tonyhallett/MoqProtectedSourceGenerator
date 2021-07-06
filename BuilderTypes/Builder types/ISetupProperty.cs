using MoqProtectedTyped;

namespace MoqProtectedGenerated
{
    public interface ISetupProperty<TMock,TProperty> where TMock:class
    {
        // if generate types in the code generator this could be an option - return ProtectedMock or Mock
        // although ProtectedMock.Mock
        ProtectedMock<TMock> SetupProperty(TProperty initialValue = default(TProperty));
    }
}
