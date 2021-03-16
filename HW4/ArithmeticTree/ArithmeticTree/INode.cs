namespace ArithmeticTree
{
    /// <summary>
    /// Interface node in arithmetic tree
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Print node
        /// </summary>
        public void Print();

        /// <summary>
        /// Calculate value
        /// </summary>
        public float Calculate();
    }
}