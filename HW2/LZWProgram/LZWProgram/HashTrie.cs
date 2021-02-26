using System;
using System.Collections;

namespace LZWProgram
{
    public class HashTrie
    {
        private class HashTrieNode
        {
            public Hashtable hashArray { get; set; }
            public int CurrentValue { get; set; }

            public HashTrieNode()
            {
                CurrentValue = -1;
                hashArray = new Hashtable();
            }

            public HashTrieNode(int currentValue)
            {
                CurrentValue = currentValue;
                hashArray = new Hashtable();
            }
        }

        private HashTrieNode root;

        public void Insert(byte newByte, int currentValue)
        {
            var newNode = new HashTrieNode(currentValue);
            root.hashArray.Add(newByte, newNode);
        }

        public bool HasChild(byte currentByte)
            => root.hashArray.ContainsKey(currentByte);

        public void GetChild(byte currentByte)
            => root = (HashTrieNode)root.hashArray[currentByte];

        public int GetValue()
            => root.CurrentValue;
    }
}