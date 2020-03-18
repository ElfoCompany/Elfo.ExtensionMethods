using System;
using System.Linq;
using System.Security.Cryptography;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    /// <summary>
    /// Represent an object which contanis all the needed information to lazily compute an Hash.
    /// </summary>
    /// <typeparam name="H">The <see cref="HashAlgorithm"/> to be used to compute the Hash.</typeparam>
    public class HashResult<H>
        where H : HashAlgorithm, new()
    {
        /// <summary>
        /// Create an <see cref="HashResult{H}"/>
        /// </summary>
        /// <param name="input">the object from which the hash is to be calculated.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the <see cref="HashResult{H}"/>.</param>
        public HashResult(IHashable input, HashingOptions hashingOptions = null)
        {
            #region HashingOptions Management
            if (hashingOptions is null)
            {
                hashingOptions = HashingOptions.DefaultHashingOptions;
            }
            #endregion

            LazyHash = new Lazy<byte[]>(() => input.GetBytesForHash().Hash<H>());
            
            LazyStringValue = new Lazy<string>(() => ToString(HashingOptions.Separator, HashingOptions.Format), true);
        }

        #region Properties
        #region Private Properties
        private Lazy<byte[]> LazyHash { get; }
        private Lazy<string> LazyStringValue { get; } 
        #endregion

        #region Protected Properties
        /// <summary>
        /// Returns the computed Hash as <see cref="byte[]"/>.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        protected byte[] Hash => LazyHash.Value;
        /// <summary>
        /// Returns the computed Hash as <see cref="string"/>.
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        protected string StringValue => LazyStringValue.Value;
        #endregion

        #region Public Properties
        /// <summary>
        /// The <see cref="Hash.HashingOptions"/> used by this instance of <see cref="HashResult{H}"/>.
        /// </summary>
        public HashingOptions HashingOptions { get; } 
        #endregion
        #endregion

        /// <summary>
        /// Returns the computed Hash as <see cref="string"/>.
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => StringValue;

        /// <summary>
        /// Returns the computed Hash as <see cref="string"/> by using the specified options insted of the ones specified into 
        /// the <see cref="HashingOptions"/> of this <see cref="HashResult{H}"/> instance.
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="separator">The value used to separate the bytes composing the Hash.</param>
        /// <param name="format">The numeric format to be used during the conversion from <see cref="byte[]"/> to <see cref="string"/>.<para/>
        /// The allowed formats are the same of <see cref="byte.ToString()"/>
        /// </param>
        /// <returns></returns>
        public virtual string ToString(string separator, string format)
            => string.Join(separator, Hash.Select(b => b.ToString(format)));


        #region Implicit Operators
        /// <summary>
        /// Converts an <see cref="HashResult{H}"/> into the corresponding <see cref="byte[]"/> representing the Hash.
        /// The result of the conversion is based on the <see cref="Hash.HashingOptions"/> used by the <see cref="HashResult{H}"/>
        /// input instance.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="hashResult">The <see cref="HashResult{H}"/> to convert.</param>
        public static implicit operator byte[] (HashResult<H> hashResult)
        {
            if (hashResult == null)
            {
                return default;
            }
            return hashResult.Hash.Clone() as byte[];
        }

        /// <summary>
        /// Converts an <see cref="HashResult{H}"/> into the corresponding <see cref="string"/> representing the Hash.
        /// The result of the conversion is based on the <see cref="Hash.HashingOptions"/> used by the <see cref="HashResult{H}"/>
        /// input instance.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="hashResult">The <see cref="HashResult{H}"/> to convert.</param>
        public static implicit operator string(HashResult<H> hashResult)
        {
            if (hashResult == null)
            {
                return default;
            }
            return hashResult.ToString();
        } 
        #endregion
    }

    /// <summary>
    /// Represent an object which contanis all the needed information to lazily compute an Hash.
    /// </summary>
    /// <typeparam name="H">The <see cref="HashAlgorithm"/> to be used to compute the Hash.</typeparam>
    /// <typeparam name="R">The returning type of the result.</typeparam>
    public class HashResult<H, R> : HashResult<H>
        where H : HashAlgorithm, new()
    {
        /// <summary>
        /// Create an <see cref="HashResult{H,R}"/>
        /// </summary>
        /// <param name="input">the object from which the hash is to be calculated.</param>
        /// <param name="toResultFunc">The <see cref="Func{T, TResult}"/> which will be used to convert the <see cref="byte[]"/> representing the Hash into the 
        /// specified result type.</param>
        /// <param name="hashingOptions">Optional. Options to change the behaviour of the <see cref="HashResult{H, R}"/>.</param>
        public HashResult(
            IHashable input,
            Func<byte[], R> toResultFunc,
            HashingOptions hashingOptions = null)
            : base(input, hashingOptions)
        {
            if(toResultFunc is null)
            {
                throw new ArgumentNullException(nameof(toResultFunc));
            }
            ToResultFunc = toResultFunc;
        }

        #region Protected properties
        /// <summary>
        /// The <see cref="Func{T, TResult}"/> which will be used to convert the <see cref="byte[]"/> representing the Hash into the 
        /// specified result type.
        /// </summary>
        protected Func<byte[], R> ToResultFunc { get; } 
        #endregion

        /// <summary>
        /// Returns the computed Hash as the specified <typeparamref name="R"/>.
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <returns></returns>
        public R ToResult() => ToResultFunc.Invoke(Hash);

        #region Implicit Operators
        /// <summary>
        /// Converts an <see cref="HashResult{H, R}"/> into the corresponding <see cref="byte[]"/> representing the Hash.
        /// The result of the conversion is based on the <see cref="HashingOptions"/> used by the <see cref="HashResult{H, R}"/>
        /// input instance.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="hashResult">The <see cref="HashResult{H, R}"/> to convert.</param>
        public static implicit operator byte[] (HashResult<H, R> hashResult) => hashResult;

        /// <summary>
        /// Converts an <see cref="HashResult{H, R}"/> into the corresponding <see cref="string"/> representing the Hash.
        /// The result of the conversion is based on the <see cref="HashingOptions"/> used by the <see cref="HashResult{H, R}"/>
        /// input instance.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="hashResult">The <see cref="HashResult{H, R}"/> to convert.</param>
        public static implicit operator string(HashResult<H, R> hashResult) => hashResult;

        /// <summary>
        /// Converts an <see cref="HashResult{H, R}"/> into the corresponding <see cref="string"/> representing the Hash.
        /// The result of the conversion is based on the <see cref="ToResult"/> method of the <see cref="HashResult{H, R}"/>
        /// input instance. If the <see cref="HashResult{H, R}"/> input instance is null,
        /// the default value for the <typeparamref name="R"/> type is returned.<para/>
        /// Causes the evaluation of the Hash operation.
        /// </summary>
        /// <param name="hashResult">The <see cref="HashResult{H, R}"/> to convert.</param>
        public static implicit operator R(HashResult<H, R> hashResult)
        {
            if (hashResult == null)
            {
                return default;
            }
            return hashResult.ToResult();
        } 
        #endregion
    }
}
