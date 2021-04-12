using NUnit.Framework;
using BTreeImplementation;

namespace BTreeTests
{
    /// <summary>
    /// Tests for B-tree
    /// </summary>
    public class BTreeFunctionsTests
    {
        private BTree<string, string> tree;

        [SetUp]
        public void Setup()
        {
            tree = new BTree<string, string>(2);
        }

        [Test]
        public void EmptyTreeTest()
        {
            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void OneItemInsertTest()
        {
            tree.Add("a", "1");

            Assert.IsTrue(tree.ContainsKey("a"));
        }

        [Test]
        public void OneItemInsertAndDeleteTest()
        {
            tree.Add("a", "1");

            tree.Remove("a");

            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void MoreItemsInsertTest()
        {
            for (int i = 1; i < 15; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 15; i++)
            {
                Assert.IsTrue(tree.ContainsKey(i.ToString()));
            }
        }

        [Test]
        public void DeleteFirstKeyTest()
        {
            for (int i = 0; i < 9; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            tree.Remove("0");

            Assert.IsFalse(tree.ContainsKey("0"));
        }

        [Test]
        public void DeleteFromLeafTest()
        {
            for (int i = 0; i < 2; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            tree.Remove("0");

            Assert.IsFalse(tree.ContainsKey("0"));
            Assert.IsTrue(tree.ContainsKey("1"));
        }

        [Test]
        public void DeleteLastKeyTest()
        {
            for (int i = 0; i < 10; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            tree.Remove("9");

            Assert.IsFalse(tree.ContainsKey("9"));
        }

        [Test]
        public void DeleteAllItemsTest()
        {
            for (int i = 1; i < 11; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 11; i++)
            {
                tree.Remove(i.ToString());
            }

            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void DeleteExceptionTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            Assert.IsFalse(tree.Remove("15"));
        }

        [Test]
        public void ChangeValueByKeyTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            tree.ChangeValue("3", "12");

            tree.TryGetValue("3", out string result);

            Assert.AreEqual("12", result);
        }

        [Test]
        public void ExceptionChangeValueTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            Assert.Catch<NonExistentKeyException>(() => tree.ChangeValue("15", "a"));
        }

        [Test]
        public void IsExistKeyTest()
        {
            tree.Add("a", "1");
            tree.Add("b", "2");
            tree.Add("c", "3");

            Assert.IsFalse(tree.ContainsKey("d"));
        }

        [Test]
        public void DeleteAndInsertTest()
        {
            for (int i = 0; i < 15; i++)
            {
                tree.Add(i.ToString(), i.ToString());
            }

            tree.Remove("3");

            Assert.IsFalse(tree.ContainsKey("3"));

            tree.Add("3", "3");

            Assert.IsTrue(tree.ContainsKey("3"));
        }
    }
}