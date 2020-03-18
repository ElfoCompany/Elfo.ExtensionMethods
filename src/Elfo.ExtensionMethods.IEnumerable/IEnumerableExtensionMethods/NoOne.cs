using System;
using System.Collections.Generic;
using System.Linq;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Determines whether a senquence does not contain elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check for emptiness.</param>
        /// <returns>true if the source sequence does not contain elements; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static bool NoOne<T>(this IEnumerable<T> source) => !source.Any();

        /// <summary>
        /// Determines whether a senquence does not contain elements that siatisfie a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns> 
        /// true if no elements in the source sequence pass the test in the specified predicate;
        /// otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static bool NoOne<T>(this IEnumerable<T> source, Predicate<T> predicate) => source.Any(e => !predicate(e));
    }
}
