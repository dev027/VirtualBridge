using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace VirtualBridge.Utilities.Testing.Exceptions
{
    /// <summary>
    /// DeliberateException.
    /// </summary>
    [Serializable]
    public class DeliberateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliberateException"/> class.
        /// </summary>
        public DeliberateException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliberateException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        [ExcludeFromCodeCoverage]
        public DeliberateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliberateException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">InnerException.</param>
        [ExcludeFromCodeCoverage]
        public DeliberateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliberateException"/> class.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Streaming Context.</param>
        [ExcludeFromCodeCoverage]
        protected DeliberateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}