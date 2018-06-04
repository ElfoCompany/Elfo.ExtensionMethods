using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elfo.ExtensionMethods.IEnumerable
{
   public static partial class IEnumerableExtensionMethods
    {
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> query, Predicate<T> predicate) => query = query.Where(e => !predicate(e));
    }
}