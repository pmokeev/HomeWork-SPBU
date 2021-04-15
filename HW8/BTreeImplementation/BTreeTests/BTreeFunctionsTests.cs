using NUnit.Framework;
using BTreeImplementation;
using System.Collections.Generic;
using System;

namespace BTreeTests
{
    /// <summary>
    /// Tests for B-tree
    /// </summary>
    public class BTreeFunctionsTests
    {
        private BTree<string, string> treeString;
        private BTree<int, string> treeIntString; 

        [SetUp]
        public void Setup()
        {
            treeString = new BTree<string, string>(2);
            treeIntString = new BTree<int, string>(2);

            for (int i = 0; i < 10; i++)
            {
                treeIntString.Add(i, i.ToString());
            }
        }

        [Test]
        public void EmptyTreeTest()
        {
            Assert.IsTrue(treeString.IsEmpty());
        }

        [Test]
        public void OneItemInsertTest()
        {
            treeString.Add("a", "1");

            Assert.IsTrue(treeString.ContainsKey("a"));
        }

        [Test]
        public void OneItemInsertAndDeleteTest()
        {
            treeString.Add("a", "1");

            treeString.Remove("a");

            Assert.IsTrue(treeString.IsEmpty());
        }

        [Test]
        public void MoreItemsInsertTest()
        {
            for (int i = 1; i < 15; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 15; i++)
            {
                Assert.IsTrue(treeString.ContainsKey(i.ToString()));
            }
        }

        [Test]
        public void DeleteFirstKeyTest()
        {
            for (int i = 0; i < 9; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            treeString.Remove("0");

            Assert.IsFalse(treeString.ContainsKey("0"));
        }

        [Test]
        public void DeleteFromLeafTest()
        {
            for (int i = 0; i < 2; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            treeString.Remove("0");

            Assert.IsFalse(treeString.ContainsKey("0"));
            Assert.IsTrue(treeString.ContainsKey("1"));
        }

        [Test]
        public void DeleteLastKeyTest()
        {
            for (int i = 0; i < 10; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            treeString.Remove("9");

            Assert.IsFalse(treeString.ContainsKey("9"));
        }

        [Test]
        public void DeleteAllItemsTest()
        {
            for (int i = 1; i < 11; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            for (int i = 1; i < 11; i++)
            {
                treeString.Remove(i.ToString());
            }

            Assert.IsTrue(treeString.IsEmpty());
        }

        [Test]
        public void DeleteExceptionTest()
        {
            for (int i = 0; i < 15; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            Assert.IsFalse(treeString.Remove("15"));
        }

        [Test]
        public void ChangeValueByKeyTest()
        {
            for (int i = 0; i < 15; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            treeString.ChangeValue("3", "12");

            treeString.TryGetValue("3", out string result);

            Assert.AreEqual("12", result);
        }

        [Test]
        public void ExceptionChangeValueTest()
        {
            for (int i = 0; i < 15; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            Assert.Catch<NonExistentKeyException>(() => treeString.ChangeValue("15", "a"));
        }

        [Test]
        public void IsExistKeyTest()
        {
            treeString.Add("a", "1");
            treeString.Add("b", "2");
            treeString.Add("c", "3");

            Assert.IsFalse(treeString.ContainsKey("d"));
        }

        [Test]
        public void DeleteAndInsertTest()
        {
            for (int i = 0; i < 15; i++)
            {
                treeString.Add(i.ToString(), i.ToString());
            }

            treeString.Remove("3");

            Assert.IsFalse(treeString.ContainsKey("3"));

            treeString.Add("3", "3");

            Assert.IsTrue(treeString.ContainsKey("3"));
        }

        [Test]
        public void KeysInDictTest()
        {
            var correctList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                correctList.Add(i);
            }

            CollectionAssert.AreEqual(correctList, treeIntString.Keys);
        }

        [Test]
        public void ValuesInDictTest()
        {
            var correctList = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                correctList.Add(i.ToString());
            }

            CollectionAssert.AreEqual(correctList, treeIntString.Values);
        }

        [Test]
        public void KeysCountTest()
        {
            Assert.AreEqual(10, treeIntString.Count);
        }

        [Test]
        public void GetValueByUsingThisTest()
        {
            Assert.AreEqual("3", treeIntString[3]);
        }

        [Test]
        public void ClearTreeTest()
        {
            treeIntString.Clear();

            Assert.IsTrue(treeIntString.IsEmpty());
        }

        [Test]
        public void GetValueByMethodTest()
        {
            treeIntString.TryGetValue(3, out string outputValue);

            Assert.AreEqual("3", outputValue);
        }

        [Test]
        public void IsContainsKeyTest()
        {
            Assert.IsTrue(treeIntString.ContainsKey(3));
        }

        [Test]
        public void IsNotContainsKeyTest()
        {
            Assert.IsFalse(treeIntString.ContainsKey(10));
        }

        [Test]
        public void IContainsPairTest()
        {
            Assert.IsTrue(treeIntString.Contains(new KeyValuePair<int, string>(3, "3")));
        }

        [Test]
        public void AddByPairTest()
        {
            treeIntString.Add(new KeyValuePair<int, string>(10, "10"));

            Assert.IsTrue(treeIntString.Contains(new KeyValuePair<int, string>(10, "10")));
        }

        [Test]
        public void RemoveByPairTest()
        {
            treeIntString.Remove(new KeyValuePair<int, string>(0, "0"));

            Assert.IsFalse(treeIntString.Contains(new KeyValuePair<int, string>(0, "0")));
        }

        [Test]
        public void CopyToArrayTest()
        {
            var array = new KeyValuePair<int, string>[10];
            var answerArray = new KeyValuePair<int, string>[10];

            for (int i = 0; i < 10; i++)
            {
                answerArray[i] = new KeyValuePair<int, string>(i, i.ToString());
            }

            treeIntString.CopyTo(array, 0);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(answerArray[i], array[i]);
            }
        }

        [Test]
        public void ForeachTreeTest()
        {
            var answerArray = new KeyValuePair<int, string>[10];
            int index = 0;

            for (int i = 0; i < 10; i++)
            {
                answerArray[i] = new KeyValuePair<int, string>(i, i.ToString());
            }

            foreach (var item in treeIntString)
            {
                Assert.AreEqual(answerArray[index], item);
                index++;
            }
        }

        [Test]
        public void CurrentTestAfterDelete()
        {
            foreach (var item in treeIntString)
            {
                if (item.Key == 2)
                {
                    treeIntString.Remove(2);
                    Assert.AreEqual(new KeyValuePair<int, string>(2, "2"), item);
                    return;
                }
            }
        }

        [Test]
        public void MoveNextExceptionTest()
        {
            var dictionaryEnumerator = treeIntString.GetEnumerator();

            treeIntString.Remove(0);

            Assert.Catch<InvalidOperationException>(() => dictionaryEnumerator.MoveNext());
        }

        [Test]
        public void AlreadyExistAddTest()
        {
            Assert.Catch<ArgumentException>(() => treeIntString.Add(0, "10"));
        }

        [Test]
        public void ResetEnumeratorTest()
        {
            var dictionaryEnumerator = treeIntString.GetEnumerator();
            dictionaryEnumerator.MoveNext();
            dictionaryEnumerator.MoveNext();

            dictionaryEnumerator.Reset();
            dictionaryEnumerator.MoveNext();

            Assert.AreEqual(new KeyValuePair<int, string>(0, "0"), dictionaryEnumerator.Current);
        }
    }
}