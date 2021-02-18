using System;

namespace BWTAlgorithm
{
    public interface IComparable
    {
        int CompareTo(object element);
    }

    class Suffix : IComparable<Suffix>
    {
        public int index;
        public int rank;
        public int nextRank;
        public Suffix(int newIndex, int newRank, int newNextRank)
        {
            index = newIndex;
            rank = newRank;
            nextRank = newNextRank;
        }

        public int CompareTo(Suffix secondSuffix)
        {
            if (this.rank != secondSuffix.rank)
            {
                return this.rank.CompareTo(secondSuffix.rank);
            }
            return this.nextRank.CompareTo(secondSuffix.nextRank);
        }
    }

    class BWTransform
    {
        private static int[] SuffixArray(string curString)
        {
            var lenString = curString.Length;
            var suffixesArray = new Suffix[lenString];

            for (int i = 0; i < lenString; i++)
            {
                suffixesArray[i] = new Suffix(i, curString[i] - 'a', 0);
            }

            for (int i = 0; i < lenString; i++)
            {
                if (i + 1 < lenString)
                {
                    suffixesArray[i].nextRank = suffixesArray[i + 1].rank;
                }
                else
                {
                    suffixesArray[i].nextRank = -1;
                }
            }

            Array.Sort(suffixesArray);

            var indexes = new int[lenString];

            for (int length = 4; length < 2 * lenString; length <<= 1)
            {
                var currentRank = 0;
                int preventRank = suffixesArray[0].rank;
                suffixesArray[0].rank = currentRank;
                indexes[suffixesArray[0].index] = 0;

                for (int i = 1; i < lenString; i++)
                {
                    if (suffixesArray[i].rank == preventRank && suffixesArray[i].nextRank == suffixesArray[i - 1].nextRank)
                    {
                        preventRank = suffixesArray[i].rank;
                        suffixesArray[i].rank = currentRank;
                    }
                    else
                    {
                        preventRank = suffixesArray[i].rank;
                        suffixesArray[i].rank = ++currentRank;
                    }

                    indexes[suffixesArray[i].index] = i;
                }

                for (int i = 0; i < lenString; i++)
                {
                    var nextPoint = suffixesArray[i].index + length / 2;
                    if (nextPoint < lenString)
                    {
                        suffixesArray[i].nextRank = suffixesArray[indexes[nextPoint]].rank;
                    }
                    else
                    {
                        suffixesArray[i].nextRank = -1;
                    }
                }
                Array.Sort(suffixesArray);
            }
            var resultArray = new int[lenString];

            for (int i = 0; i < lenString; i++)
            {
                resultArray[i] = suffixesArray[i].index;

            }
            return resultArray;
        }

        public static string StraightBWT(string currentString)
        {
            if (currentString.Length == 0)
            {
                return currentString;
            }

            currentString += "$";
            var lenStartString = currentString.Length;
            int[] suffixArray = SuffixArray(currentString);

            var resultString = "";

            foreach (var element in suffixArray)
            {
                resultString += currentString[(element + lenStartString - 1) % lenStartString];
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

        private static Tuple<string, int>[] StringCounterArray(char[] charArray)
        {
            var mainArray = new Tuple<string, int>[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                mainArray[i] = new Tuple<string, int>(Convert.ToString(charArray[i]), CountElement(charArray, charArray[i], i));
            }

            return mainArray;
        }

        private static int IndexInArray(Tuple<string, int>[] mainArray, string symbol, int indexSymbol)
        {
            for (int i = 0; i < mainArray.Length; i++)
            {
                if (mainArray[i].Item1 == symbol && mainArray[i].Item2 == indexSymbol)
                {
                    return i;
                }
            }

            return -1;
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

            Tuple<string, int>[] stringMainArray = StringCounterArray(mainArray);
            Tuple<string, int>[] stringSortedMainArray = StringCounterArray(sortedMainArray);

            var resultString = "";
            var currentSymbol = "$";
            int indexSymbol = 1;
            string nextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol)].Item1;
            int indexNextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol)].Item2;

            while (nextSymbol[0] != '$')
            {
                resultString += nextSymbol;

                currentSymbol = nextSymbol;
                indexSymbol = indexNextSymbol;
                nextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol)].Item1;
                indexNextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol)].Item2;
            }

            return resultString;
        }
    }
}
