using System;
using System.Security.Cryptography;
using System.Text;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    public static partial class HashExtensionMethods
    {
        /// <summary>
        /// Compute the <see cref="SHA256"/> Hash with of the given array of bytes.
        /// </summary>
        /// <param name="input">The array of bytes to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <returns></returns>
        public static HashResult<SHA256CryptoServiceProvider> Sha256(this byte[] input, HashingOptions hashingOptions = null)
            => input.ToHashable().Sha256(hashingOptions);

        /// <summary>
        /// Compute the <see cref="SHA256"/> Hash with of the given <see cref="string"/>.
        /// </summary>
        /// <param name="input">The <see cref="string"/> to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <param name="stringEncoding">Optional. The encoding of the input <see cref="string"/>, 
        /// used to convert the <see cref="string"/> into an array of bytes.</param>
        /// <returns></returns>
        public static HashResult<SHA256CryptoServiceProvider> Sha256(this string input, HashingOptions hashingOptions = null, Encoding stringEncoding = null)
            => input.ToHashable(stringEncoding).Sha256(hashingOptions);

        /// <summary>
        /// Compute the <see cref="SHA256"/> Hash with of the given <see cref="IHashable"/>.
        /// </summary>
        /// <param name="input">The <see cref="IHashable"/> to calculate the hash of.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the hashing computation.</param>
        /// <returns></returns>
        public static HashResult<SHA256CryptoServiceProvider> Sha256(this IHashable input, HashingOptions hashingOptions = null)
            => input.Hash<SHA256CryptoServiceProvider>(hashingOptions);
    }
}
