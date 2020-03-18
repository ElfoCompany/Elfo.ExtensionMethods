using System;

namespace Elfo.ExtensionMethods.Cryptography.Hash.Hashables
{
    public class BytesHashable : IHashable
    {
        public BytesHashable(byte[] input)
        {
            #region Null checks
            if (input is null)
                throw new ArgumentNullException(nameof(input)); 
            #endregion

            LazyValue = new Lazy<byte[]>(() => input.Clone() as byte[]);
        }

        private Lazy<byte[]> LazyValue { get; }
        internal byte[] Value => LazyValue.Value;

        public byte[] GetBytesForHash() => Value;

        public static implicit operator byte[] (BytesHashable hashable) => hashable.GetBytesForHash();

        public static implicit operator BytesHashable(byte[] bytes) => new BytesHashable(bytes);
    }
}
