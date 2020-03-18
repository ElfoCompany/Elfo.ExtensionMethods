using System.Collections.Generic;
using System.Linq;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Determines whether the source is not null and contains at least one value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check.</param>
        /// <returns>true if the source sequence is not null and contains at least one element; otherwise, false.</returns>
        public static bool ContainsAtLeastOneValue<T>(this IEnumerable<T> source) => source != null && source.Any();
    }
}
