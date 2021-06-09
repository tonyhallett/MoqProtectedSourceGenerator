namespace MoqProtectedSourceGenerator
{
    public class VoidReturnTypeDetails : IReturnTypeDetails
    {
        public string DictionaryExpressionOf(string likeTypeName, string returnType)
        {
            return $"Action<{likeTypeName}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType)
        {
            return $"VoidMethodBuilder<{mockedTypeName}>";
        }
    }
}
