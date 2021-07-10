using NUnit.Framework;
using TestTask;
using System.Collections.Generic;

namespace VectorTests
{
    /// <summary>
    /// A class with sparse vector tests
    /// </summary>
    public class SparseVectorTests
    {
        private float[] firstVector;
        private float[] secondVector;
        private float[] thirdVector;

        [SetUp]
        public void Setup()
        {
            firstVector = new float[] { 2, 0, 0, 0, 0,
                3, 0, 4, 0, 0,
                0, 1, 5, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 4, 0, 0,
                0, 2, 0, 0, 0,
                0, 0, 0, 3, 0,
                0, 0, 1, 0, 0,
                0, 0, 5 };

            secondVector = new float[] { 3, 0, 0, 0, 0,
                3, 0, 4, 0, 0,
                0, 1, 5, 0, 0,
                0, 0, 0, 7, 0,
                0, 0, 4, 0, 0,
                0, 2, 0, 0, 0,
                0, 0, 0, 3, 0,
                3, 0, 1, 0, 0,
                0, 0, 5 };

            thirdVector = new float[] { 0, 0, 0, 0 };
        }

        [Test]
        public void CreateVectorsTest()
        {
            SparseVector vector = new SparseVector(firstVector);
            var realList = new List<(int index, float value)>() { (0, 2), (5, 3), (7, 4), (11, 1), (12, 5), (22, 4), (26, 2), (33, 3), (37, 1), (42, 5) };

            Assert.AreEqual(realList, vector.VectorList);
        }

        [Test]
        public void SumVectorsTest()
        {
            var rightList = new List<(int index, float value)>() { (0, 5), (5, 6), (7, 8), (11, 2), (12, 10), (18, 7), (22, 8), (26, 4), (33, 6), (35, 3), (37, 2), (42, 10) };
            SparseVector firstSparseVector = new SparseVector(firstVector);
            SparseVector secondSparseVector = new SparseVector(secondVector);

            firstSparseVector.SumSparseVectors(secondSparseVector);

            CollectionAssert.AreEqual(rightList, firstSparseVector.VectorList);
        }

        [Test]
        public void SubtractionVectorsTest()
        {
            var rightList = new List<(int index, float value)>() { (0, -1), (5, 0), (7, 0), (11, 0), (12, 0), (18, 7), (22, 0), (26, 0), (33, 0), (35, 3), (37, 0), (42, 0) };

            SparseVector firstSparseVector = new SparseVector(firstVector);
            SparseVector secondSparseVector = new SparseVector(secondVector);

            firstSparseVector.SubtractionSparseVectors(secondSparseVector);

            CollectionAssert.AreEqual(rightList, firstSparseVector.VectorList);
        }

        [Test]
        public void ScalarMultiplicationVectorsTest()
        {
            SparseVector firstSparseVector = new SparseVector(firstVector);
            SparseVector secondSparseVector = new SparseVector(secondVector);

            float rightValue = 112;
            float currentValue = firstSparseVector.ScalarMultiplicationSparseVectors(secondSparseVector);

            Assert.AreEqual(rightValue, currentValue);
        }

        [Test]
        public void IsNullVectorTest()
        {
            SparseVector sparseVector = new SparseVector(thirdVector);

            Assert.IsTrue(sparseVector.IsNull());
        }
    }
}