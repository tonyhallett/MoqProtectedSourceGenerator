using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public interface IFakeExtensionMethodClass
    {
        void AddSource(GeneratorExecutionContext context);
        void AddSetupOrVerify(bool isSetup, ArgumentListSyntax arguments, FileLocation fileLocation);

    }
}