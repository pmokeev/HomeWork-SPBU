using NUnit.Framework;
using BTreeImplementation;

namespace BTreeTests
{
    /// <summary>
    /// Tests for B-tree
    /// </summary>
    public class BTreeFunctionsTests
    {
        private BTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new BTree(2);
        }

        [Test]
        public void EmptyTreeTest()
        {
            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void OneItemInsertTest()
        {
            tree.Insert("a", "1");

            Assert.IsTrue(tree.IsExistKey("a"));
        }

        [Test]
        public void OneItemInsertAndDeleteTest()
        {
            tree.Insert("a", "1");

            tree.Delete("a");

            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void MoreItemsInsertTest()
        {
            for (int i = 1; i < 15; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 15; i++)
            {
                Assert.IsTrue(tree.IsExistKey(i.ToString()));
            }
        }

        [Test]
        public void DeleteFirstKeyTest()
        {
            for (int i = 0; i < 9; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            tree.Delete("0");

            Assert.IsFalse(tree.IsExistKey("0"));
        }

        [Test]
        public void DeleteFromLeafTest()
        {
            for (int i = 0; i < 2; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            tree.Delete("0");

            Assert.IsFalse(tree.IsExistKey("0"));
            Assert.IsTrue(tree.IsExistKey("1"));
        }

        [Test]
        public void DeleteLastKeyTest()
        {
            for (int i = 0; i < 10; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            tree.Delete("9");

            Assert.IsFalse(tree.IsExistKey("9"));
        }

        [Test]
        public void DeleteAllItemsTest()
        {
            for (int i = 1; i < 11; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 11; i++)
            {
                tree.Delete(i.ToString());
            }

            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void DeleteExceptionTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            Assert.Catch<NonExistentKeyException>(() => tree.Delete("15"));
        }

        [Test]
        public void ChangeValueByKeyTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            tree.ChangeValue("3", "12");

            Assert.AreEqual("12", tree.GetValue("3"));
        }

        [Test]
        public void ExceptionChangeValueTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            Assert.Catch<NonExistentKeyException>(() => tree.ChangeValue("15", "a"));
        }

        [Test]
        public void IsExistKeyTest()
        {
            tree.Insert("a", "1");
            tree.Insert("b", "2");
            tree.Insert("c", "3");

            Assert.IsFalse(tree.IsExistKey("d"));
        }

        [Test]
        public void DeleteAndInsertTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Insert(i.ToString(), i.ToString());
            }

            tree.Delete("3");

            Assert.IsFalse(tree.IsExistKey("3"));

            tree.Insert("3", "3");

            Assert.IsTrue(tree.IsExistKey("3"));
        }
    }
}