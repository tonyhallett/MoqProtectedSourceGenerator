using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class BuildSetupOrVerify
    {
        public bool IsSetup { get; set; }
        public FileLocation FileLocation { get; set; }

        public Diagnostic Diagnostic { get; set; }
        public bool Success { get; set; }
    }
}
