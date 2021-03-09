using System;

namespace UniqueListNumber
{
    public class ValueDoesNotExistException : Exception
    {
        public ValueDoesNotExistException()
        {
        }

        public ValueDoesNotExistException(string message)
            : base(message)
        {
        }

        public ValueDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ValueDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
