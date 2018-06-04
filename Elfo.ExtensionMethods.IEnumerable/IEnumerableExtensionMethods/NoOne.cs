using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        public static bool NoOne<T>(this IEnumerable<T> query, Predicate<T> predicate) => query.Any(e => !predicate(e));
    }
}
