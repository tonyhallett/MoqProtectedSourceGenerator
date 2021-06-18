using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public static class SpaceTabs
    {
        private static readonly string Tab = "    ";
        private static readonly Dictionary<int, string> tabs = new();
        public static string GetSpaces(int numTabs)
        {
            if (!tabs.TryGetValue(numTabs, out var spaces))
            {
                spaces = CreateSpaces(numTabs);
                tabs.Add(numTabs, spaces);
            }
            return spaces;
        }
        private static string CreateSpaces(int numTabs)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < numTabs; i++)
            {
                sb.Append(Tab);
            }
            return sb.ToString();
        }
    }
}
