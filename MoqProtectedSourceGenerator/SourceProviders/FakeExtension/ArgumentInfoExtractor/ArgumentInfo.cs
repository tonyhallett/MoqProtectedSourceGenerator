using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public class ArgumentInfo
    {
        public ArgumentType Type { get; set; }
        public string RefAny { get; set; }

        public static string SourceList(List<ArgumentInfo> argumentInfos)
        {
            var numArgumentInfos = argumentInfos.Count;
            var stringBuilder = new StringBuilder("new List<ArgumentInfo>{");

            if (numArgumentInfos == 0)
            {
                stringBuilder.Append("}");
            }
            else
            {
                var spaces = SpaceTabs.GetSpaces(5);
                void AppendLineTabbed(string line, bool appendLine = true, string prefix = null)
                {
                    if (prefix == null)
                    {
                        prefix = spaces;
                    }
                    Func<string, StringBuilder> append = appendLine ? stringBuilder.AppendLine : stringBuilder.Append;
                    stringBuilder.Append(prefix);
                    append(line);
                }

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
                    AppendLineTabbed(@$"new ArgumentInfo {{ Type = ArgumentType.{argumentInfo.Type}, RefAny = {refExpression} }}{comma}");
                    count++;
                }
                AppendLineTabbed("}", false, SpaceTabs.GetSpaces(4));
            }

            var sourceList = stringBuilder.ToString();
            return sourceList;

        }
    }
}
