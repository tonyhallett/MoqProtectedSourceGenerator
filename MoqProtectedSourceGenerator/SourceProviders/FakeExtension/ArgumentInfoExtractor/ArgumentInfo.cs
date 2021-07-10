using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public class ArgumentInfo
    {
        public ArgumentType Type { get; set; }
        public string RefAny { get; set; }
        private static readonly string FiveTabs = SpaceTabs.GetSpaces(5);
        private static void AddArguments(StringBuilder stringBuilder, List<ArgumentInfo> argumentInfos)
        {
            var numArgumentInfos = argumentInfos.Count;


            stringBuilder.AppendLine("");

            var count = 0;
            foreach (var argumentInfo in argumentInfos)
            {
                var isLast = count == numArgumentInfos - 1;
                var comma = isLast ? "" : ",";
                var refAny = argumentInfo.RefAny;
                var refExpression = "null";
                if (refAny != null)
                {
                    var withoutRefAny = refAny.Substring(0, refAny.Length - 6);
                    refExpression = @$"Expression.Field(null, typeof({withoutRefAny}), ""IsAny"")";

                }
                AppendLineTabbed(stringBuilder, @$"new ArgumentInfo {{ Type = ArgumentType.{argumentInfo.Type}, RefAny = {refExpression} }}{comma}");
                count++;
            }
            AppendLineTabbed(stringBuilder, "}", false, SpaceTabs.GetSpaces(4));
        }
        public static string SourceList(List<ArgumentInfo> argumentInfos)
        {
            var stringBuilder = new StringBuilder("new List<ArgumentInfo>{");

            if (argumentInfos.Count == 0)
            {
                stringBuilder.Append("}");
            }
            else
            {
                AddArguments(stringBuilder, argumentInfos);
            }

            var sourceList = stringBuilder.ToString();
            return sourceList;

        }

        private static void AppendLineTabbed(StringBuilder stringBuilder, string line, bool appendLine = true, string prefix = null)
        {
            if (prefix == null)
            {
                prefix = FiveTabs;
            }
            Func<string, StringBuilder> append = appendLine ? stringBuilder.AppendLine : stringBuilder.Append;
            stringBuilder.Append(prefix);
            append(line);
        }
    }
}
