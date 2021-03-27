using NUnit.Framework;
using Routers;

namespace RoutersTests
{
    /// <summary>
    /// Class with tests of data structure disjoint set
    /// </summary>
    public class SetTests
    {
        private Set currentSet;

        [SetUp]
        public void Setup()
        {
            currentSet = new Set(4);
        }

        [Test]
        public void SimpleFindTest()
        {
            Assert.AreEqual(1, currentSet.Find(1));
        }

        [Test]
        public void FindUfterUnionTest()
        {
            currentSet.Union(0, 3);

            Assert.AreEqual(0, currentSet.Find(3));
        }

        [Test]
        public void UnionAllElementsTest()
        {
            currentSet.Union(0, 1);
            currentSet.Union(1, 2);
            currentSet.Union(2, 3);

            Assert.IsTrue(currentSet.IsOnlySet());
        }

        [Test]
        public void NotOnlyOneSetTest()
        {
            Assert.IsFalse(currentSet.IsOnlySet());
        }
    }
}