using System;
using System.Text;

namespace Elfo.ExtensionMethods.Cryptography.Hash.Hashables
{
    public class StringHashable : IHashable
    {
        public StringHashable(string input, Encoding encoding = null)
        {
            #region Null checks
            if (input is null)
                throw new ArgumentNullException(nameof(input));
            #endregion

            #region Default values
            if (encoding == null)
                encoding = Encoding.UTF8; 
            #endregion

            Value = input;
            Encoder = encoding;
            LazyBytes = new Lazy<byte[]>(() => Encoder.GetBytes(input));
        }

        private Lazy<byte[]> LazyBytes { get; }

        internal byte[] Bytes => LazyBytes.Value;
        internal string Value { get; }
        internal Encoding Encoder { get; }

        public byte[] GetBytesForHash() => Bytes;
        public override string ToString() => Value;


        public static implicit operator string(StringHashable hashable) => hashable.ToString();

        public static implicit operator StringHashable(string stringToHash)
            => new StringHashable(stringToHash);
    }
}
