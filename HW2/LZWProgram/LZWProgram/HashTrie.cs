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
            public HashTrieNode ParentNode{ get; set; }

            public HashTrieNode()
            {
                CurrentValue = -1;
                hashArray = new Hashtable();
                ParentNode = null;
            }

            public HashTrieNode(int currentValue)
            {
                CurrentValue = currentValue;
                hashArray = new Hashtable();
                ParentNode = null;
            }
        }

        private HashTrieNode root = new HashTrieNode();

        public void Insert(byte newByte, int currentValue)
        {
            var newNode = new HashTrieNode(currentValue);
            newNode.ParentNode = root;
            root.hashArray.Add(newByte, newNode);
        }

        public bool HasChild(byte currentByte)
            => root.hashArray.ContainsKey(currentByte);

        public void GetChild(byte currentByte)
            => root = (HashTrieNode)root.hashArray[currentByte];

        public int GetValue()
            => root.CurrentValue;

        public bool HasParent()
            => root.ParentNode == null;

        public int GetValueOfParent()
            => root.ParentNode.CurrentValue;
    }
}