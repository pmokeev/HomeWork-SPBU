namespace ArithmeticTree
{
    /// <summary>
    /// Addition operation class
    /// </summary>
    public class Addition : Operator
    {
        /// <summary>
        /// Operation sign
        /// </summary>
        public override char Operation { get; } = '+';

        /// <summary>
        /// Addition result
        /// </summary>
        public override float Calculate()
            => LeftChild.Calculate() + RightChild.Calculate();
    }
}