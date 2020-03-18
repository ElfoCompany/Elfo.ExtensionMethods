using System;
using System.Security.Cryptography;
using System.Text;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    public static partial class HashExtensionMethods
    {
        /// <summary>
        /// Compute the <see cref="System.Security.Cryptography.MD5"/> Hash with of the given array of bytes.
        /// </summary>
        /// <param name="input">The array of bytes to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <returns></returns>
        public static HashResult<MD5CryptoServiceProvider> MD5(this byte[] input, HashingOptions hashingOptions = null)
            => input.ToHashable().MD5(hashingOptions);

        /// <summary>
        /// Compute the <see cref="System.Security.Cryptography.MD5"/> Hash with of the given <see cref="string"/>.
        /// </summary>
        /// <param name="input">The <see cref="string"/> to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <param name="stringEncoding">Optional. The encoding of the input <see cref="string"/>, 
        /// used to convert the <see cref="string"/> into an array of bytes.</param>
        /// <returns></returns>
        public static HashResult<MD5CryptoServiceProvider> MD5(this string input, HashingOptions hashingOptions = null, Encoding stringEncoding = null)
            => input.ToHashable(stringEncoding).MD5(hashingOptions);

        /// <summary>
        /// Compute the <see cref="System.Security.Cryptography.MD5"/> Hash with of the given <see cref="IHashable"/>.
        /// </summary>
        /// <param name="input">The <see cref="IHashable"/> to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <returns></returns>
        public static HashResult<MD5CryptoServiceProvider> MD5(this IHashable input, HashingOptions hashingOptions = null)
            => input.Hash<MD5CryptoServiceProvider>(hashingOptions);
    }
}
