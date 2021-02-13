using System;

namespace SortingArray
{
    class AlgorithmSorting
    {
        public static int EntrySize()
        {
            int sizeArray = -1;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out sizeArray))
                {
                    Console.WriteLine("Try again!");
                }
                else if (sizeArray <= 0)
                {
                    Console.WriteLine("Size must be positive. Try again!");
                }
                else
                {
                    return sizeArray;
                }
            }
        }

        public static int[] BubbleSort(int[] currentArray)
        {
            if (currentArray.Length == 0)
            {
                return currentArray;
            }
            for (int i = 0; i < currentArray.Length; i++)
            {
                for (int j = 0; j < currentArray.Length - 1; j++)
                {
                    if (currentArray[j] > currentArray[j + 1])
                    {
                        int temp = currentArray[j];
                        currentArray[j] = currentArray[j + 1];
                        currentArray[j + 1] = temp;
                    }
                }
            }

            return currentArray;
        }
    }
}
