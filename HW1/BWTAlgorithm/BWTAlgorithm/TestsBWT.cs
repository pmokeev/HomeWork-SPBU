using System;

namespace BWTAlgorithm
{
    class TestsBWT
    {
        private static bool CorrectTestCase()
        {
            var startString = "banana";
            var endString = "annb$aa";

            return BWTransform.StraightBWT(startString) == endString;
        }

        private static bool IncorrectTestCase()
        {
            var startString = "abrakadabra";
            var endString = "ar$dkraaabab";

            return BWTransform.StraightBWT(startString) == endString;
        }

        private static bool NullTestCase()
        {
            var startString = "";
            var endString = "";

            return BWTransform.StraightBWT(startString) == endString;
        }

        private static bool OneSymbolTestCase()
        {
            var startString = "a";
            var endString = "a$";

            return BWTransform.StraightBWT(startString) == endString;
        }

        private static bool OneCharTestCase()
        {
            var startString = "bbbbbbbbbbbbbbbbbb";
            var endString = "bbbbbbbbbbbbbbbbbb$";

            return BWTransform.StraightBWT(startString) == endString;
        }

        private static bool SentenceEncodeTestCase()
        {
            var startString = "а роза упала на лапу азора";
            var endString = "уааааанл$зр плоаа  рзуао п ";

            return BWTransform.StraightBWT(startString) == endString;
        }

        public static bool AllTestsCaseBWT()
            => CorrectTestCase() && !IncorrectTestCase() && NullTestCase() && OneSymbolTestCase() && OneCharTestCase() && SentenceEncodeTestCase();

        private static bool CorrectTestCaseReverse()
        {
            var startString = "annb$aa";
            var endString = "banana";

            return BWTransform.ReverseBWT(startString) == endString;
        }

        private static bool IncorrectTestCaseReverse()
        {
            var startString = "ard$kraaaabb";
            var endString = "abrakabadra";

            return BWTransform.ReverseBWT(startString) == endString;
        }

        private static bool NullTestCaseReverse()
        {
            var startString = "";
            var endString = "";

            return BWTransform.ReverseBWT(startString) == endString;
        }

        private static bool OneSymbolTestCaseReverse()
        {
            var startString = "a$";
            var endString = "a";

            return BWTransform.ReverseBWT(startString) == endString;
        }

        private static bool SentenceDecodeTestCase()
        {
            var startString = "уааааанл$зр плоаа  рзуао п ";
            var endString = "а роза упала на лапу азора";

            return BWTransform.ReverseBWT(startString) == endString;
        }

        public static bool AllTestsCaseBWTReverse()
            => CorrectTestCaseReverse() && !IncorrectTestCaseReverse() && NullTestCaseReverse() && OneSymbolTestCaseReverse() && SentenceDecodeTestCase();
    }
}
