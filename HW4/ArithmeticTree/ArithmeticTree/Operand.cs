using System;

namespace ArithmeticTree
{
    /// <summary>
    /// The class that implements the operand in the parse tree
    /// </summary>
    public class Operand : INode
    {
        /// <summary>
        /// Value in node
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Operand(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Print value
        /// </summary>
        public void Print()
            => Console.Write(Value);

        /// <summary>
        /// Get value in node
        /// </summary>
        public float Calculate()
            => Value;
    }
}