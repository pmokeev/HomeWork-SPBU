using System;

namespace SortingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!TestsAlgorithm.AllTestsCase())
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine("Enter size of array:");

            int sizeArray = AlgorithmSorting.EntrySize();

            Random random = new Random();

            var mainArray = new int[sizeArray];

            Console.WriteLine("Start array:");
            for (int i = 0; i < sizeArray; i++)
            {
                mainArray[i] = random.Next() % 100;
                Console.Write($"{mainArray[i]} ");
            }

            mainArray = AlgorithmSorting.BubbleSort(mainArray);

            Console.WriteLine("\nRezult array:");
            foreach (int element in mainArray)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
