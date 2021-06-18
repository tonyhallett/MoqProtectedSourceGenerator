using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public static class OutType
    {
        public static readonly string WrappedProperty = "Value";
        public static string ParameterType(TypeSyntax wrappedType)
        {
            return $"Out<{wrappedType}>";
        }
        public static string GetWrappedType(string type)
        {
            if (type.StartsWith("Out<"))
            {
                var closing = type.IndexOf(">");
                var wrapped = type.Substring(4, closing - 4);
                return wrapped;
            }
            return null;
        }

        public static bool IsOutArgument(InvocationExpressionSyntax invocation)
        {
            return invocation.NormalizeWhitespace().ToFullString().StartsWith("Out.From");
        }
    }
}
