using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UniqueListNumber
{
    [TestClass]
    public class ListTests
    {
        private List list = new List();

        [TestMethod]
        public void InsertInBeginningListByPositionTests()
        {
            list.Insert(1, 0);

            Assert.IsTrue(list.IsExistValue(1));
        }

        [TestMethod]
        public void InsertThreeElementsTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            Assert.IsTrue(list.IsExistValue(2));
        }

        [TestMethod]
        public void InsertInListByPositionTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 1);

            Assert.AreEqual(2, list.GetValueByIndex(2));
        }

        [TestMethod]
        public void InsertInEndListByPositionTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(4, list.GetValueByIndex(3));
        }

        [TestMethod]
        public void ErrorInsertInListTests()
        {
            list.Insert(1, 0);

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(1, 2));
        }

        [TestMethod]
        public void GetSizeListTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(4, list.GetSize());
        }

        [TestMethod]
        public void IsExistValueInListTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.IsFalse(list.IsExistValue(5));
        }

        [TestMethod]
        public void GetValueInBeginningListByIndexTests()
        {
            list.Insert(1, 0);

            Assert.AreEqual(1, list.GetValueByIndex(0));
        }

        [TestMethod]
        public void GetValueInListByIndexTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);
            list.Insert(4, 3);

            Assert.AreEqual(3, list.GetValueByIndex(2));
        }

        [TestMethod]
        public void GetIndexByValueInBeginningListTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);

            Assert.AreEqual(0, list.GetIndexByValue(1));
        }

        [TestMethod]
        public void GetIndexByValueInListTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            Assert.AreEqual(1, list.GetIndexByValue(2));
        }

        [TestMethod]
        public void DeleteInBeginningListByValueTests()
        {
            list.Insert(1, 0);

            list.DeleteByValue(1);

            Assert.IsFalse(list.IsExistValue(1));
        }

        [TestMethod]
        public void DeleteInListByValueTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByValue(2);

            Assert.IsFalse(list.IsExistValue(2));
        }

        [TestMethod]
        public void DeleteInEndListByValueTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByValue(3);

            Assert.IsFalse(list.IsExistValue(3));
        }

        [TestMethod]
        public void DeleteInBeginningListByIndexTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);

            list.DeleteByIndex(0);

            Assert.IsFalse(list.IsExistValue(1));
        }

        [TestMethod]
        public void DeleteInListByIndexTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByIndex(1);

            Assert.IsFalse(list.IsExistValue(2));
        }

        [TestMethod]
        public void DeleteInEndListByIndexTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.DeleteByIndex(2);

            Assert.IsFalse(list.IsExistValue(3));
        }

        [TestMethod]
        public void SetInBeginningListValueTests()
        {
            list.Insert(1, 0);

            list.SetValueByIndex(2, 0);

            Assert.IsTrue(list.IsExistValue(2));
        }

        [TestMethod]
        public void SetInListValueTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.SetValueByIndex(4, 1);

            Assert.IsTrue(list.IsExistValue(4));
        }

        [TestMethod]
        public void SetInEndListValueTests()
        {
            list.Insert(1, 0);
            list.Insert(2, 1);
            list.Insert(3, 2);

            list.SetValueByIndex(4, 2);

            Assert.IsTrue(list.IsExistValue(4));
        }
    }
}
