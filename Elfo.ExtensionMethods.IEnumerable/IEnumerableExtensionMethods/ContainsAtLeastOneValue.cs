using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        public static bool ContainsAtLeastOneValue<T>(this IEnumerable<T> list) => list != null && !list.IsNullOrEmpty();
    }
}
