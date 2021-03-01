using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace LZWProgram
{
    public class LZWAlgorithm
    {
        private static HashTrie FillStartHashArray()
        {
            var root = new HashTrie();

            for (int i = 0; i < 256; i++)
            {
                root.Insert((byte)i, i);
            }

            return root;
        }

        private static void WriteInFile(FileStream fileOut, int valueToWrite)
        {
            byte[] intBytes = BitConverter.GetBytes(valueToWrite);
            Array.Reverse(intBytes);

            foreach (var item in intBytes)
            {
                fileOut.WriteByte(item);
            }
        }

        public static void Compress(string pathToFile)
        {
            string resultPath = pathToFile + ".zipped";

            using FileStream fileIn = File.OpenRead(pathToFile);
            using FileStream fileOut = File.OpenWrite(resultPath);
            HashTrie pointer = FillStartHashArray();
            int countableIndex = 256;
            int counterBytes = 1;
            byte currentByte = (byte)fileIn.ReadByte();

            while (counterBytes != fileIn.Length)
            {
                if (counterBytes == fileIn.Length - 1)
                {
                    WriteInFile(fileOut, pointer.GetValue());
                }
                else
                {
                    if (pointer.HasChild(currentByte))
                    {
                        pointer.GetChild(currentByte);
                    }
                    else
                    {
                        WriteInFile(fileOut, pointer.GetValue());
                        countableIndex++;
                        pointer.Insert(currentByte, countableIndex);
                        pointer.GoToRoot();
                        continue;
                    }
                 }

                currentByte = (byte)fileIn.ReadByte();
                counterBytes++;
            }
        }
    }
}