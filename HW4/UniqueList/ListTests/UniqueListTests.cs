using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListNumber
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList uniqueList = new UniqueList();

        [TestMethod]
        public void NormalInsertInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.IsTrue(uniqueList.IsExistValue(2));
        }

        [TestMethod]
        public void ErrorInsertInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);

            Assert.ThrowsException<ValueIsAlreadyInsertedException>(() => uniqueList.Insert(1, 0));
        }

        [TestMethod]
        public void DeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.DeleteByValue(2);

            Assert.IsFalse(uniqueList.IsExistValue(2));
        }

        [TestMethod]
        public void ErrorDeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.ThrowsException<ValueDoesNotExistException>(() => uniqueList.DeleteByValue(4));
        }

        [TestMethod]
        public void DeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.DeleteByIndex(2);

            Assert.IsFalse(uniqueList.IsExistValue(3));
        }

        [TestMethod]
        public void ErrorDeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.ThrowsException<ValueDoesNotExistException>(() => uniqueList.DeleteByIndex(4));
        }

        [TestMethod]
        public void SetValueInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.SetValueByIndex(2, 1);

            Assert.IsTrue(uniqueList.IsExistValue(2));
        }

        [TestMethod]
        public void ErrorSetValueInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.ThrowsException<ValueIsAlreadyInsertedException>(() => uniqueList.SetValueByIndex(2, 2));
        }
    }
}