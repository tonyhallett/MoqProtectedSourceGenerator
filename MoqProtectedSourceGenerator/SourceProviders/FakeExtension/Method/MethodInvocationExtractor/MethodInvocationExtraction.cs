using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class MethodInvocationExtraction
    {
        public FileLocation FileLocation { get; set; }

        public Diagnostic Diagnostic { get; set; }
        public bool Success { get; set; }
    }
}
