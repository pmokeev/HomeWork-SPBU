using System;

namespace ArithmeticTree
{
    /// <summary>
    /// A class that implements an arithmetic parsing tree
    /// </summary>
    public class Tree
    {
        private INode root;
        private int index = 0;

        private static int ReadNumber(ref int index, string expression)
        {
            var resultNumber = "";

            while (char.IsDigit(expression[index]))
            {
                resultNumber += expression[index];
                index++;
            }

            return Int32.Parse(resultNumber);
        }

        private bool IsOperation(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        private Operator GetOperation(char symbol)
        {
            return symbol switch
            {
                '-' => new Subtraction(),
                '+' => new Addition(),
                '*' => new Multiplication(),
                '/' => new Division(),
                _ => throw new Exception(),
            };
        }

        private INode CreateNode(string expression, ref int index)
        {
            while (expression[index] == '(' || expression[index] == ' ' || expression[index] == ')')
            {
                index++;
            }

            if (char.IsDigit(expression[index]))
            {
                var operandValue = new Operand(ReadNumber(ref index, expression));

                return operandValue;
            }
            else if (IsOperation(expression[index]))
            {
                Operator arithmeticOperation = GetOperation(expression[index]);
                index++;

                arithmeticOperation.LeftChild = CreateNode(expression, ref index);
                arithmeticOperation.RightChild = CreateNode(expression, ref index);

                return arithmeticOperation;
            }
            else
            {
                return null;
            }
        }

        private bool CheckExpression(string expression)
        {
            int counter = 0;
            int indexCheck = 0;

            while (indexCheck != expression.Length)
            {
                if (expression[indexCheck] == '(' || expression[indexCheck] == ' ' || expression[indexCheck] == ')')
                {
                    indexCheck++;
                }
                else if (char.IsDigit(expression[indexCheck]))
                {
                    int number = ReadNumber(ref indexCheck, expression);
                    indexCheck++;
                    counter++;
                }
                else if (IsOperation(expression[indexCheck]))
                {
                    indexCheck++;
                    counter--;
                }
                else
                {
                    return false;
                }
            }

            return counter == 0;
        }

        /// <summary>
        /// Create a tree for a given expression
        /// </summary>
        /// <param name="expression">Given expression</param>
        public void CreateTree(string expression)
        {
            if (CheckExpression(expression))
            {
                throw new InvalidExpressionException();
            }

            root = CreateNode(expression, ref index);
        }

        /// <summary>
        /// Print tree
        /// </summary>
        public void PrintTree()
            => root.Print();

        /// <summary>
        /// Calculate the result of an expression
        /// </summary>
        public float Calculate()
            => root.Calculate();
    }
}