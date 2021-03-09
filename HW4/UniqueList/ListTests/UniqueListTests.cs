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
            uniqueList.Insert(1);
            uniqueList.Insert(2);
            uniqueList.Insert(3);

            Assert.IsTrue(uniqueList.IsExistValue(2));
        }

        [TestMethod]
        public void ErrorInsertInUniqueListTests()
        {
            uniqueList.Insert(1);
            uniqueList.Insert(2);

            Assert.ThrowsException<ValueIsAlreadyInsertedException>(() => uniqueList.Insert(1));
        }

        [TestMethod]
        public void DeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1);
            uniqueList.Insert(2);
            uniqueList.Insert(3);

            uniqueList.DeleteByValue(2);

            Assert.IsFalse(uniqueList.IsExistValue(2));
        }

        [TestMethod]
        public void ErrorDeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1);
            uniqueList.Insert(2);
            uniqueList.Insert(3);

            Assert.ThrowsException<ValueDoesNotExistException>(() => uniqueList.DeleteByValue(4));
        }

        [TestMethod]
        public void DeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1);
            uniqueList.Insert(2);
            uniqueList.Insert(3);

            uniqueList.DeleteByIndex(2);

            Assert.IsFalse(uniqueList.IsExistValue(3));
        }

        [TestMethod]
        public void ErrorDeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1);
            uniqueList.Insert(2);
            uniqueList.Insert(3);

            Assert.ThrowsException<ValueDoesNotExistException>(() => uniqueList.DeleteByIndex(4));
        }
    }
}