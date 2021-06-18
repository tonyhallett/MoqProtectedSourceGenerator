namespace MoqProtectedSourceGenerator
{
    public class ReturningReturnTypeDetails : IReturnTypeDetails
    {
        public string ExpressionDelegate(string likeTypeName, string returnType)
        {
            return $"Func<{likeTypeName},{returnType}>";
        }

        public string MethodBuilderType(string mockedTypeName, string returnType)
        {
            return $"ReturningMethodBuilder<{mockedTypeName},{returnType}>";
        }
    }
}
