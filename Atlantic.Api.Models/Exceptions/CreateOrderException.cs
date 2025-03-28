using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Atlantic.Api.Models.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class CreateOrderException : Exception
    {
        public CreateOrderException()
        {
        }

        protected CreateOrderException(SerializationInfo info, StreamingContext context)
        {
        }

        public CreateOrderException(string message) : base(message)
        {
        }

        public CreateOrderException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
