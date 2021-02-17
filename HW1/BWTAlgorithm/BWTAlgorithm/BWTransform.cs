using System;

namespace BWTAlgorithm
{
    class BWTransform
    {
        private static string[] CreateSuffixArray(string currentString)
        {
            var suffixArray = new string[currentString.Length];

            for (int i = 0; i < currentString.Length; i++)
            {
                suffixArray[i] = currentString.Substring(i);
            }

            return suffixArray;
        }

        public static string StraightBWT(string currentString)
        {
            if (currentString.Length == 0)
            {
                return currentString;
            }

            currentString += "$";
            var lenStartString = currentString.Length;
            string[] suffixArray = CreateSuffixArray(currentString);
            Array.Sort(suffixArray);

            var resultString = "";

            foreach (var element in suffixArray)
            {
                resultString += currentString[(2 * lenStartString - element.Length - 1) % lenStartString];
            }

            return resultString;
        }

        private static int CountElement(char[] arrayChar, char element, int indexSearch)
        {
            var counter = 0;

            for (int i = 0; i < indexSearch; i++)
            {
                if (arrayChar[i] == element)
                {
                    counter++;
                }
            }

            return counter + 1;
        }

        private static string[] StringCounterArray(char[] charArray)
        {
            var lenArray = charArray.Length;
            var stringArray = new string[lenArray];
            for (int i = 0; i < lenArray; i++)
            {
                stringArray[i] = Convert.ToString(charArray[i]) + Convert.ToString(CountElement(charArray, charArray[i], i));
            }

            return stringArray;
        }

        public static string ReverseBWT(string currentString)
        {
            if (currentString.Length == 0)
            {
                return currentString;
            }

            char[] mainArray = currentString.ToCharArray();
            var sortedMainArray = new char[currentString.Length];
            Array.Copy(mainArray, sortedMainArray, currentString.Length);
            Array.Sort(sortedMainArray);

            var stringMainArray = StringCounterArray(mainArray);
            var stringSortedMainArray = StringCounterArray(sortedMainArray);

            var resultString = "";
            var currentSymbol ="$1";
            var nextSymbol = stringSortedMainArray[Array.IndexOf(stringMainArray, currentSymbol)];

            while (nextSymbol[0] != '$')
            {
                resultString += Convert.ToString(nextSymbol[0]);

                currentSymbol = nextSymbol;
                nextSymbol = stringSortedMainArray[Array.IndexOf(stringMainArray, currentSymbol)];
            }

            return resultString;
        }
    }
}
