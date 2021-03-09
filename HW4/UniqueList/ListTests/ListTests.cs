using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListNumber
{
    [TestClass]
    public class ListTests
    {
        private List list = new List();

        [TestMethod]
        public void InsertTests()
        {
            list.Insert(1);

            Assert.IsTrue(list.IsExistValue(1));
        }

        [TestMethod]
        public void InsertThreeElementsTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            Assert.IsTrue(list.IsExistValue(2));
        }

        [TestMethod]
        public void GetSizeListTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);

            Assert.AreEqual(4, list.GetSize());
        }

        [TestMethod]
        public void IsExistValueInListTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);

            Assert.IsFalse(list.IsExistValue(5));
        }

        [TestMethod]
        public void GetValueInStartListByIndexTests()
        {
            list.Insert(1);

            Assert.AreEqual(1, list.GetValueByIndex(0));
        }

        [TestMethod]
        public void GetValueInListByIndexTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);
            list.Insert(4);

            Assert.AreEqual(3, list.GetValueByIndex(2));
        }

        [TestMethod]
        public void GetIndexByValueInStartListTests()
        {
            list.Insert(1);
            list.Insert(2);

            Assert.AreEqual(0, list.GetIndexByValue(1));
        }

        [TestMethod]
        public void GetIndexByValueInListTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            Assert.AreEqual(1, list.GetIndexByValue(2));
        }

        [TestMethod]
        public void DeleteInStartListByValueTests()
        {
            list.Insert(1);

            list.DeleteByValue(1);

            Assert.IsFalse(list.IsExistValue(1));
        }

        [TestMethod]
        public void DeleteInListByValueTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            list.DeleteByValue(2);

            Assert.IsFalse(list.IsExistValue(2));
        }

        [TestMethod]
        public void DeleteInEndListByValueTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            list.DeleteByValue(3);

            Assert.IsFalse(list.IsExistValue(3));
        }

        [TestMethod]
        public void DeleteInStartListByIndexTests()
        {
            list.Insert(1);
            list.Insert(2);

            list.DeleteByIndex(0);

            Assert.IsFalse(list.IsExistValue(1));
        }

        [TestMethod]
        public void DeleteInListByIndexTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            list.DeleteByIndex(1);

            Assert.IsFalse(list.IsExistValue(2));
        }

        [TestMethod]
        public void DeleteInEndListByIndexTests()
        {
            list.Insert(1);
            list.Insert(2);
            list.Insert(3);

            list.DeleteByIndex(2);

            Assert.IsFalse(list.IsExistValue(3));
        }
    }
}
