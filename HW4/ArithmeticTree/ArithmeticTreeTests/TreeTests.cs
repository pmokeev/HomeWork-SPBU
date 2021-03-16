using NUnit.Framework;
using ArithmeticTree;
using System;

namespace ArithmeticTreeTests
{
    /// <summary>
    /// Arithmetic tree tests
    /// </summary>
    public class Tests
    {
        private Tree tree;

        [SetUp]
        public void Setup()
        {
            tree = new Tree();
        }

        [Test]
        public void AdditionTest()
        {
            var expression = "(+ 1 1)";

            tree.CreateTree(expression);

            Assert.AreEqual(2, tree.Calculate());
        }

        [Test]
        public void SubstructionTest()
        {
            var expression = "(- 1 1)";

            tree.CreateTree(expression);

            Assert.AreEqual(0, tree.Calculate());
        }

        [Test]
        public void MultiplicationTest()
        {
            var expression = "(* 2 3)";

            tree.CreateTree(expression);

            Assert.AreEqual(6, tree.Calculate());
        }

        [Test]
        public void CorrectDivisionTest()
        {
            var expression = "(/ 6 3)";

            tree.CreateTree(expression);

            Assert.AreEqual(2, tree.Calculate());
        }

        [Test]
        public void IncorrectDivisionTest()
        {
            var expression = "(/ 6 0)";

            tree.CreateTree(expression);

            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }

        [Test]
        public void FloatDivisionTest()
        {
            var expression = "(/ 1 2)";

            tree.CreateTree(expression);

            Assert.AreEqual(0.5, tree.Calculate());
        }

        [Test]
        public void ExpressionFromTaskTest()
        {
            var expression = "(* (+ 1 1) 2)";

            tree.CreateTree(expression);

            Assert.AreEqual(4, tree.Calculate());
        }

        [Test]
        public void InvalidExpressionTest()
        {
            var expression = "(* 1 )";

            Assert.Throws<InvalidExpressionException>(() => tree.CreateTree(expression));
        }
    }
}