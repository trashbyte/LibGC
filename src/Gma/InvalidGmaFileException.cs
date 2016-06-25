using System;
using System.Runtime.Serialization;

namespace LibGC.Gma
{
    /// <summary>
    /// Thrown when an invalid .GMA stream is read/written.
    /// </summary>
    public class InvalidGmaFileException : Exception
    {
        public InvalidGmaFileException()
        {
        }

        public InvalidGmaFileException(string message)
            : base(message)
        {
        }

        public InvalidGmaFileException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidGmaFileException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
