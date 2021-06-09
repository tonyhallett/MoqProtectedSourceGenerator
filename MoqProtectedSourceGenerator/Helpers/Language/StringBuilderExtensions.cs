using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedSourceGenerator
{
    public static class StringBuilderExtensions
    {
        public static void AggregateAppendIfLast<TSource>(this StringBuilder stringBuilder,List<TSource> source, Action<TSource, Func<string, StringBuilder>, bool> appendWithLast)
        {
            source.AggregateWithLast(stringBuilder, (sb, entry, isLast) =>
             {
                 Func<string, StringBuilder> append = isLast ? sb.Append : sb.AppendLine;
                 appendWithLast(entry, append, isLast);
                 return sb;
             });
        }
    }
}
