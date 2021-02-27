using System;
using System.Collections;

namespace LZWProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Pavel\\Documents\\HomeworkSPBU\\HW2\\LZWProgram\\LZWProgram\\test.txt";

            LZWAlgorithm.Compress(path);
        }
    }
}
