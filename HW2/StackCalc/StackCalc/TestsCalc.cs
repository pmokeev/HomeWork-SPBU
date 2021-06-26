using System;

namespace StackCalc
{
    class TestsCalc
    {
        private static bool CorrectTestCase()
        {
            var listCalc = new Calculator(new ListStack());
            var arrayCalc = new Calculator(new ArrayStack());
            var expression = "1 2 3 + *";


            return 5 == listCalc.Calculate(expression) && 5 == arrayCalc.Calculate(expression);
        }

        private static bool IncorrectTestCase()
        {
            var listCalc = new Calculator(new ListStack());
            var arrayCalc = new Calculator(new ArrayStack());
            var expression = "1 2 +";

            return 4 == listCalc.Calculate(expression) && 4 == arrayCalc.Calculate(expression);
        }

        private static bool OneNumberTestCase()
        {
            var listCalc = new Calculator(new ListStack());
            var arrayCalc = new Calculator(new ArrayStack());
            var expression = "1";

            return 1 == listCalc.Calculate(expression) && 1 == arrayCalc.Calculate(expression);
        }

        private static bool HardTestCase()
        {
            var listCalc = new Calculator(new ListStack());
            var arrayCalc = new Calculator(new ArrayStack());
            var expression = "100 54 23 * + 10 2 / - 11 +";

            return 1348 == listCalc.Calculate(expression) && 1348 == arrayCalc.Calculate(expression);
        }

        private static bool MistakeOfThePastTestCase()
        {
            var listCalc = new Calculator(new ListStack());
            var arrayCalc = new Calculator(new ArrayStack());
            var expression = "5 0 -";

            return 5 == listCalc.Calculate(expression) && 5 == arrayCalc.Calculate(expression);
        }

        public static bool AllTestsCase()
            => CorrectTestCase() && !IncorrectTestCase() && OneNumberTestCase() && HardTestCase() && MistakeOfThePastTestCase();
    }
}