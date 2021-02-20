using System;

namespace StackCalc
{
    class Program
    {
        private static void PrintHello()
        {
            Console.WriteLine("Choose one stack option");
            Console.WriteLine("1 - List stack");
            Console.WriteLine("2 - Array stack");
        }

        private static int EntryKey()
        {
            var key = -1;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out key) || (key != 1 && key != 2))
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    return key;
                }
            }
        }

        private static string EnterExpression()
        {
            string expression = Console.ReadLine();
            while (expression.Length == 0 || expression == "\n")
            {
                Console.WriteLine("Try again!");
                expression = Console.ReadLine();
            }

            return expression;
        }

        static void Main(string[] args)
        {
            if (!TestsCalc.ListAllTestsCase() || !TestsCalc.ArrayAllTestsCase())
            {
                Console.WriteLine("Error!");
                return;
            }

            PrintHello();
            int key = EntryKey();
            Console.WriteLine("Enter the string to calculate:");
            string expression = EnterExpression();
            Calculator calculatorStack;

            if (key == 1)
            {
                calculatorStack = new Calculator(new ListStack());
            }
            else
            {
                calculatorStack = new Calculator(new ArrayStack());
            }

            try
            {
                Console.WriteLine($"Answer is: {calculatorStack.Calculate(expression)}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error. Division by zero!");
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Operations are less than numbers");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The expression must be of the form a b + . Not a + b");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Unknown character");
            }
        }
    }
}