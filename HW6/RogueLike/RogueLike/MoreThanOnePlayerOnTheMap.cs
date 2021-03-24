using System;

namespace RogueLike
{
    /// <summary>
    /// Exception class if there is suddenly more than one character on the map
    /// </summary>
    public class MoreThanOnePlayerOnTheMap : Exception
    {
        public MoreThanOnePlayerOnTheMap()
        {
        }

        public MoreThanOnePlayerOnTheMap(string message)
            : base(message)
        {
        }

        public MoreThanOnePlayerOnTheMap(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MoreThanOnePlayerOnTheMap(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
