using System;

namespace SortingArray
{
    class AlgorithmSorting
    {
        public static void BubbleSort(int[] currentArray)
        {
            if (currentArray.Length == 0)
            {
                return;
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
        }
    }
}