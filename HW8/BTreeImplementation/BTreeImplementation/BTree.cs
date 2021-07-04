using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BTreeImplementation
{
    /// <summary>
    /// Class that implements B-Tree
    /// </summary>
    public class BTree<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable
    {
        private class BTreeNode
        {
            public bool IsLeaf { get; set; }
            public int MinimumDegree { get; set; }
            public BTreeNode[] Children { get; set; }
            public int NumberOfKeys { get; set; }
            public (TKey key, TValue value)[] Keys { get; set; }

            public BTreeNode(int currentDegree, bool isLeaf)
            {
                IsLeaf = isLeaf;
                MinimumDegree = currentDegree;
                Children = new BTreeNode[2 * MinimumDegree];
                Keys = new (TKey key, TValue value)[2 * MinimumDegree - 1];
                NumberOfKeys = 0;
            }

            /// <summary>
            /// Traversal to get a list of b-tree pairs
            /// </summary>
            public List<KeyValuePair<TKey, TValue>> TraverseNode()
            {
                List<KeyValuePair<TKey, TValue>> pairList = new List<KeyValuePair<TKey, TValue>>();
                int index = 0;

                for (index = 0; index < NumberOfKeys; index++)
                {
                    if (!IsLeaf)
                    {
                        pairList = pairList.Union(Children[index].TraverseNode()).ToList();
                    }

                    pairList.Add(new KeyValuePair<TKey, TValue>(Keys[index].key, Keys[index].value));
                }

                if (!IsLeaf)
                {
                    pairList = pairList.Union(Children[index].TraverseNode()).ToList();
                }

                return pairList;
            }

            /// <summary>
            /// Traversal to get a list of b-tree keys
            /// </summary>
            public List<TKey> TraverseNodeKey()
            {
                List<TKey> keyList = new List<TKey>();
                int index = 0;

                for (index = 0; index < NumberOfKeys; index++)
                {
                    if (!IsLeaf)
                    {
                        keyList = keyList.Union(Children[index].TraverseNodeKey()).ToList();
                    }

                    keyList.Add(Keys[index].key);
                }

                if (!IsLeaf)
                {
                    keyList = keyList.Union(Children[index].TraverseNodeKey()).ToList();
                }

                return keyList;
            }

            /// <summary>
            /// Traversal to get a list of tree values
            /// </summary>
            public List<TValue> TraverseNodeValue()
            {
                List<TValue> valueList = new List<TValue>();
                int index = 0;

                for (index = 0; index < NumberOfKeys; index++)
                {
                    if (!IsLeaf)
                    {
                        valueList = valueList.Union(Children[index].TraverseNodeValue()).ToList();
                    }

                    valueList.Add(Keys[index].value);
                }

                if (!IsLeaf)
                {
                    valueList = valueList.Union(Children[index].TraverseNodeValue()).ToList();
                }

                return valueList;
            }

            /// <summary>
            /// Finding a node with the required key
            /// </summary>
            public BTreeNode SearchNode(TKey currentKey)
            {
                int index = 0;

                while (index < NumberOfKeys && Comparer<TKey>.Default.Compare(currentKey, Keys[index].key) > 0)
                {
                    index++;
                }
                
                if (index != NumberOfKeys)
                {
                    if (Comparer<TKey>.Default.Compare(currentKey, Keys[index].key) == 0)
                    {
                        return this;
                    }
                }

                if (IsLeaf)
                {
                    return null;
                }

                return Children[index].SearchNode(currentKey);
            }

            /// <summary>
            /// Replace the value in a pair with a new one
            /// </summary>
            /// <param name="currentKey">Search key</param>
            /// <param name="newValue">New value in a pair</param>
            public void ChangeValue(TKey currentKey, TValue newValue)
            {
                if (IsLeaf)
                {
                    for (int i = 0; i < NumberOfKeys; i++)
                    {
                        if (Comparer<TKey>.Default.Compare(currentKey, Keys[i].key) == 0)
                        {
                            Keys[i].value = newValue;
                        }
                    }
                }

                for (int i = 0; i < NumberOfKeys; i++)
                {
                    if (Comparer<TKey>.Default.Compare(currentKey, Keys[i].key) == 0)
                    {
                        Keys[i].value = newValue;
                    }
                    else if (Comparer<TKey>.Default.Compare(currentKey, Keys[i].key) < 0)
                    {
                        Children[i].ChangeValue(currentKey, newValue);
                    }
                }

                if (Comparer<TKey>.Default.Compare(currentKey, Keys[NumberOfKeys - 1].key) < 0)
                {
                    Children[NumberOfKeys].ChangeValue(currentKey, newValue);
                }
            }

            /// <summary>
            /// Find the first key that is greater than the current one
            /// </summary>
            private int FindGreater(TKey currentKey)
            {
                int index = 0;
                
                while (index < NumberOfKeys && Comparer<TKey>.Default.Compare(Keys[index].key, currentKey) < 0)
                {
                    index++;
                }

                return index;
            }

            /// <summary>
            /// Helper function to help find the rightmost node from the left subtree.
            /// </summary>
            private (TKey key, TValue value) GetPreventElement(int currentIndex)
            {
                BTreeNode pointer = Children[currentIndex];

                while (!pointer.IsLeaf)
                {
                    pointer = pointer.Children[pointer.NumberOfKeys];
                }

                return pointer.Keys[pointer.NumberOfKeys - 1];
            }

            /// <summary>
            /// A function that finds the left key in the right subtree.
            /// </summary>
            private (TKey key, TValue value) GetNextElement(int currentIndex)
            {
                BTreeNode pointer = Children[currentIndex + 1];

                while (!pointer.IsLeaf)
                {
                    pointer = pointer.Children[0];
                }

                return pointer.Keys[0];
            }

            /// <summary>
            /// Merge Children[currentIndex + 1] into Children[currentIndex] of node
            /// </summary>
            private void Merge(int currentIndex)
            {
                BTreeNode child = Children[currentIndex];
                BTreeNode brother = Children[currentIndex + 1];

                child.Keys[MinimumDegree - 1] = Keys[currentIndex];

                for (int i = 0; i < brother.NumberOfKeys; i++)
                {
                    child.Keys[i + MinimumDegree] = brother.Keys[i];
                }

                if (!child.IsLeaf)
                {
                    for (int i = 0; i <= brother.NumberOfKeys; i++)
                    {
                        child.Children[i + MinimumDegree] = brother.Children[i];
                    }
                }

                for (int i = currentIndex + 1; i < NumberOfKeys; i++)
                {
                    Keys[i - 1] = Keys[i];
                }

                for (int i = currentIndex + 2; i <= NumberOfKeys; i++)
                {
                    Children[i - 1] = Children[i];
                }

                child.NumberOfKeys += brother.NumberOfKeys + 1;
                NumberOfKeys--;
            }

            /// <summary>
            /// Removing from a leaf
            /// </summary>
            private void RemoveFromLeaf(int currentIndex)
            {
                for (int i = currentIndex + 1; i < NumberOfKeys; i++)
                {
                    Keys[i - 1] = Keys[i];
                }

                NumberOfKeys--;
            }

            /// <summary>
            /// A function to move the key from the [currentIndex - 1] node to the [currentIndex] node
            /// </summary>
            public void BorrowFromPrevent(int currentIndex)
            {
                BTreeNode child = Children[currentIndex];
                BTreeNode brother = Children[currentIndex - 1];

                for (int i = child.NumberOfKeys - 1; i >= 0; i--)
                {
                    child.Keys[i + 1] = child.Keys[i];
                }

                if (!child.IsLeaf)
                {
                    for (int i = child.NumberOfKeys; i >= 0; i--)
                    {
                        child.Children[i + 1] = child.Children[i];
                    }
                }

                child.Keys[0] = Keys[currentIndex - 1];

                if (!child.IsLeaf)
                {
                    child.Children[0] = brother.Children[brother.NumberOfKeys];
                }

                Keys[currentIndex - 1] = brother.Keys[brother.NumberOfKeys - 1];
                child.NumberOfKeys++;
                brother.NumberOfKeys--;
            }

            /// <summary>
            /// A function to move the key from the [currentIndex + 1] node to the [currentIndex] node
            /// </summary>
            private void BorrowFromNext(int currentIndex)
            {
                BTreeNode child = Children[currentIndex];
                BTreeNode brother = Children[currentIndex + 1];

                child.Keys[child.NumberOfKeys] = Keys[currentIndex];

                if (!child.IsLeaf)
                {
                    child.Children[child.NumberOfKeys + 1] = brother.Children[0];
                }

                Keys[currentIndex] = brother.Keys[0];

                for (int i = 1; i < brother.NumberOfKeys; i++)
                {
                    brother.Keys[i - 1] = brother.Keys[i];
                }

                if (!brother.IsLeaf)
                {
                    for (int i = 1; i <= brother.NumberOfKeys; i++)
                    {
                        brother.Children[i - 1] = brother.Children[i];
                    }
                }

                child.NumberOfKeys++;
                brother.NumberOfKeys--;
            }

            /// <summary>
            /// Fill Children[idx] with less than MinimumDegree keys
            /// </summary>
            public void FillChildrens(int currentIndex)
            {
                if (currentIndex != 0 && Children[currentIndex - 1].NumberOfKeys >= MinimumDegree)
                {
                    BorrowFromPrevent(currentIndex);
                }
                else if (currentIndex != NumberOfKeys && Children[currentIndex + 1].NumberOfKeys >= MinimumDegree)
                {
                    BorrowFromNext(currentIndex);
                }
                else
                {
                    if (currentIndex != NumberOfKeys)
                    {
                        Merge(currentIndex);
                    }
                    else
                    {
                        Merge(currentIndex - 1);
                    }
                }
            }

            /// <summary>
            /// A function that removes a key and a value from a node.
            /// </summary>
            /// <param name="currentKey">The key by which to delete the pair</param>
            public void Remove(TKey currentKey)
            {
                int index = FindGreater(currentKey);
                
                if (index < NumberOfKeys && Comparer<TKey>.Default.Compare(Keys[index].key, currentKey) == 0)
                {
                    if (IsLeaf)
                    {
                        RemoveFromLeaf(index);
                    }
                    else
                    {
                        RemoveFromNotLeaf(index);
                    }
                }
                else
                {
                    if (IsLeaf)
                    {
                        throw new NonExistentKeyException("There is no such key!");
                    }

                    bool flag = index == NumberOfKeys;

                    if (Children[index].NumberOfKeys < MinimumDegree)
                    {
                        FillChildrens(index);
                    }

                    if (flag && index > NumberOfKeys)
                    {
                        Children[index - 1].Remove(currentKey);
                    }
                    else
                    {
                        Children[index].Remove(currentKey);
                    }
                }
            }

            /// <summary>
            /// A function that removes a value not from a sheet.
            /// </summary>
            private void RemoveFromNotLeaf(int currentIndex)
            {
                TKey key = Keys[currentIndex].key;

                if (Children[currentIndex].NumberOfKeys >= MinimumDegree)
                {
                    (TKey key, TValue value) pred = GetPreventElement(currentIndex);
                    Keys[currentIndex] = pred;
                    Children[currentIndex].Remove(pred.key);
                }
                else if (Children[currentIndex + 1].NumberOfKeys >= MinimumDegree)
                {
                    (TKey key, TValue value) next = GetNextElement(currentIndex);
                    Keys[currentIndex] = next;
                    Children[currentIndex + 1].Remove(next.key);
                }
                else
                {
                    Merge(currentIndex);
                    Children[currentIndex].Remove(key);
                }
            }

            /// <summary>
            /// Function to split the child of this node.
            /// </summary>
            /// <param name="index">Split child index</param>
            /// <param name="node">Node for dividing the child.</param>
            public void SplitChild(int index, BTreeNode node)
            {
                BTreeNode newNode = new BTreeNode(node.MinimumDegree, node.IsLeaf);
                newNode.NumberOfKeys = MinimumDegree - 1;

                for (int i = 0; i < MinimumDegree - 1; i++)
                {
                    newNode.Keys[i] = node.Keys[i + MinimumDegree];
                }

                if (!node.IsLeaf)
                {
                    for (int i = 0; i < MinimumDegree; i++)
                    {
                        newNode.Children[i] = node.Children[i + MinimumDegree];
                    }
                }

                node.NumberOfKeys = MinimumDegree - 1;

                for (int i = NumberOfKeys; i >= index + 1; i--)
                {
                    Children[i + 1] = Children[i];
                }

                Children[index + 1] = newNode;

                for (int i = NumberOfKeys - 1; i >= index; i--)
                {
                    Keys[i + 1] = Keys[i];
                }

                Keys[index] = node.Keys[MinimumDegree - 1];
                NumberOfKeys++;
            }

            /// <summary>
            /// Adding a new key and value to the node.
            /// </summary>
            public void InsertNotFull(TKey currentKey, TValue currentValue)
            {
                (TKey key, TValue value) newKey = (currentKey, currentValue);

                int index = NumberOfKeys - 1;
                
                if (IsLeaf)
                {
                    while (index >= 0 && Comparer<TKey>.Default.Compare(Keys[index].key, newKey.key) > 0)
                    {
                        Keys[index + 1] = Keys[index];
                        index--;
                    }

                    Keys[index + 1] = newKey;
                    NumberOfKeys++;
                }
                else
                {
                    while (index >= 0 && Comparer<TKey>.Default.Compare(Keys[index].key, newKey.key) > 0)
                    {
                        index--;
                    }

                    if (Children[index + 1].NumberOfKeys == 2 * MinimumDegree - 1)
                    {
                        SplitChild(index + 1, Children[index + 1]);
                        
                        if (Comparer<TKey>.Default.Compare(Keys[index + 1].key, newKey.key) < 0)
                        {
                            index++;
                        }
                    }

                    Children[index + 1].InsertNotFull(currentKey, currentValue);
                }
            }
        }

        private BTreeNode root;
        private int minimumDegree;
        private int versionBTree;

        public BTree(int currentDegree)
        {
            minimumDegree = currentDegree;
            versionBTree = 0;
        }

        /// <summary>
        /// Property storing the current list of b-tree keys
        /// </summary>
        public ICollection<TKey> Keys
            => root.TraverseNodeKey();

        /// <summary>
        /// Property storing the current list of b-tree values
        /// </summary>
        public ICollection<TValue> Values
            => root.TraverseNodeValue();

        /// <summary>
        /// Property storing the number of pairs in the b-tree
        /// </summary>
        public int Count 
            => Keys.Count;

        /// <summary>
        /// Gets a value indicating whether the object is read-only.
        /// </summary>
        public bool IsReadOnly
            => false;

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        public TValue this[TKey key]
        {
            get
            {
                TValue outputValue;
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                else if (!TryGetValue(key, out outputValue))
                {
                    throw new KeyNotFoundException();
                }

                return outputValue;
            }
            set => Add(key, value);
        }

        private List<KeyValuePair<TKey, TValue>> Traverse()
        {
            if (!IsEmpty())
            {
                return root.TraverseNode();
            }

            return null;
        }

        /// <summary>
        /// Clear the current b-tree
        /// </summary>
        public void Clear()
        {
            List<TKey> temp = new List<TKey>(Keys);

            foreach (var item in temp)
            {
                Remove(item);
            }

            versionBTree++;
        }

        /// <summary>
        /// Empty tree check
        /// </summary>
        public bool IsEmpty()
            => root == null;

        /// <summary>
        /// A function that returns by reference a value for a given key and a boolean value that means there is such a key in the b-tree
        /// </summary>
        /// <returns>boolean meaning the presence of such a key in the b-tree</returns>
        public bool TryGetValue(TKey currentKey, out TValue outputValue)
        {
            if (root == null)
            {
                outputValue = default(TValue);
                return false;
            }

            BTreeNode currentNode = root.SearchNode(currentKey);

            if (currentNode == null)
            {
                outputValue = default(TValue);
                return false;
            }
            else
            {
                for (int i = 0; i < currentNode.NumberOfKeys; i++)
                {
                    if (Comparer<TKey>.Default.Compare(currentNode.Keys[i].key, currentKey) == 0)
                    {
                        outputValue = currentNode.Keys[i].value;
                        return true;
                    }
                }
            }

            outputValue = default(TValue);
            return false;
        }

        /// <summary>
        /// Determines whether the collection contains the specified value.
        /// </summary>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (TryGetValue(item.Key, out TValue result) && Comparer<TValue>.Default.Compare(item.Value, result) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if an element with the specified key is contained
        /// </summary>
        public bool ContainsKey(TKey currentKey)
            => TryGetValue(currentKey, out TValue outputValue);

        /// <summary>
        /// A function that changes the value paired with the current key to a new one
        /// </summary>
        public void ChangeValue(TKey currentKey, TValue newValue)
        {
            if (!ContainsKey(currentKey))
            {
                throw new NonExistentKeyException();
            }

            root.ChangeValue(currentKey, newValue);
            versionBTree++;
        }

        /// <summary>
        /// Function for adding a pair using KeyValuePair
        /// </summary>
        public void Add(KeyValuePair<TKey, TValue> item)
            => Add(item.Key, item.Value);

        /// <summary>
        /// Insert in tree
        /// </summary>
        public void Add(TKey keyToAdd, TValue valueToAdd)
        {
            if (keyToAdd == null)
            {
                throw new ArgumentNullException();
            }
            else if (TryGetValue(keyToAdd, out TValue result))
            {
                throw new ArgumentException();
            }

            (TKey key, TValue value) newKey = (keyToAdd, valueToAdd);

            if (IsEmpty())
            {
                root = new BTreeNode(minimumDegree, true);
                root.Keys[0] = newKey;
                root.NumberOfKeys = 1;
            }
            else
            {
                if (root.NumberOfKeys == 2 * minimumDegree - 1)
                {
                    BTreeNode newNode = new BTreeNode(minimumDegree, false);
                    newNode.Children[0] = root;
                    newNode.SplitChild(0, root);
                    int index = 0;
                    
                    if (Comparer<TKey>.Default.Compare(newNode.Keys[0].key, newKey.key) < 0)
                    {
                        index++;
                    }

                    newNode.Children[index].InsertNotFull(newKey.key, newKey.value);
                    root = newNode;
                }
                else
                { 
                    root.InsertNotFull(newKey.key, newKey.value);
                }
            }

            versionBTree++;
        }

        /// <summary>
        /// Function for remove a pair using KeyValuePair
        /// </summary>
        public bool Remove(KeyValuePair<TKey, TValue> item)
            => Remove(item.Key);

        /// <summary>
        /// Remove from tree
        /// </summary>
        /// <param name="keyToDelete"></param>
        public bool Remove(TKey keyToDelete)
        {
            if (keyToDelete == null)
            {
                throw new ArgumentNullException();
            }

            if (IsEmpty() || !TryGetValue(keyToDelete, out TValue outputValue))
            {
                return false;
            }

            root.Remove(keyToDelete);

            if (root.NumberOfKeys == 0)
            {
                if (root.IsLeaf)
                {
                    root = null;
                }
                else
                {
                    root = root.Children[0];
                }
            }

            versionBTree++;
            return true;
        }

        /// <summary>
        /// Prints all values in the tree
        /// </summary>
        public void PrintElementsInTree()
        {
            if (IsEmpty())
            {
                List<KeyValuePair<TKey, TValue>> pairList = Traverse();

                foreach (var item in pairList)
                {
                    Console.WriteLine($"Key = {item.Key}, value = {item.Value}");
                }
            }
        }

        /// <summary>
        /// Copies the elements of the collection to an Array, starting at the specified index of the Array.
        /// </summary>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException();
            }

            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        private class DictionaryEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private int currentIndex = -1;
            private int currentVersion;
            private List<KeyValuePair<TKey, TValue>> pairList;
            BTree<TKey, TValue> tree;

            public DictionaryEnumerator(BTree<TKey, TValue> currentTree)
            {
                pairList = currentTree.Traverse();
                currentVersion = currentTree.versionBTree;
                tree = currentTree;
            }

            /// <summary>
            /// The current element of the enumerator
            /// </summary>
            public object Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex >= pairList.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return pairList[currentIndex];
                }
            }

            KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current
                => (KeyValuePair<TKey, TValue>)Current;

            /// <summary>
            /// Go to new item
            /// </summary>
            public bool MoveNext()
            {
                if (currentVersion != tree.versionBTree)
                {
                    throw new InvalidOperationException();
                }

                if (currentIndex < pairList.Count - 1)
                {
                    currentIndex++;
                    return true;
                }

                return false;
            }

            /// <summary>
            /// "Our song is good - start over" (Наша песня хороша - начинай сначала)
            /// </summary>
            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose() { }
        }

        /// <summary>
        /// Returns an enumerator that iterates over the collection.
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new DictionaryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}