using System;

namespace LZWProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!TestsLZW.AllTestsTrie())
            {
                Console.WriteLine("Error!");
                return;
            }
        }
    }
}
