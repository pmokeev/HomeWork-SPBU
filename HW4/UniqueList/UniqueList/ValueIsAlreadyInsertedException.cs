using System;

namespace UniqueListNumber
{
    public class ValueIsAlreadyInsertedException : Exception
    {
        public ValueIsAlreadyInsertedException()
        {
        }

        public ValueIsAlreadyInsertedException(string message)
            : base(message)
        {
        }

        public ValueIsAlreadyInsertedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ValueIsAlreadyInsertedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
