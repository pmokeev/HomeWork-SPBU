using System;

namespace LZWProgram
{
    class TestsLZW
    {
        private static bool TestInsertTrie()
        {
            HashTrie trie = new HashTrie();

            trie.Insert("azaza");
            trie.Insert("azazt");

            return trie.IsExist("azaza");
        }

        private static bool TestOneSymbolTrie()
        {
            HashTrie trie = new HashTrie();

            trie.Insert("a");

            return trie.IsExist("a");
        }

        private static bool IncorrectExistTestTrie()
        {
            HashTrie trie = new HashTrie();

            trie.Insert("privet");
            trie.Insert("kak");
            trie.Insert("dela");
            trie.Insert("pogoda");

            return trie.IsExist("lublusisharp");
        }

        private static bool TestNullInsertTrie()
        {
            HashTrie trie = new HashTrie();

            trie.Insert("");

            return trie.IsExist("");
        }

        public static bool AllTestsTrie()
            => TestInsertTrie() && TestOneSymbolTrie() && !IncorrectExistTestTrie() && !TestNullInsertTrie();
    }
}
