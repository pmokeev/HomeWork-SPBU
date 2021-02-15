using System;

namespace BWTAlgorithm
{
    class TestsBWT
    {
        private static bool CorrectTestCase()
        {
            var startString = "banana";
            var endString = "annb$aa";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        private static bool UncorrectTestCase()
        {
            var startString = "abrakadabra";
            var endString = "ar$dkraaabab";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        private static bool NullTestCase()
        {
            var startString = "";
            var endString = "";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        private static bool OneSymbolTestCase()
        {
            var startString = "a";
            var endString = "a$";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        private static bool OneCharTestCase()
        {
            var startString = "bbbbbbbbbbbbbbbbbb";
            var endString = "bbbbbbbbbbbbbbbbbb$";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        private static bool SentenceEncodeTestCase()
        {
            var startString = "а роза упала на лапу азора";
            var endString = "уааааанл$зр плоаа  рзуао п ";

            return String.Compare(BWTransform.StraightBWT(startString), endString) == 0;
        }

        public static bool AllTestsCaseBWT()
        {
            return CorrectTestCase() && !UncorrectTestCase() && NullTestCase() && OneSymbolTestCase() && OneCharTestCase() && SentenceEncodeTestCase();
        }

        private static bool CorrectTestCaseReverse()
        {
            var startString = "annb$aa";
            var endString = "banana";

            return String.Compare(BWTransform.ReverseBWT(startString), endString) == 0;
        }

        private static bool UncorrectTestCaseReverse()
        {
            var startString = "ard$kraaaabb";
            var endString = "abrakabadra";

            return String.Compare(BWTransform.ReverseBWT(startString), endString) == 0;
        }

        private static bool NullTestCaseReverse()
        {
            var startString = "";
            var endString = "";

            return String.Compare(BWTransform.ReverseBWT(startString), endString) == 0;
        }

        private static bool OneSymbolTestCaseReverse()
        {
            var startString = "a$";
            var endString = "a";

            return String.Compare(BWTransform.ReverseBWT(startString), endString) == 0;
        }

        private static bool SentenceDecodeTestCase()
        {
            var startString = "уааааанл$зр плоаа  рзуао п ";
            var endString = "а роза упала на лапу азора";

            return String.Compare(BWTransform.ReverseBWT(startString), endString) == 0;
        }

        public static bool AllTestsCaseBWTReverse()
        {
            return CorrectTestCaseReverse() && !UncorrectTestCaseReverse() && NullTestCaseReverse() && OneSymbolTestCaseReverse() && SentenceDecodeTestCase();
        }
    }
}
