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
