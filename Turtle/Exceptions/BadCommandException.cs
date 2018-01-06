using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Turtle.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BadCommandException : Exception
    {
        public BadCommandException()
        {
        }

        public BadCommandException(string message) : base(message)
        {
        }

        public BadCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
