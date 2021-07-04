using System;

namespace BTreeImplementation
{
    /// <summary>
    /// Exception if an item is called with a non-existent key
    /// </summary>
    public class NonExistentKeyException : Exception
    {
        public NonExistentKeyException()
        {
        }

        public NonExistentKeyException(string message)
            : base(message)
        {
        }

        public NonExistentKeyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NonExistentKeyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
