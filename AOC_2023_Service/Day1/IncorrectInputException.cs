using System.Runtime.Serialization;

namespace AOC_2023_Service.Day1
{
    [Serializable]
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }

        public IncorrectInputException(string? message) : base(message)
        {
        }

        public IncorrectInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IncorrectInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
