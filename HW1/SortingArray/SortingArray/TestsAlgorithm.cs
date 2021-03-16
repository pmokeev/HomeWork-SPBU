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
            var startArray = new int[] { 35, 55, 66, 2, 79 };
            var endArray = new int[] { 2, 35, 55, 66, 79 };

            AlgorithmSorting.BubbleSort(startArray);

            return IsSimilarArrays(startArray, endArray);
        }

        private static bool UncorrectTestCase()
        {
            var startArray = new int[] { 55, 59, 12, 31, 34, 47, 42, 71, 29, 38 };
            var endArray = new int[] { 55, 59, 12, 31, 34, 47, 42, 71, 29, 38 };

            AlgorithmSorting.BubbleSort(startArray);

            return IsSimilarArrays(startArray, endArray);
        }

        private static bool EmptyArrayTest()
        {
            const int sizeArray = 0;

            var startArray = new int[sizeArray];
            var endArray = new int[sizeArray];

            AlgorithmSorting.BubbleSort(startArray);

            return IsSimilarArrays(startArray, endArray);
        }

        private static bool OneElementTest()
        {
            var startArray = new int[] { 1 };
            var endArray = new int[] { 1 };

            AlgorithmSorting.BubbleSort(startArray);

            return IsSimilarArrays(startArray, endArray);
        }

        public static bool AllTestsCase()
        {
            return CorrectTestCase() && !UncorrectTestCase() && EmptyArrayTest() && OneElementTest();
        }
    }
}