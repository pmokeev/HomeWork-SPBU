namespace ArithmeticTree
{
    /// <summary>
    /// Subtraction operation class
    /// </summary>
    public class Subtraction : Operator
    {
        /// <summary>
        /// Operation sign
        /// </summary>
        public override char Operation { get; } = '-';

        /// <summary>
        /// Subtraction result
        /// </summary>
        public override float Calculate()
            => LeftChild.Calculate() - RightChild.Calculate();
    }
}