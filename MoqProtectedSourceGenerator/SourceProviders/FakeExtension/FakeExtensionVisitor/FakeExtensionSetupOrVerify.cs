using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class FakeExtensionSetupOrVerify
    {
        public bool IsSetup { get; set; }
        public ITypeSymbol MockedType { get; set; }
        public ExtensionMethod ExtensionMethod { get; set; }
        public FileLocation FileLocation { get; set; }

    }
}