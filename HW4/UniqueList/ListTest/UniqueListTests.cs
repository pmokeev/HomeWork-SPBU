using NUnit.Framework;
using UniqueListNumber;

namespace ListTest
{
    /// <summary>
    /// Testing the functionality of a unique list
    /// </summary>
    public class UniqueListTests
    {
        private UniqueList uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new();
        }

        [Test]
        public void NormalInsertInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.IsTrue(uniqueList.Contains(2));
        }

        [Test]
        public void ErrorInsertInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);

            Assert.Throws<ValueIsAlreadyInsertedException>(() => uniqueList.Insert(1, 0));
        }

        [Test]
        public void DeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.DeleteByValue(2);

            Assert.IsFalse(uniqueList.Contains(2));
        }

        [Test]
        public void ErrorDeleteByValueFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.Throws<ValueDoesNotExistException>(() => uniqueList.DeleteByValue(4));
        }

        [Test]
        public void DeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.DeleteByIndex(2);

            Assert.IsFalse(uniqueList.Contains(3));
        }

        [Test]
        public void ErrorDeleteByIndexFromUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.Throws<ValueDoesNotExistException>(() => uniqueList.DeleteByIndex(4));
        }

        [Test]
        public void SetValueInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            uniqueList.SetValueByIndex(2, 1);

            Assert.IsTrue(uniqueList.Contains(2));
        }

        [Test]
        public void ErrorSetValueInUniqueListTests()
        {
            uniqueList.Insert(1, 0);
            uniqueList.Insert(2, 1);
            uniqueList.Insert(3, 2);

            Assert.Throws<ValueIsAlreadyInsertedException>(() => uniqueList.SetValueByIndex(2, 2));
        }
    }
}