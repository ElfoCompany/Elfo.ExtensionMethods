using System;
using System.Collections.Generic;
using System.Linq;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static class IEnumerableExtensionMethods
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) => (list == null || list?.Count() == 0);

        public static bool ContainsAtLeastOneValue<T>(this IEnumerable<T> list) => list != null && !list.IsNullOrEmpty();

        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> query, Predicate<T> predicate) => query = query.Where(e => !predicate(e));
    }
}
