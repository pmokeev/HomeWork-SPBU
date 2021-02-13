using System;

namespace SortingArray
{
    class TestsAlgorithm
    {
        private static bool IsSimilarArrays(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CorrectTestCase()
        {
            const int sizeArray = 5;

            var startArray = new int[sizeArray] { 35, 55, 66, 2, 79 };
            var endArray = new int[sizeArray] { 2, 35, 55, 66, 79 };

            return IsSimilarArrays(AlgorithmSorting.BubbleSort(startArray), endArray);
        }

        private static bool UncorrectTestCase()
        {
            const int sizeArray = 10;

            var startArray = new int[sizeArray] { 55, 59, 12, 31, 34, 47, 42, 71, 29, 38 };
            var endArray = new int[sizeArray] { 55, 59, 12, 31, 34, 47, 42, 71, 29, 38 };

            return IsSimilarArrays(AlgorithmSorting.BubbleSort(startArray), endArray);
        }

        private static bool EmptyArrayTest()
        {
            const int sizeArray = 0;

            var startArray = new int[sizeArray];
            var endArray = new int[sizeArray];

            return IsSimilarArrays(AlgorithmSorting.BubbleSort(startArray), endArray);
        }

        private static bool OneElementTest()
        {
            const int sizeArray = 1;

            var startArray = new int[sizeArray] { 1 };
            var endArray = new int[sizeArray] { 1 };

            return IsSimilarArrays(AlgorithmSorting.BubbleSort(startArray), endArray);
        }

        public static bool AllTestsCase()
        {
            return CorrectTestCase() && !UncorrectTestCase() && EmptyArrayTest() && OneElementTest();
        }
    }
}