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
                var valueTaskResultType = TaskGenericHelper.ExtractResultType(returnType);
                return $"{type}ValueTask<{mockedTypeName},{valueTaskResultType},{delegates}>";
            }
            else if (returnType.StartsWith("Task<"))
            {
                var taskResultType = TaskGenericHelper.ExtractResultType(returnType);
                return $"{type}TaskResult<{mockedTypeName},{taskResultType},{delegates}>";
            }
            return $"{type}<{mockedTypeName},{returnType},{delegates}>";
        }

        
    }
}
