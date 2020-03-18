using System;
using System.Collections.Generic;
using System.Linq;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="ArgumentNullException">Source or predicate is null.</exception>
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> source, Predicate<T> predicate) => source.Where(e => !predicate(e));

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used
        ///     in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="predicate">
        /// A function to test each element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="ArgumentNullException">Source or predicate is null.</exception>
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> source, Func<T, int, bool> predicate) => source.Where((e, i)=> !predicate(e, i));
    }
}