using System.Collections.Generic;

namespace MoqProtectedSourceGenerator
{
    public class ReturningReturnTypeDetails : IReturnTypeDetails
    {
        private delegate string ReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates);
        private readonly List<ReturnTypeProvider> returnTypeProviders;

        public ReturningReturnTypeDetails()
        {
            returnTypeProviders = new()
            {
                TaskReturnTypeProvider,
                TaskResultReturnTypeProvider,
                ValueTaskReturnTypeProvider,
                ValueTaskResultReturnTypeProvider,
                NonAsyncReturnTypeProvider
            };
        }
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
            return GetType("SetupTypedResult", mockedTypeName, returnType, delegates);
        }

        private string TaskReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates)
        {
            if (returnType == "Task")
            {
                return $"{type}Task<{mockedTypeName},{delegates}>";
            }
            return null;
        }

        private string ValueTaskReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates)
        {
            if (returnType == "ValueTask")
            {
                return $"{type}ValueTask<{mockedTypeName},{delegates}>";
            }
            return null;
        }

        private string TaskResultReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates)
        {
            if (returnType.StartsWith("Task<"))
            {
                var taskResultType = TaskGenericHelper.ExtractResultType(returnType);
                return $"{type}TaskResult<{mockedTypeName},{taskResultType},{delegates}>";
            }
            return null;
        }

        private string ValueTaskResultReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates)
        {
            if (returnType.StartsWith("ValueTask<"))
            {
                var valueTaskResultType = TaskGenericHelper.ExtractResultType(returnType);
                return $"{type}ValueTaskResult<{mockedTypeName},{valueTaskResultType},{delegates}>";
            }
            return null;
        }

        private string NonAsyncReturnTypeProvider(string type, string mockedTypeName, string returnType, string delegates)
        {
            return $"{type}<{mockedTypeName},{returnType},{delegates}>";
        }

        private string GetType(string type, string mockedTypeName, string returnType, string delegates)
        {
            foreach (var returnTypeProvider in returnTypeProviders)
            {
                var providedReturnType = returnTypeProvider(type, mockedTypeName, returnType, delegates);
                if (providedReturnType != null)
                {
                    return providedReturnType;
                }
            }
            return null;
        }


    }
}
