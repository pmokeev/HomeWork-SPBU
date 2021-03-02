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
            int countableIndex = 255;
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

        private static Hashtable FillHashtable()
        {
            var table = new Hashtable();

            for (int i = 0; i < 256; i++)
            {
                table.Add(i, new byte[] { (byte)i });
            }

            return table;
        }

        private static void WriteInOutFile(byte[] byteArray, FileStream fileOut)
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

        public static void Decompress(string pathToFile)
        {
            string resultPath = pathToFile.Substring(0, pathToFile.Length - 7);
            using FileStream fileIn = File.OpenRead(pathToFile);
            using FileStream fileOut = File.OpenWrite(resultPath);

            Hashtable table = FillHashtable();

            int countableIndex = 255;
            int period = 4;
            byte firstByte = 0;
            byte[] bytesArray;

            int oldKey = ReadKey(fileIn);
            WriteInOutFile((byte[])table[oldKey], fileOut);

            for (int i = 4; i < fileIn.Length; i += period)
            {
                int newKey = ReadKey(fileIn);

                if (table.ContainsKey(newKey))
                {
                    bytesArray = (byte[])table[newKey];
                }
                else
                {
                    bytesArray = (byte[])table[oldKey];
                    Array.Resize(ref bytesArray, bytesArray.Length + 1);
                    bytesArray[bytesArray.Length - 1] = bytesArray[0];
                }

                WriteInOutFile(bytesArray, fileOut);

                firstByte = bytesArray[0];

                byte[] oldByteArray = (byte[])table[oldKey];
                Array.Resize(ref oldByteArray, oldByteArray.Length + 1);
                oldByteArray[oldByteArray.Length - 1] = firstByte;

                countableIndex++;
                table.Add(countableIndex, oldByteArray);

                oldKey = newKey;
            }
        }
    }
}