using System;

namespace StackCalcAppVeyor
{
    /// <summary>
    /// Calculator class on stack
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        /// <summary>
        /// Constructor of Calculator
        /// </summary>
        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        private (float, float) GetTwoElementsFromStack()
        {
            float element1 = stack.Pop();
            float element2 = stack.Pop();

            return (element1, element2);
        }

        /// <summary>
        /// Function that evaluates the value of an expression
        /// </summary>
        public double Calculate(string expressionToCalculate)
        {
            string[] expressionArray = expressionToCalculate.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in expressionArray)
            {
                if (Int32.TryParse(element, out int numberToPush))
                {
                    stack.Push(numberToPush);
                    continue;
                }

                var (element1, element2) = GetTwoElementsFromStack();
                switch (element)
                {
                    case "+":
                        {
                            stack.Push(element1 + element2);
                            break;
                        }
                    case "-":
                        {
                            stack.Push(element2 - element1);
                            break;
                        }
                    case "*":
                        {
                            stack.Push(element1 * element2);
                            break;
                        }
                    case "/":
                        {
                            if (Math.Abs(element1) < 0.0000001)
                            {
                                throw new DivideByZeroException();
                            }

                            stack.Push(element2 / element1);
                            break;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
            }

            float answerExpression = stack.Pop();

            if (!stack.IsEmpty())
            {
                throw new ArithmeticException();
            }

            return answerExpression;
        }
    }
}
