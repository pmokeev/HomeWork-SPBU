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
        public static IEnumerable<TInit> Map<TInit>(IEnumerable<TInit> currentList, Func<TInit, TInit> function)
            => currentList.Select(function);

        /// <summary>
        /// A function that returns a boolean value for each value in the List
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="function">Function that checks the condition for each element of the List</param>
        /// <returns>A List composed of those elements of the passed list for which the passed function returned true.</returns>
        public static IEnumerable<TResult> Filter<TInit, TResult>(IEnumerable<TInit> currentList, Func<TInit, TResult> function)
            => currentList.Select(function);

        /// <summary>
        /// Function that calculates the accumulated value in the List
        /// </summary>
        /// <param name="currentList">The List to which the function is applied</param>
        /// <param name="startValue">The initial value of the accumulating variable</param>
        /// <param name="function">Value reading function</param>
        /// <returns>The accumulated value resulting from the entire iteration of the List.</returns>
        public static TResult Fold<TInit, TResult>(IEnumerable<TInit> currentList, TResult startValue, Func<TResult, TInit, TResult> function)
            => currentList.Aggregate(startValue, function);

        static void Main(string[] args)
        {
        }
    }
}