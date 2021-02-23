using System;
using System.Collections;

namespace LZWProgram
{
    class HashTrie
    {
        private class HashTrieNode
        {
            public bool endOfWord;
            public Hashtable hashArray;

            public HashTrieNode()
            {
                this.endOfWord = false;
                this.hashArray = new Hashtable();
            }
        }

        private HashTrieNode root = new HashTrieNode();

        public void Insert(string currentString)
        {
            if (currentString.Length == 0)
            {
                return;
            }

            HashTrieNode currentNode = root;

            for (int i = 0; i < currentString.Length; i++)
            {
                var node = (HashTrieNode)currentNode.hashArray[currentString[i]];

                if (node == null)
                {
                    node = new HashTrieNode();
                    currentNode.hashArray.Add(currentString[i], node);
                }

                currentNode = node;
            }

            currentNode.endOfWord = true;
        }

        public bool IsExist(string currentString)
        {
            if (root == null || currentString.Length == 0)
            {
                return false;
            }

            HashTrieNode currentNode = root;

            for (int i = 0; i < currentString.Length; i++)
            {
                var node = (HashTrieNode)currentNode.hashArray[currentString[i]];

                if (node == null)
                {
                    return false;
                }
                else
                {
                    currentNode = node;
                }
            }

            return currentNode.endOfWord == true;
        }
    }
}
