namespace MoqProtectedSourceGenerator
{
    public static class StringHelpers
    {

        public static string UppercaseFirst(string lowercase)
        {
            var first = lowercase.Substring(0, 1);
            var remainder = lowercase.Substring(1);
            return $"{first.ToUpper()}{remainder}";
        }

    }
}
