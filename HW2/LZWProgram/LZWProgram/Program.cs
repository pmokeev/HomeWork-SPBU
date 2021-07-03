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

            if (args[0] != "-c" && args[0] != "-u" && args.Length != 2)
            {
                Console.WriteLine("Error! Please, try again.");
            }

            if (args[0] == "-c")
            {
                if (!File.Exists(args[1]))
                {
                    Console.WriteLine("Error! File not found.");
                    return;
                }
                else if (File.Exists(args[1] + ".zipped"))
                {
                    Console.WriteLine("Error! .zipped file already exists. Please, try again.");
                    return;
                }

                var startFile = new FileInfo(args[1]);
                var startFileLength = (int)startFile.Length;
                LZWAlgorithm.Compress(args[1]);
                var compressedFile = new FileInfo(args[1] + ".zipped");
                var compressedFileLength = (int)compressedFile.Length;

                Console.WriteLine($"Compression ratio = {(float)startFileLength / compressedFileLength}");
                Console.WriteLine("Done!");
            }
            else if (args[0] == "-u")
            {
                if (!File.Exists(args[1]))
                {
                    Console.WriteLine("Error! File not found.");
                    return;
                }
                else if (File.Exists(args[1].Substring(0, args[1].Length - 7)))
                {
                    Console.WriteLine("Error! Uncompressed file already exists. Please, try again.");
                    return;
                }

                LZWAlgorithm.Decompress(args[1]);
                Console.WriteLine("Done!");
            }
        }
    }
}