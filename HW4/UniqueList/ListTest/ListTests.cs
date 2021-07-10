using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniqueListNumber;

namespace ListTest
{
    /// <summary>
    /// Testing the general functionality of List
    /// </summary>
    [TestFixture]
    public class ListTests
    {
        private static IEnumerable<UniqueListNumber.List> ListTypes()
        {
            yield return new UniqueListNumber.List();
            yield return new UniqueList();
        }

        [TestCaseSource(nameof(ListTypes))]
        public void InsertInBeginningListByPositionTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);

            Assert.IsTrue(list.Contains(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void InsertThreeElementsTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            Assert.IsTrue(list.Contains(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void InsertInListByPositionTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 1);

            Assert.AreEqual(2, list.GetValueByIndex(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void InsertInEndListByPositionTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(4, list.GetValueByIndex(3));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetSizeListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(4, list.GetSize());
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetSizeEmptyListTests(UniqueListNumber.List list)
        {
            Assert.AreEqual(0, list.GetSize());
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetSizeAfterDeleteListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.DeleteByValue(2);

            Assert.AreEqual(1, list.GetSize());
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetSizeAfterDeleteOneElementInListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.DeleteByValue(1);

            Assert.AreEqual(0, list.GetSize());
        }

        [TestCaseSource(nameof(ListTypes))]
        public void IsExistValueInListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.IsFalse(list.Contains(5));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetValueInBeginningListByIndexTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);

            Assert.AreEqual(1, list.GetValueByIndex(0));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetValueInListByIndexTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(3, list.GetValueByIndex(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetIndexByValueInBeginningListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);

            Assert.AreEqual(0, list.GetIndexByValue(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetIndexByValueInListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            Assert.AreEqual(1, list.GetIndexByValue(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInBeginningListByValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);

            list.DeleteByValue(1);

            Assert.IsFalse(list.Contains(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInListByValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByValue(2);

            Assert.IsFalse(list.Contains(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInEndListByValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByValue(3);

            Assert.IsFalse(list.Contains(3));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInBeginningListByIndexTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);

            list.DeleteByIndex(0);

            Assert.IsFalse(list.Contains(1));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInListByIndexTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByIndex(1);

            Assert.IsFalse(list.Contains(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void DeleteInEndListByIndexTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByIndex(2);

            Assert.IsFalse(list.Contains(3));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void SetInBeginningListValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);

            list.SetValueByIndex(2, 0);

            Assert.IsTrue(list.Contains(2));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void SetInListValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.SetValueByIndex(4, 1);

            Assert.IsTrue(list.Contains(4));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void SetInEndListValueTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.SetValueByIndex(4, 2);

            Assert.IsTrue(list.Contains(4));
        }

        [TestCaseSource(nameof(ListTypes))]
        public void GetValueByIncorrectIndexInListTests(UniqueListNumber.List list)
        {
            list.Insert(1, 0);

            Assert.Throws<ValueDoesNotExistException>(() => list.GetValueByIndex(-1));
        }
    }
}