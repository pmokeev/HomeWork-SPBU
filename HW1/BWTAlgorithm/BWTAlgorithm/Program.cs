using System;

namespace BWTAlgorithm
{
    class Program
    {
        private static void PrintHello()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - encode message");
            Console.WriteLine("2 - decode message");
            Console.WriteLine("Enter key");
        }

        private static int EnterKey()
        {
            int keyInput = 0;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out keyInput) || (keyInput != 1 && keyInput != 2))
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    return keyInput;
                }
            }
        }

        static void Main(string[] args)
        {
            if (!TestsBWT.AllTestsCaseBWT() || !TestsBWT.AllTestsCaseBWTReverse())
            {
                Console.WriteLine("Error!");
                return;
            }

            PrintHello();
            int key = EnterKey();

            if (key == 1)
            {
                Console.WriteLine("Enter string to encode without $:");
                var currentString = Console.ReadLine();

                Console.WriteLine("Result string:");
                Console.WriteLine(BWTransform.StraightBWT(currentString));
            }
            else
            {
                Console.WriteLine("Enter string to decode with $:");
                var currentString = Console.ReadLine();

                Console.WriteLine("Result string:");
                Console.WriteLine(BWTransform.ReverseBWT(currentString));
            }

        }
    }
}
