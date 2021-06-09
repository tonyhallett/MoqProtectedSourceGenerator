namespace MoqProtectedSourceGenerator
{
    public interface IReturnTypeDetails
    {
        string DictionaryExpressionOf(string likeTypeName, string returnType);
        string MethodBuilderType(string mockedTypeName, string returnType);

    }
}
