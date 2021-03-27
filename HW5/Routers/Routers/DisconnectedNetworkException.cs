using System;

namespace Routers
{
    /// <summary>
    /// Exception if the network is not connected
    /// </summary>
    public class DisconnectedNetworkException : Exception
    {
        public DisconnectedNetworkException()
        {
        }

        public DisconnectedNetworkException(string message)
            : base(message)
        {
        }

        public DisconnectedNetworkException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DisconnectedNetworkException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
