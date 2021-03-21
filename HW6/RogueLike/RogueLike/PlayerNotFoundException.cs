using System;

namespace RogueLike
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
        {
        }

        public PlayerNotFoundException(string message)
            : base(message)
        {
        }

        public PlayerNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected PlayerNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}