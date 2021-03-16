namespace ArithmeticTree
{
    /// <summary>
    /// Multiplication operation class
    /// </summary>
    public class Multiplication : Operator
    {
        /// <summary>
        /// Operation sign
        /// </summary>
        public override char Operation { get; } = '*';

        /// <summary>
        /// Multiplication result
        /// </summary>
        public override float Calculate()
            => LeftChild.Calculate() * RightChild.Calculate();
    }
}