namespace MoqProtectedSourceGenerator
{
    public interface IReturnTypeDetails
    {
        string ExpressionDelegate(string likeTypeName, string returnType);
        string MethodBuilderType(string mockedTypeName, string returnType);

    }
}
