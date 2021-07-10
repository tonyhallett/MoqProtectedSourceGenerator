namespace MoqProtectedSourceGenerator
{
    public class VoidReturnTypeDetails : IReturnTypeDetails
    {
        public string ExpressionDelegate(string likeTypeName, string returnType)
        {
            return $"Action<{likeTypeName}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType, string delegates)
        {
            return GetType("VoidBuilder", mockedTypeName, delegates);
        }

        public string SetupTyped(string mockedTypeName, string returnType, string delegates)
        {
            return GetType("SetupTyped", mockedTypeName, delegates);
        }

        private string GetType(string type, string mockedTypeName, string delegates)
        {
            return $"{type}<{mockedTypeName}, {delegates}>";
        }

    }
}
