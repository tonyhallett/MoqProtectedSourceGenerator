using System.Collections.Generic;

namespace MoqProtectedSourceGenerator
{
    public interface IReturnTypeDetails
    {
        string ExpressionDelegate(string likeTypeName, string returnType);
        string MethodBuilderType(string mockedTypeName, string returnType, IEnumerable<string> typeParameters);
        string SetupTyped(string mockedTypeName, string returnType, IEnumerable<string> typeParameters);
    }
}
