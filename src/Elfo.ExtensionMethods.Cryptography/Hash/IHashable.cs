namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    /// <summary>
    /// Represents the instance of an object from which the hash can be calculated.
    /// </summary>
    public interface IHashable
    {
        /// <summary>
        /// Returns a <see cref="byte[]"/> that will be used to compute the hash of this <see cref="IHashable"/> instance.
        /// </summary>
        /// <returns></returns>
        byte[] GetBytesForHash();
    }
}
