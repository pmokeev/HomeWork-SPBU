using System;

namespace ArithmeticTree
{
    /// <summary>
    /// Division operation class
    /// </summary>
    public class Division : Operator
    {
        /// <summary>
        /// Operation sign
        /// </summary>
        public override char Operation { get; } = '/';

        private float Divide(float firstNumber, float secondNumber)
        {
            if (Math.Abs(secondNumber) < 0.000001)
            {
                throw new DivideByZeroException("Error! Divide by zero.");
            }

            return firstNumber / secondNumber;
        }

        /// <summary>
        /// Division result
        /// </summary>
        public override float Calculate()
            => Divide(LeftChild.Calculate(), RightChild.Calculate());
    }
}