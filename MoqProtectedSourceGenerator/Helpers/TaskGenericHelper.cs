namespace MoqProtectedSourceGenerator
{
    public static class TaskGenericHelper
    {
        public static string ExtractResultType(string genericType)
        {
            var leftBracketIndex = genericType.IndexOf("<");
            var extracted = genericType.Substring(leftBracketIndex + 1, genericType.Length - leftBracketIndex - 2);
            return extracted;
        }
    }
}
