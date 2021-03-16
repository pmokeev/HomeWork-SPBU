using System;

namespace ArithmeticTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            Console.WriteLine("Enter expression:");
            var expression = Console.ReadLine();

            try
            {
                tree.CreateTree(expression);
            }
            catch (InvalidExpressionException)
            {
                Console.WriteLine("Error! Invalid expression!");
                return;
            }

            Console.Write("Expression = ");
            tree.PrintTree();
            Console.WriteLine($"\nResult = {tree.Calculate()}");
        }
    }
}