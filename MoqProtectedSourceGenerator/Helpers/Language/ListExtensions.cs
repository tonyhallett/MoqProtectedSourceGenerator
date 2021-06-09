using System;
using System.Collections.Generic;
using System.Linq;

namespace MoqProtectedSourceGenerator
{
    public static class ListExtensions
    {
        public static TAccumulate AggregateWithLast<TSource, TAccumulate>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, bool, TAccumulate> func)
        {
            var numEntries = source.Count;
            var count = 1;
            return source.Aggregate(seed, (seed, entry) =>
            {
                var isLast = count == numEntries;
                count++;
                return func(seed, entry, isLast);
            });
        }
    }
}
