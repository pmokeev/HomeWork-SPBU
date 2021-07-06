using System;
using System.Collections.Generic;
using System.Linq;

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
        public static IEnumerable<TResult> Map<TInit, TResult>(IEnumerable<TInit> currentList, Func<TInit, TResult> function)
        {
            var resultList = new List<TResult>();
            
            foreach (var item in currentList)
            {
                resultList.Add(function(item));
            }
            
            return resultList;
        }

        /// <summary>
        /// The function finds items in a List that satisfy a condition 
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="function">Function that checks the condition for each element of the List</param>
        /// <returns>A List composed of those elements of the passed list for which the passed function returned true.</returns>
        public static IEnumerable<TInit> Filter<TInit>(IEnumerable<TInit> currentList, Func<TInit, bool> function)
        {
            var resultList = new List<TInit>();

            foreach (var item in currentList)
            {
                if (function(item))
                {
                    resultList.Add(item);
                }
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
        public static TResult Fold<TInit, TResult>(IEnumerable<TInit> currentList, TResult startValue, Func<TResult, TInit, TResult> function)
        {
            foreach (var item in currentList)
            {
                startValue = function(startValue, item);
            }
            
            return startValue;
        }
    }
}