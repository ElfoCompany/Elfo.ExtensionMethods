using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elfo.ExtensionMethods.Cryptography.Hash
{
    /// <summary>
    /// Options to compute the hash used by the <see cref="HashResult{H}"/> and <see cref="HashResult{H, R}"/>.
    /// </summary>
    public class HashingOptions
    {
        #region Default Values
        public const string DEFAULT_SEPARATOR = " ";
        public const string DEFAULT_FORMAT = "x2";
        /// <summary>
        /// The defaults hashing options used by the <see cref="HashResult{H}"/> and <see cref="HashResult{H, R}"/>.
        /// </summary>
        public static HashingOptions DefaultHashingOptions => new HashingOptions();
        #endregion

        #region Properties
        /// <summary>
        /// The seprataor used by the <see cref="HashResult{H}"/> and <see cref="HashResult{H, R}"/> when converting the Hash
        /// to string.
        /// </summary>
        public virtual string Separator { get; set; } = DEFAULT_SEPARATOR;
        /// <summary>
        /// The format used by the <see cref="HashResult{H}"/> and <see cref="HashResult{H, R}"/> when converting the Hash to
        /// string.
        /// </summary>
        public virtual string Format { get; set; } = DEFAULT_FORMAT;
        #endregion

        #region Builder like Sets
        /// <summary>
        /// Sets the <see cref="Separator"/> property and returns the <see cref="HashingOptions"/> instance.
        /// </summary>
        /// <param name="separator">The string representing the <see cref="Separator"/>.</param>
        /// <returns>The current instance of <see cref="HashingOptions"/>.</returns>
        public virtual HashingOptions SetSeparator(string separator)
        {
            if (separator is null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            Separator = separator;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Format"/> property and returns the <see cref="HashingOptions"/> instance.
        /// </summary>
        /// <param name="format">The string representing the <see cref="Format"/>.</param>
        /// <returns>The current instance of <see cref="HashingOptions"/>.</returns>
        public virtual HashingOptions SetFormat(string format)
        {
            if (format is null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            Format = format;
            return this;
        } 
        #endregion
    }
}
