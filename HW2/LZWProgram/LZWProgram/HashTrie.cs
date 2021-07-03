using System;
using System.Collections.Generic;

namespace LZWProgram
{
    /// <summary>
    /// Trie structure with hashtable
    /// </summary>
    public class HashTrie
    {
        private class HashTrieNode
        {
            public Dictionary<byte, HashTrieNode> Dictionary { get; set; }
            public int CurrentValue { get; set; }
            public HashTrieNode ParentNode { get; set; }

            public HashTrieNode(int currentValue)
            {
                Dictionary = new Dictionary<byte, HashTrieNode>();
                CurrentValue = currentValue;
                ParentNode = null;
            }
        }

        private HashTrieNode root = new HashTrieNode(-1);
        private HashTrieNode cursor;

        /// <summary>
        /// Init hash trie
        /// </summary>
        public HashTrie()
        {
            cursor = root;
        }

        /// <summary>
        /// Insert in node of trie
        /// </summary>
        /// <param name="newByte">Byte to insert</param>
        /// <param name="currentValue">Value\index to insert with byte</param>
        public void Insert(byte newByte, int currentValue)
        {
            var newNode = new HashTrieNode(currentValue);
            newNode.ParentNode = cursor;
            cursor.Dictionary.Add(newByte, newNode);
        }

        /// <summary>
        /// Checking if the current node has a child with a given byte
        /// </summary>
        /// <param name="currentByte">Byte to check</param>
        /// <returns>Is there a child</returns>
        public bool HasChild(byte currentByte)
            => cursor.Dictionary.ContainsKey(currentByte);

        /// <summary>
        /// Get the node with the current byte
        /// </summary>
        /// <param name="currentByte">Byte by which you need to search for a child</param>
        public void GoToChild(byte currentByte)
        {
            if (!cursor.Dictionary.ContainsKey(currentByte))
            {
                return;
            }
            cursor = cursor.Dictionary[currentByte];
        }

        /// <summary>
        /// Returns the current pointer to the root
        /// </summary>
        public void GoToRoot()
        {
            cursor = root;
        }

        /// <summary>
        /// Get the value from the current node
        /// </summary>
        /// <returns>Value from the node</returns>
        public int GetValue()
            => cursor.CurrentValue;

        /// <summary>
        /// Get value from parent node
        /// </summary>
        /// <returns>Value from parent node</returns>
        public int GetParentValue()
        {
            if (cursor.ParentNode == null)
            {
                throw new InvalidOperationException("Parent is null");
            }

            return cursor.ParentNode.CurrentValue;
        }

        /// <summary>
        /// Is the current node empty
        /// </summary>
        /// <returns>Status of node</returns>
        public bool IsEmptyNode()
            => cursor.Dictionary.Count == 0;
    }
}