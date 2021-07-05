using System;

namespace ArithmeticTree
{
    /// <summary>
    /// The class that implements the operator in the parse tree
    /// </summary>
    public abstract class Operator : INode
    {
        /// <summary>
        /// Left node of expression
        /// </summary>
        public INode LeftChild { get; set; }

        /// <summary>
        /// Right node of expression
        /// </summary>
        public INode RightChild { get; set; }

        /// <summary>
        /// Operation sign
        /// </summary>
        public virtual char Operation { get; }

        /// <summary>
        /// Function for calculating a value
        /// </summary>
        public abstract float Calculate();

        /// <summary>
        /// Print expression
        /// </summary>
        public void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write(Operation);
            RightChild.Print();
            Console.Write(")");
        }
    }
}