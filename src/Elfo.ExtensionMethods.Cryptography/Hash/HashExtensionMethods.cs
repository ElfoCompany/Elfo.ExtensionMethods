using System;
using System.Security.Cryptography;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    public static partial class HashExtensionMethods
    {
        /// <summary>
        /// Computes the Hash of the given <see cref="byte"/> array input.
        /// </summary>
        /// <typeparam name="H">The <see cref="HashAlgorithm"/> to use.</typeparam>
        /// <param name="input">The <see cref="byte"/> array to compute the hash of.</param>
        /// <returns></returns>
        public static byte[] Hash<H>(this byte[] input)
            where H : HashAlgorithm, new()
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            byte[] result;
            using (H hasher = new H())
            {
                result = hasher.ComputeHash(input);
            }
            return result;
        }

        /// <summary>
        /// Computes the Hash of the given <see cref="IHashable"/> input.
        /// </summary>
        /// <typeparam name="H">The <see cref="HashAlgorithm"/> to use.</typeparam>
        /// <param name="input">The <see cref="IHashable"/> to compute the hash of.</param>
        /// <param name="hashingOptions">The options to use to compte the Hash.</param>
        /// <returns></returns>
        public static HashResult<H> Hash<H>(this IHashable input, HashingOptions hashingOptions = null)
            where H : HashAlgorithm, new()
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return new HashResult<H>(input, hashingOptions);
        }

        /// <summary>
        /// Computes the Hash of the given <see cref="IHashable"/> input.
        /// </summary>
        /// <typeparam name="H">The <see cref="HashAlgorithm"/> to use.</typeparam>
        /// <typeparam name="R">The output type of the Hash computation.</typeparam>
        /// <param name="input">The <see cref="IHashable"/> to compute the hash of.</param>
        /// <param name="toResultFunc">The <see cref="Func{T, TResult}"/> to convert the Hash from a <see cref="byte"/> array
        /// to <typeparamref name="R"/></param>
        /// <param name="hashingOptions">The options to use to compte the Hash.</param>
        /// <returns></returns>
        public static HashResult<H, R> Hash<H, R>(
            this IHashable input, 
            Func<byte[], R> toResultFunc,
            HashingOptions hashingOptions = null)
            where H : HashAlgorithm, new()
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return new HashResult<H, R>(input, toResultFunc, hashingOptions);
        }
    }
}
