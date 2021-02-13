using System;

namespace SortingArray
{
    class Program
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

        static void Main(string[] args)
        {
            if (!TestsAlgorithm.AllTestsCase())
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine("Enter size of array:");

            int sizeArray = EntrySize();

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