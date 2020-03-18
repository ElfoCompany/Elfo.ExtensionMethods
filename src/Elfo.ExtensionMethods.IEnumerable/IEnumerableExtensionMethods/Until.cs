using System;
using System.Collections.Generic;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Loop an <see cref="IEnumerable{T}"/> until the codition is met.
        /// </summary>
        /// <typeparam name="TSoruce"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        public static void Until<TSoruce>(this IEnumerable<TSoruce> source, Func<TSoruce, bool> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            var canContinue = true;
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext() && canContinue)
            {
                //If the predicate returns true, the loop should stop
                canContinue = !predicate.Invoke(enumerator.Current);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSoruce"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        public static void Until<TSoruce, TParam>(
            this IEnumerable<TSoruce> source,
            TParam additionalParameter,
            Func<TSoruce, int, TParam, bool> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            int index = 0;
            var canContinue = true;
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext() && canContinue)
            {
                //If the predicate returns true, the loop should stop
                canContinue = !predicate.Invoke(enumerator.Current, index++, additionalParameter);
            }
        }
    }
}
