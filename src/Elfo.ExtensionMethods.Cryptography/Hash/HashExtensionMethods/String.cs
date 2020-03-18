using Elfo.ExtensionMethods.Cryptography.Hash.Hashables;
using System.Text;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    public static partial class HashExtensionMethods
    {
        /// <summary>
        /// Convert the input <see cref="string"/> into an <see cref="IHashable"/>.
        /// </summary>
        /// <param name="input">The <see cref="string"/> to convert.</param>
        /// <param name="stringEncoding">The encoding of the input <see cref="string"/>.</param>
        /// <returns></returns>
        public static IHashable ToHashable(this string input, Encoding stringEncoding = null) 
            => new StringHashable(input, stringEncoding);
    }
}
