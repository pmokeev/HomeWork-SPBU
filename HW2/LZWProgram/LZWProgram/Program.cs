using System;
using System.IO;

namespace LZWProgram
{
    class Program
    {
        private static void HelloMessage()
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("-c (space) filepath to compress file");
            Console.WriteLine("-u (space) filepath to uncompress file");
        }

        static void Main(string[] args)
        {
            HelloMessage();
            string enterString;
            string[] paramsArray;

            while (true)
            {
                enterString = Console.ReadLine();
                paramsArray = enterString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (paramsArray[0] != "-c" && paramsArray[0] != "-u")
                {
                    Console.WriteLine("Error! Please, try again.");
                    HelloMessage();
                }
                else
                {
                    break;
                }
            }

            if (paramsArray[0] == "-c")
            {
                if (!File.Exists(paramsArray[1]))
                {
                    Console.WriteLine("Error! File not found.");
                    return;
                }
                else if (File.Exists(paramsArray[1] + ".zipped"))
                {
                    Console.WriteLine("Error! .zipped file already exists. Please, try again.");
                    return;
                }

                var startFile = new FileInfo(paramsArray[1]);
                var startFileLength = (int)startFile.Length;
                LZWAlgorithm.Compress(paramsArray[1]);
                var compressedFile = new FileInfo(paramsArray[1] + ".zipped");
                var compressedFileLength = (int)compressedFile.Length;

                Console.WriteLine($"Compression ratio = {(float)startFileLength / compressedFileLength}");
                Console.WriteLine("Done!");
            }
            else if (paramsArray[0] == "-u")
            {
                if (!File.Exists(paramsArray[1]))
                {
                    Console.WriteLine("Error! File not found.");
                    return;
                }
                else if (File.Exists(paramsArray[1].Substring(0, paramsArray[1].Length - 7)))
                {
                    Console.WriteLine("Error! Uncompressed file already exists. Please, try again.");
                    return;
                }

                LZWAlgorithm.Decompress(paramsArray[1]);
                Console.WriteLine("Done!");
            }
        }
    }
}