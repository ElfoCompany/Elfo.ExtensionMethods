using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Determines whether a sequence is null or does not contain elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="list">The <see cref="IEnumerable{T}"/> to check for null or emptiness.</param>
        /// <returns>true if the source sequence does not contain elements; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) => (list == null || list.NoOne());
    }
}
