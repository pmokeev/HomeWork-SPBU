using System;
using System.Collections.Generic;

namespace MFF
{
    /// <summary>
    /// Class with functions: Map, Filter, Fold
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Function that transforms List items
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="function">A function that applies to each element</param>
        /// <returns>The List obtained by applying the passed function to each element of the passed list.</returns>
        public static List<int> Map(List<int> currentList, Func<int, int> function)
        {
            var newList = new List<int>();

            for (int i = 0; i < currentList.Count; i++)
            {
                newList.Add(function(currentList[i]));
            }

            return newList;
        }

        /// <summary>
        /// A function that returns a boolean value for each value in the List
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="function">Function that checks the condition for each element of the List</param>
        /// <returns>A List composed of those elements of the passed list for which the passed function returned true.</returns>
        public static List<bool> Filter(List<int> currentList, Func<int, bool> function)
        {
            var resultList = new List<bool>();

            foreach (var item in currentList)
            {
                resultList.Add(function(item));
            }

            return resultList;
        }

        /// <summary>
        /// Function that calculates the accumulated value in the List
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="startValue">The initial value of the accumulating variable</param>
        /// <param name="function">Value reading function</param>
        /// <returns>The accumulated value resulting from the entire iteration of the List.</returns>
        public static int Fold(List<int> currentList, int startValue, Func<int, int, int> function)
        {
            foreach (var currentValue in currentList)
            {
                startValue = function(startValue, currentValue);
            }

            return startValue;
        }
    }
}