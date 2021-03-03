using System;
using System.Collections;

namespace LZWProgram
{
    /// <summary>
    /// Trie structure with hashtable
    /// </summary>
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

        /// <summary>
        /// Insert in node of trie
        /// </summary>
        /// <param name="newByte">Byte to insert</param>
        /// <param name="currentValue">Value\index to insert with byte</param>
        public void Insert(byte newByte, int currentValue)
        {
            var newNode = new HashTrieNode(currentValue);
            newNode.ParentNode = root;
            root.HashArray.Add(newByte, newNode);
        }

        /// <summary>
        /// Checking if the current node has a child with a given byte
        /// </summary>
        /// <param name="currentByte">Byte to check</param>
        /// <returns>Is there a child</returns>
        public bool HasChild(byte currentByte)
            => root.HashArray.ContainsKey(currentByte);

        /// <summary>
        /// Get the node with the current byte
        /// </summary>
        /// <param name="currentByte">Byte by which you need to search for a child</param>
        public void GetChild(byte currentByte)
        {
            if (!root.HashArray.ContainsKey(currentByte))
            {
                return;
            }
            root = (HashTrieNode)root.HashArray[currentByte];
        }

        /// <summary>
        /// Returns the current pointer to the root
        /// </summary>
        public void GoToRoot()
        {
            while (root.ParentNode != null)
            {
                root = root.ParentNode;
            }
        }

        /// <summary>
        /// Get the value from the current node
        /// </summary>
        /// <returns>Value from the node</returns>
        public int GetValue()
            => root.CurrentValue;

        /// <summary>
        /// Get value from parent node
        /// </summary>
        /// <returns>Value from parent node</returns>
        public int GetParentValue()
        {
            if (root.ParentNode == null)
            {
                throw new InvalidOperationException("Parent is null");
            }

            return root.ParentNode.CurrentValue;
        }

        /// <summary>
        /// Is the current node empty
        /// </summary>
        /// <returns>Status of node</returns>
        public bool IsEmptyNode()
            => root.HashArray.Count == 0;
    }
}