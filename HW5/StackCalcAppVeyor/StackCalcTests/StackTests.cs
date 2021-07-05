using NUnit.Framework;
using StackCalcAppVeyor;

namespace StackCalcTests
{
    /// <summary>
    /// Stack Calculator Tests
    /// </summary>
    public class StackTests
    {
        private Calculator listCalc;
        private Calculator arrayCalc;

        [SetUp]
        public void Setup()
        {
            listCalc = new Calculator(new ListStack());
            arrayCalc = new Calculator(new ArrayStack());
        }

        [Test]
        public void CorrectTestCase()
        {
            var expression = "1 2 3 + *";

            Assert.AreEqual(5, listCalc.Calculate(expression));
            Assert.AreEqual(5, arrayCalc.Calculate(expression));
        }

        [Test]
        public void IncorrectTestCase()
        {
            var expression = "1 2 +";

            Assert.AreNotEqual(4, listCalc.Calculate(expression));
            Assert.AreNotEqual(4, arrayCalc.Calculate(expression));
        }

        [Test]
        public void OneNumberTestCase()
        {
            var expression = "1";

            Assert.AreEqual(1, listCalc.Calculate(expression));
            Assert.AreEqual(1, arrayCalc.Calculate(expression));
        }

        [Test]
        public void HardTestCase()
        {
            var expression = "100 54 23 * + 10 2 / - 11 +";

            Assert.AreEqual(1348, listCalc.Calculate(expression));
            Assert.AreEqual(1348, arrayCalc.Calculate(expression));
        }

        [Test]
        public void MistakeOfThePastTestCase()
        {
            var expression = "5 0 -";

            Assert.AreEqual(5, listCalc.Calculate(expression));
            Assert.AreEqual(5, arrayCalc.Calculate(expression));
        }
    }
}