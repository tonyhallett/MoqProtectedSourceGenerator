using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public class ParameterInfo
    {
        public ParameterType Type { get; set; }
        public string RefAny { get; set; }

        public static string SourceList(List<ParameterInfo> parameterInfos)
        {
            var numParameterInfos = parameterInfos.Count;
            var stringBuilder = new StringBuilder("new List<ParameterInfo>{");

            if (numParameterInfos == 0)
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
                foreach (var parameterInfo in parameterInfos)
                {
                    var isLast = count == numParameterInfos - 1;
                    var comma = isLast ? "" : ",";
                    var refAny = parameterInfo.RefAny;
                    var refExpression = "null";
                    if (refAny != null)
                    {
                        var withoutRefAny = refAny.Substring(0, refAny.Length - 6);
                        refExpression = @$"Expression.Field(null, typeof({withoutRefAny}), ""IsAny"")";

                    }
                    AppendLineTabbed(@$"new ParameterInfo {{ Type = ParameterType.{parameterInfo.Type}, RefAny = {refExpression} }}{comma}");
                    count++;
                }
                AppendLineTabbed("}", false, SpaceTabs.GetSpaces(4));
            }

            var sourceList = stringBuilder.ToString();
            return sourceList;

        }
    }
}
