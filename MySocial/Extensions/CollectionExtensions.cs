using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocial.Extensions
{
    public static class CollectionExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            foreach (var element in source)
            {
                action(element);
            }
        }

        public static TSource SingleOrFallback<TSource>(this IEnumerable<TSource> source, Func<TSource> fallbackFunc)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (fallbackFunc == null) throw new ArgumentNullException("fallback function");

            var list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        return fallbackFunc();

                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (var iterator = source.GetEnumerator())
                {
                    if (!iterator.MoveNext())
                    {
                        return fallbackFunc();
                    }
                    var first = iterator.Current;

                    if (!iterator.MoveNext())
                    {
                        return first;
                    }
                }
            }

            throw new InvalidOperationException("Sequence contains more than one element");
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.GroupBy(keySelector, comparer).Select(g => g.First());
        }
    }
}
