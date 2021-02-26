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

        private static void WriteInFile(FileStream fileOut, HashTrie node, int newIndex)
        {
            return;
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

                    for (int byteIndex = 0; byteIndex < fileIn.Length; byteIndex++)
                    {
                        byte currentByte = (byte)fileIn.ReadByte();

                        if (byteIndex == fileIn.Length - 1)
                        {
                            // Запись countableIndex в файл 
                            continue;
                        }
                        else
                        {
                            if (pointer.HasChild(currentByte))
                            {
                                pointer.GetChild(currentByte);
                            }
                            else
                            {
                                WriteInFile(fileOut, pointer, pointer.GetValueOfParent());
                                countableIndex++;
                                pointer.Insert(currentByte, countableIndex);
                                pointer = root;
                            }
                        }
                    }
                }
            }
        }
    }
}
