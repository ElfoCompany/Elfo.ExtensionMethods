using Elfo.ExtensionMethods.Cryptography.Hash.Hashables;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    public static partial class HashExtensionMethods
    {
        /// <summary>
        /// Convert the input <see cref="byte"/> array into an <see cref="IHashable"/>.
        /// </summary>
        /// <param name="input">The <see cref="byte"/> array to convert.</param>
        /// <returns></returns>
        public static IHashable ToHashable(this byte[] input) => new BytesHashable(input);
    }
}
