namespace MoqProtectedSourceGenerator
{
    public class ReturningReturnTypeDetails : IReturnTypeDetails
    {
        public string DictionaryExpressionOf(string likeTypeName, string returnType)
        {
            return $"Func<{likeTypeName},{returnType}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType)
        {
            return $"ReturningMethodBuilder<{mockedTypeName},{returnType}>";
        }
    }
}
