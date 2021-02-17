using System;

namespace BWTAlgorithm
{
    public interface IComparable
    {
        int CompareTo(object secondComp);
    }

    public class Suffix : IComparable<Suffix>
    {
        public int index;
        public int rank;
        public int next;
        public Suffix(int newIndex, int newRank, int newNextRank)
        {
            index = newIndex;
            rank = newRank;
            next = newNextRank;
        }

        public int CompareTo(Suffix secondSuf)
        {
            if (this.rank != secondSuf.rank)
            {
                return this.rank.CompareTo(secondSuf.rank);
            }
            return this.next.CompareTo(secondSuf.next);
        }
    }

    class BWTransform
    {
        private static int[] SuffixArray(string curString)
        {
            int n = curString.Length;
            Suffix[] suffixesArray = new Suffix[n];

            for (int i = 0; i < n; i++)
            {
                suffixesArray[i] = new Suffix(i, curString[i] - 'a', 0);
            }

            for (int i = 0; i < n; i++)
            {
                if (i + 1 < n)
                {
                    suffixesArray[i].next = suffixesArray[i + 1].rank;
                }
                else
                {
                    suffixesArray[i].next = -1;
                }
            }

            Array.Sort(suffixesArray);

            int[] ind = new int[n];

            for (int length = 4; length < 2 * n; length <<= 1)
            {
                int rank = 0;
                int prevRank = suffixesArray[0].rank;
                suffixesArray[0].rank = rank;
                ind[suffixesArray[0].index] = 0;

                for (int i = 1; i < n; i++)
                {
                    if (suffixesArray[i].rank == prevRank && suffixesArray[i].next == suffixesArray[i - 1].next)
                    {
                        prevRank = suffixesArray[i].rank;
                        suffixesArray[i].rank = rank;
                    }
                    else
                    {
                        prevRank = suffixesArray[i].rank;
                        suffixesArray[i].rank = ++rank;
                    }
                    ind[suffixesArray[i].index] = i;
                }
                for (int i = 0; i < n; i++)
                {
                    int nextPoint = suffixesArray[i].index + length / 2;
                    if (nextPoint < n)
                    {
                        suffixesArray[i].next = suffixesArray[ind[nextPoint]].rank;
                    }
                    else
                    {
                        suffixesArray[i].next = -1;
                    }
                }
                Array.Sort(suffixesArray);
            }
            var resultArray = new int[n];

            for (int i = 0; i < n; i++)
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

        private static string[,] StringCounterArray(char[] charArray)
        {
            var mainArray = new string[charArray.Length, 2];

            for (int i = 0; i < charArray.Length; i++)
            {
                mainArray[i, 0] = Convert.ToString(charArray[i]);
                mainArray[i, 1] = Convert.ToString(CountElement(charArray, charArray[i], i));
            }

            return mainArray;
        }

        private static int IndexInArray(string[,] mainArray, string symbol, string indexSymbol)
        {
            for (int i = 0; i < mainArray.Length; i++)
            {
                if (mainArray[i, 0] == symbol && mainArray[i, 1] == indexSymbol)
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

            string[,] stringMainArray = StringCounterArray(mainArray);
            string[,] stringSortedMainArray = StringCounterArray(sortedMainArray);

            var resultString = "";
            var currentSymbol = "$";
            var indexSymbol = "1";
            string nextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol), 0];
            string indexNextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol), 1];

            while (nextSymbol[0] != '$')
            {
                resultString += nextSymbol;

                currentSymbol = nextSymbol;
                indexSymbol = indexNextSymbol;
                nextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol), 0];
                indexNextSymbol = stringSortedMainArray[IndexInArray(stringMainArray, currentSymbol, indexSymbol), 1];
            }

            return resultString;
        }
    }
}
