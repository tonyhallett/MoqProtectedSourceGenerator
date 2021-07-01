using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public class VoidReturnTypeDetails : IReturnTypeDetails
    {
        public string ExpressionDelegate(string likeTypeName, string returnType)
        {
            return $"Action<{likeTypeName}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType, IEnumerable<string> typeParameters)
        {
            return GetType("VoidBuilder",mockedTypeName,typeParameters);
        }

        public string SetupTyped(string mockedTypeName, string returnType, IEnumerable<string> typeParameters)
        {
            return GetType("SetupTyped", mockedTypeName, typeParameters);
        }

        private string GetType(string type,string mockedTypeName, IEnumerable<string> typeParameters)
        {
            var stringBuilder = new StringBuilder($"{type}<{mockedTypeName}");
            foreach (var typeParameter in typeParameters)
            {
                stringBuilder.Append(",");

                stringBuilder.Append(typeParameter);
            }

            stringBuilder.Append($">");
            return stringBuilder.ToString();
        }

    }
}
