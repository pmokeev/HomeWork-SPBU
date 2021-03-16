using System;

namespace ArithmeticTree
{
    /// <summary>
    /// Exception if an invalid expression is entered
    /// </summary>
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException()
        {
        }

        public InvalidExpressionException(string message)
            : base(message)
        {
        }

        public InvalidExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidExpressionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}