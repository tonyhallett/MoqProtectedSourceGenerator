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

        public string MethodBuilderType(string mockedTypeName, string returnType, IEnumerable<string> typeParameters)
        {
            return GetType("ReturningBuilder", mockedTypeName, returnType, typeParameters);
        }

        public string SetupTyped(string mockedTypeName, string returnType, IEnumerable<string> typeParameters)
        {
            return GetType("SetupTypedResult", mockedTypeName,returnType, typeParameters);
        }

        private string GetType(string type, string mockedTypeName, string returnType, IEnumerable<string> typeParameters)
        {
            var stringBuilder = new StringBuilder($"{type}<{mockedTypeName},");
            var hasTypeParameters = false;
            var first = true;
            foreach (var typeParameter in typeParameters)
            {
                hasTypeParameters = true;
                if (first)
                {
                    first = false;
                }
                else
                {
                    stringBuilder.Append(",");
                }
                stringBuilder.Append(typeParameter);
            }
            if (hasTypeParameters)
            {
                stringBuilder.Append(",");
            }
            stringBuilder.Append($"{returnType}>");
            return stringBuilder.ToString();
        }
    }
}
