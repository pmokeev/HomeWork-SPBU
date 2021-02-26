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
            int valueToWrite = node.HasParent() ? node.GetValueOfParent() : node.GetValue();
            byte[] intBytes = BitConverter.GetBytes(valueToWrite);
            Array.Reverse(intBytes);
            byte[] bytes = intBytes;
            foreach (var b in bytes)
            {
                fileOut.WriteByte(b);
            }
        }

        public static void Compress(string pathToFile)
        {
            string resultPath = pathToFile + ".zipped";

            using (FileStream fileIn = File.OpenRead(pathToFile))
            {
                using (FileStream fileOut = File.OpenWrite(resultPath))
                {
                    HashTrie root = FillStartHashArray();
                    HashTrie pointer = root;
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
                                pointer = root;
                                continue;
                            }
                        }

                        currentByte = (byte)fileIn.ReadByte();
                        counterBytes++;
                    }
                }
            }
        }
    }
}
