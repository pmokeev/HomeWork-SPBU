using System;

namespace StackCalc
{
    class TestsCalc
    {
        private static bool ListStackCorrectTestCase()
        {
            var calculatorStack = new Calculator(new ListStack());
            var expression = "1 2 3 + *";

            return 5 == calculatorStack.Calculate(expression);
        }

        private static bool ListStackIncorrectTestCase()
        {
            var calculatorStack = new Calculator(new ListStack());
            var expression = "1 2 +";

            return 4 == calculatorStack.Calculate(expression);
        }

        private static bool ListStackOneNumberTestCase()
        {
            var calculatorStack = new Calculator(new ListStack());
            var expression = "1";

            return 1 == calculatorStack.Calculate(expression);
        }

        private static bool ListStackHardTestCase()
        {
            var calculatorStack = new Calculator(new ListStack());
            var expression = "100 54 23 * + 10 2 / - 11 +";

            return 1348 == calculatorStack.Calculate(expression);
        }

        private static bool ListStackMistakeOfThePastTestCase()
        {
            var calculatorStack = new Calculator(new ListStack());
            var expression = "5 0 -";

            return 5 == calculatorStack.Calculate(expression);
        }

        public static bool ListAllTestsCase()
            => ListStackCorrectTestCase() && !ListStackIncorrectTestCase() && ListStackOneNumberTestCase() && ListStackHardTestCase() && ListStackMistakeOfThePastTestCase();

        private static bool ArrayStackCorrectTestCase()
        {
            var calculatorStack = new Calculator(new ArrayStack());
            var expression = "1 2 3 + *";

            return 5 == calculatorStack.Calculate(expression);
        }

        private static bool ArrayStackIncorrectTestCase()
        {
            var calculatorStack = new Calculator(new ArrayStack());
            var expression = "1 2 +";

            return 4 == calculatorStack.Calculate(expression);
        }

        private static bool ArrayStackOneNumberTestCase()
        {
            var calculatorStack = new Calculator(new ArrayStack());
            var expression = "1";

            return 1 == calculatorStack.Calculate(expression);
        }

        private static bool ArrayStackHardTestCase()
        {
            var calculatorStack = new Calculator(new ArrayStack());
            var expression = "100 54 23 * + 10 2 / - 11 +";

            return 1348 == calculatorStack.Calculate(expression);
        }

        private static bool ArrayStackMistakeOfThePastTestCase()
        {
            var calculatorStack = new Calculator(new ArrayStack());
            var expression = "5 0 -";

            return 5 == calculatorStack.Calculate(expression);
        }

        public static bool ArrayAllTestsCase()
            => ArrayStackCorrectTestCase() && !ArrayStackIncorrectTestCase() && ArrayStackOneNumberTestCase() && ArrayStackHardTestCase() && ArrayStackMistakeOfThePastTestCase();

    }
}
