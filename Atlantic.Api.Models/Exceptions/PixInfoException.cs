using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Atlantic.Api.Models.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class PixInfoException : Exception
    {
        public PixInfoException()
        {
        }

        protected PixInfoException(SerializationInfo info, StreamingContext context)
        {
        }

        public PixInfoException(string message) : base(message)
        {
        }

        public PixInfoException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
