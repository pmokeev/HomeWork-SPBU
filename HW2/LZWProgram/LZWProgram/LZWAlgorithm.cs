using System;
using System.IO;
using System.Collections;

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

        private static void WriteInFileCompress(FileStream fileOut, int valueToWrite)
        {
            byte[] intBytes = BitConverter.GetBytes(valueToWrite);
            Array.Reverse(intBytes);

            foreach (var item in intBytes)
            {
                fileOut.WriteByte(item);
            }
        }

        /// <summary>
        /// Compress file, creating .zipped file
        /// </summary>
        /// <param name="pathToFile">Path to initial file</param>
        public static void Compress(string pathToFile)
        {
            string resultPath = pathToFile + ".zipped";

            using FileStream fileIn = File.OpenRead(pathToFile);
            using FileStream fileOut = File.OpenWrite(resultPath);
            HashTrie pointer = FillStartHashArray();
            int countableIndex = 255;
            int counterBytes = 1;
            byte currentByte = (byte)fileIn.ReadByte();

            while (counterBytes != fileIn.Length)
            {
                if (counterBytes == fileIn.Length - 1)
                {
                    WriteInFileCompress(fileOut, pointer.GetValue());
                }
                else
                {
                    if (pointer.HasChild(currentByte))
                    {
                        pointer.GetChild(currentByte);
                    }
                    else
                    {
                        WriteInFileCompress(fileOut, pointer.GetValue());
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

        private static Hashtable FillHashtable()
        {
            var hashArray = new Hashtable();

            for (int i = 0; i < 256; i++)
            {
                hashArray.Add(i, new byte[] { (byte)i });
            }

            return hashArray;
        }

        private static void WriteInFileDecompress(byte[] byteArray, FileStream fileOut)
        {
            foreach (var item in byteArray)
            {
                fileOut.WriteByte(item);
            }
        }

        private static int ReadKey(FileStream fileIn)
        {
            var arrayBytes = new byte[4];

            for (int i = 0; i < arrayBytes.Length; i++)
            {
                arrayBytes[i] = (byte)fileIn.ReadByte();
            }

            Array.Reverse(arrayBytes);
            return BitConverter.ToInt32(arrayBytes);
        }

        /// <summary>
        /// Decompress .zipped file
        /// </summary>
        /// <param name="pathToFile">Path to .zipped file</param>
        public static void Decompress(string pathToFile)
        {
            string resultPath = pathToFile.Substring(0, pathToFile.Length - 7);
            using FileStream fileIn = File.OpenRead(pathToFile);
            using FileStream fileOut = File.OpenWrite(resultPath);

            Hashtable hashArray = FillHashtable();

            int countableIndex = 255;
            int bytePerRead = 4;
            byte firstByte = 0;
            byte[] bytesArray;

            int oldKey = ReadKey(fileIn);
            WriteInFileDecompress((byte[])hashArray[oldKey], fileOut);

            for (int i = 4; i < fileIn.Length; i += bytePerRead)
            {
                int newKey = ReadKey(fileIn);

                if (hashArray.ContainsKey(newKey))
                {
                    bytesArray = (byte[])hashArray[newKey];
                }
                else
                {
                    bytesArray = (byte[])hashArray[oldKey];
                    Array.Resize(ref bytesArray, bytesArray.Length + 1);
                    bytesArray[bytesArray.Length - 1] = bytesArray[0];
                }

                WriteInFileDecompress(bytesArray, fileOut);

                firstByte = bytesArray[0];
                byte[] oldKeyArray = (byte[])hashArray[oldKey];
                Array.Resize(ref oldKeyArray, oldKeyArray.Length + 1);
                oldKeyArray[oldKeyArray.Length - 1] = firstByte;
                countableIndex++;
                hashArray.Add(countableIndex, oldKeyArray);

                oldKey = newKey;
            }
        }
    }
}