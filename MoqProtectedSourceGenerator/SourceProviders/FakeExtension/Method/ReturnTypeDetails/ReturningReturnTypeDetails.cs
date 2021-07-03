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
            if(returnType == "Task")
            {
                return $"{type}Task<{mockedTypeName},{delegates}>";
            }
            else if (returnType.StartsWith("ValueTask<"))
            {
                var valueTaskResultType = ExtractResultType(returnType);
                return $"{type}ValueTask<{mockedTypeName},{valueTaskResultType},{delegates}>";
            }
            else if (returnType.StartsWith("Task<"))
            {
                var taskResultType = ExtractResultType(returnType);
                return $"{type}TaskResult<{mockedTypeName},{taskResultType},{delegates}>";
            }
            return $"{type}<{mockedTypeName},{returnType},{delegates}>";
        }

        private string ExtractResultType(string genericType)
        {
            var leftBracketIndex = genericType.IndexOf("<");
            var extracted = genericType.Substring(leftBracketIndex+1, genericType.Length - leftBracketIndex -2);
            return extracted;
        }
    }
}
