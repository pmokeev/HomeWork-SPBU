using System;

namespace StackCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            ListStack stack = new ListStack();

            stack.Push(10);
            stack.Push(20);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch 
            {
                Console.WriteLine("Error!");
            }

            Console.WriteLine("Good!");
        }
    }
}
