using System;
using System.Runtime.Serialization;

namespace LibGC.StageLayout
{
    /// <summary>
    /// Thrown when an invalid STAGEDEF stream is read/written.
    /// </summary>
    public class InvalidStageLayoutFileException : Exception
    {
        public InvalidStageLayoutFileException()
        {
        }

        public InvalidStageLayoutFileException(string message)
            : base(message)
        {
        }

        public InvalidStageLayoutFileException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidStageLayoutFileException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
