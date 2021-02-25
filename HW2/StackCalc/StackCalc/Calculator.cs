using System;

namespace StackCalc
{
    class Calculator
    {
        private IStack stack;

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

        public double Calculate(string expressionToCalculate)
        {
            string[] expressionArray = expressionToCalculate.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in expressionArray)
            {
                int numberToPush;
                if (Int32.TryParse(element, out numberToPush))
                {
                    stack.Push(numberToPush);
                    continue;
                }

                switch (element)
                {
                    case "+":
                        {
                            var (element1, element2) = GetTwoElementsFromStack();
                            stack.Push(element1 + element2);
                            break;
                        }
                    case "-":
                        {
                            var (element1, element2) = GetTwoElementsFromStack();
                            stack.Push(element2 - element1);
                            break;
                        }
                    case "*":
                        {
                            var (element1, element2) = GetTwoElementsFromStack();
                            stack.Push(element1 * element2);
                            break;
                        }
                    case "/":
                        {
                            var (element1, element2) = GetTwoElementsFromStack();
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