using System;
using System.IO;

namespace LZWProgram
{
    class LZWAlgorithm
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

        public static void Compress(string pathToFile)
        {
            string resultPath = pathToFile + ".zipped";

            using (FileStream fileIn = File.OpenRead(pathToFile))
            {
                using (FileStream fileOut = File.OpenWrite(resultPath))
                {
                    HashTrie root = FillStartHashArray();
                    HashTrie pointer = root;
                    int countableIndex = 0;

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
                                // Запись countableIndex текущего байта в файл 
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
