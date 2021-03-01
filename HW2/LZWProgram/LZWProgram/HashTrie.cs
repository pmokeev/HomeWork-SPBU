using System;
using System.Collections;

namespace LZWProgram
{
    public class HashTrie
    {
        private class HashTrieNode
        {
            public Hashtable HashArray { get; set; }
            public int CurrentValue { get; set; }
            public HashTrieNode ParentNode { get; set; }

            public HashTrieNode()
            {
                CurrentValue = -1;
                HashArray = new Hashtable();
                ParentNode = null;
            }

            public HashTrieNode(int currentValue)
            {
                CurrentValue = currentValue;
                HashArray = new Hashtable();
                ParentNode = null;
            }
        }

        private HashTrieNode root = new HashTrieNode();

        public void Insert(byte newByte, int currentValue)
        {
            var newNode = new HashTrieNode(currentValue);
            newNode.ParentNode = root;
            root.HashArray.Add(newByte, newNode);
        }

        public bool HasChild(byte currentByte)
            => root.HashArray.ContainsKey(currentByte);

        public void GetChild(byte currentByte)
            => root = (HashTrieNode)root.HashArray[currentByte];

        public void GoToRoot()
        {
            while (root.ParentNode != null)
            {
                root = root.ParentNode;
            }
        }

        public int GetValue()
            => root.CurrentValue;

        public int GetValueOfParent()
            => root.ParentNode.CurrentValue;
    }
}