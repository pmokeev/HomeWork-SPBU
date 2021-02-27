using System;
using System.IO;

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

        private static void WriteInFile(FileStream fileOut, HashTrie node)
        {
            int valueToWrite = node.GetValue();
            byte[] intBytes = BitConverter.GetBytes(valueToWrite);
            Array.Reverse(intBytes);
            byte[] bytes = intBytes;

            if (valueToWrite == 0)
            {
                fileOut.WriteByte((byte)0);
            }
            else
            {
                int startIndex = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] != (byte)0)
                    {
                        startIndex = i;
                        break;
                    }
                }

                for (int i = startIndex; i < bytes.Length; i++)
                {
                    fileOut.WriteByte((byte)bytes[i]);
                }
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
                    WriteInFile(fileOut, pointer);
                }
                else
                {
                    if (pointer.HasChild(currentByte))
                    {
                        pointer.GetChild(currentByte);
                    }
                    else
                    {
                        WriteInFile(fileOut, pointer);
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
