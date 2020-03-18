using System;
using System.Collections.Generic;

namespace Elfo.ExtensionMethods.IEnumerable
{
    public static partial class IEnumerableExtensionMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            foreach (TSource sourceElement in source)
            {
                action.Invoke(sourceElement);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            var index = 0;
            foreach (TSource sourceElement in source)
            {
                action.Invoke(sourceElement, index++);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="source"></param>
        /// <param name="additionalParameter"></param>
        /// <param name="action"></param>
        public static void ForEach<TSource, TParam>(
            this IEnumerable<TSource> source,
            TParam additionalParameter,
            Action<TSource, int, TParam> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            var index = 0;
            foreach (TSource sourceElement in source)
            {
                action.Invoke(sourceElement, index++, additionalParameter);
            }
        }

    }
}
