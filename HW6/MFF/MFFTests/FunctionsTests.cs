using NUnit.Framework;
using System.Collections.Generic;
using MFF;
using System;

namespace MFFTests
{
    public class FunctionsTests
    {
        [Test]
        public void MapTaskTest()
        {
            var testList = new List<int>() { 1, 2, 3 };
            var resultList = new List<int>() { 2, 4, 6 };

            CollectionAssert.AreEqual(resultList, Functions.Map(testList, x => x * 2));
        }

        [Test]
        public void EmptyListMapTest()
        {
            var testList = new List<int>();
            var resultList = new List<int>();

            CollectionAssert.AreEqual(resultList, Functions.Map(testList, x => x * 2));
        }

        [Test]
        public void SquareMapTest()
        {
            var testList = new List<int>() { 2, 3, 4, 5 };
            var resultList = new List<int>() { 4, 9, 16, 25 };

            CollectionAssert.AreEqual(resultList, Functions.Map(testList, x => x * x));
        }

        [Test]
        public void TaskFilterTest()
        {
            var testList = new List<int>() { 2, 3, 4, 5, 6 };
            var resultList = new List<bool>() { true, false, true, false, true };

            CollectionAssert.AreEqual(resultList, Functions.Filter(testList, x => (x % 2) == 0));
        }

        [Test]
        public void EmptyListFilterTest()
        {
            var testList = new List<int>();
            var resultList = new List<bool>();

            CollectionAssert.AreEqual(resultList, Functions.Filter(testList, x => (x % 2) == 0));
        }

        [Test]
        public void SqrtFilterTest()
        {
            var testList = new List<int>() { 2, 4, 5, 6, 1, 7 };
            var resultList = new List<bool>() { false, false, false, false, true, false };

            CollectionAssert.AreEqual(resultList, Functions.Filter(testList, x => Math.Sqrt(x) == 1));
        }

        [Test]
        public void TaskFoldTest()
        {
            var testList = new List<int>() { 1, 2, 3 };
            var startValue = 1;
            var resultValue = 6;

            Assert.AreEqual(resultValue, Functions.Fold(testList, startValue, (acc, elem) => acc * elem));
        }

        [Test]
        public void EmptyListFoldTest()
        {
            var testList = new List<int>();
            var startValue = 1;
            var resultValue = 1;

            Assert.AreEqual(resultValue, Functions.Fold(testList, startValue, (acc, elem) => acc * elem));
        }

        [Test]
        public void StringFoldTest()
        {
            var testList = new List<string>() { "I ", "am ", "Groot" };
            var startValue = "";
            var resultValue = "I am Groot";

            Assert.AreEqual(resultValue, Functions.Fold(testList, startValue, (acc, elem) => acc + elem));
        }
    }
}