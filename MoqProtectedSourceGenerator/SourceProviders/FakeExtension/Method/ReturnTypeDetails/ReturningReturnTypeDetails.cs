using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public class ReturningReturnTypeDetails : IReturnTypeDetails
    {
        public string ExpressionDelegate(string likeTypeName, string returnType)
        {
            return $"Func<{likeTypeName},{returnType}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType, string delegates)
        {
            return GetType("ReturningBuilder", mockedTypeName, returnType, delegates);
        }

        public string SetupTyped(string mockedTypeName, string returnType, string delegates)
        {
            return GetType("SetupTypedResult", mockedTypeName,returnType, delegates);
        }

        private string GetType(string type, string mockedTypeName, string returnType, string delegates)
        {
            return $"{type}<{mockedTypeName},{returnType},{delegates}>";
        }
    }
}
