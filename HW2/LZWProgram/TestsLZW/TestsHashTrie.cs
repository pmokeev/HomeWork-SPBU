using LZWProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsLZW
{
    [TestClass]
    public class TestsHashTrie
    {
        private HashTrie trie = new HashTrie();
        [TestMethod]
        public void InsertTest()
        {
            trie.Insert((byte)1, 1);

            Assert.IsTrue(trie.HasChild((byte)1));
        }

        [TestMethod]
        public void ThreeElementsInsertTest()
        {
            trie.Insert((byte)1, 1);
            trie.Insert((byte)2, 2);
            trie.Insert((byte)3, 3);

            Assert.IsTrue(trie.HasChild((byte)2));
        }

        [TestMethod]
        public void GetChildTest()
        {
            trie.Insert((byte)1, 1);
            trie.GetChild((byte)1);

            Assert.IsTrue(trie.IsEmptyNode());
        }

        [TestMethod]
        public void GetChildFromNodeWithoutThisChildTest()
        {
            trie.Insert((byte)1, 1);
            trie.GetChild((byte)2);

            Assert.IsTrue(trie.HasChild((byte)1));
        }

        [TestMethod]
        public void HasChildTest()
        {
            trie.Insert((byte)1, 1);

            Assert.IsFalse(trie.HasChild((byte)2));
        }

        [TestMethod]
        public void GoToRootTest()
        {
            trie.Insert((byte)1, 1);
            trie.Insert((byte)2, 1);
            trie.GetChild((byte)2);
            trie.Insert((byte)3, 1);
            trie.GetChild((byte)3);
            trie.GoToRoot();

            Assert.IsTrue(trie.HasChild((byte)1));
        }

        [TestMethod]
        public void GetValueTest()
        {
            trie.Insert((byte)1, 1);
            trie.GetChild((byte)1);

            Assert.AreEqual(1, trie.GetValue());
        }

        [TestMethod]
        public void GetValueFromEmptyTrieTest()
        {
            Assert.AreEqual(-1, trie.GetValue());
        }

        [TestMethod]
        public void GetParentValueTest()
        {
            trie.Insert((byte)1, 1);
            trie.GetChild((byte)1);
            trie.Insert((byte)2, 2);
            trie.GetChild((byte)2);

            Assert.AreEqual(1, trie.GetParentValue());
        }

        [TestMethod]
        public void IsEmptyTrieTest()
        {
            Assert.IsTrue(trie.IsEmptyNode());
        }
    }
}