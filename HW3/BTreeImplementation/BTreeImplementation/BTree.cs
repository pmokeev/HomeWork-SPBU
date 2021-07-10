using System;

namespace BTreeImplementation
{
    /// <summary>
    /// Class that implements B-Tree
    /// </summary>
    public class BTree
    {
        private class BTreeNode
        {
            public bool IsLeaf { get; set; }
            public int MinimumDegree { get; set; }
            public BTreeNode[] Children { get; set; }
            public int NumberOfKeys { get; set; }
            public (string key, string value)[] Keys { get; set; }

            public BTreeNode(int currentDegree, bool isLeaf)
            {
                IsLeaf = isLeaf;
                MinimumDegree = currentDegree;
                Children = new BTreeNode[2 * MinimumDegree];
                Keys = new (string key, string value)[2 * MinimumDegree - 1];
                NumberOfKeys = 0;
            }

            /// <summary>
            /// Print the values of the current node
            /// </summary>
            public void PrintNode()
            {
                int index;

                for (index = 0; index < NumberOfKeys; index++)
                {
                    if (!IsLeaf)
                    {
                        Children[index].PrintNode();
                    }

                    Console.WriteLine($" Key = {Keys[index].key}, Value = {Keys[index].value};");
                }

                if (!IsLeaf)
                {
                    Children[index].PrintNode();
                }
            }

            /// <summary>
            /// Finding a node with the required key
            /// </summary>
            public BTreeNode SearchNode(string currentKey)
            {
                int index = 0;

                while (index < NumberOfKeys && String.Compare(currentKey, Keys[index].key) > 0)
                {
                    index++;
                }
                
                if (index != NumberOfKeys)
                {
                    if (String.Compare(Keys[index].key, currentKey) == 0)
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
            public void ChangeValue(string currentKey, string newValue)
            {
                if (IsLeaf)
                {
                    for (int i = 0; i < NumberOfKeys; i++)
                    {
                        if (currentKey == Keys[i].key)
                        {
                            Keys[i].value = newValue;
                        }
                    }
                }

                for (int i = 0; i < NumberOfKeys; i++)
                {
                    if (Keys[i].key == currentKey)
                    {
                        Keys[i].value = newValue;
                    }
                    else if (String.Compare(currentKey, Keys[i].key) < 0)
                    {
                        Children[i].ChangeValue(currentKey, newValue);
                    }
                }

                if (String.Compare(currentKey, Keys[NumberOfKeys - 1].key) < 0)
                {
                    Children[NumberOfKeys].ChangeValue(currentKey, newValue);
                }
            }

            /// <summary>
            /// Find the first key that is greater than the current one
            /// </summary>
            private int FindGreater(string currentKey)
            {
                int index = 0;

                while (index < NumberOfKeys && String.Compare(Keys[index].key, currentKey) < 0)
                {
                    index++;
                }

                return index;
            }

            /// <summary>
            /// Helper function to help find the rightmost node from the left subtree.
            /// </summary>
            private (string key, string value) GetPreventElement(int currentIndex)
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
            private (string key, string value) GetNextElement(int currentIndex)
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
            public void Remove(string currentKey)
            {
                int index = FindGreater(currentKey);

                if (index < NumberOfKeys && Keys[index].key == currentKey)
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
                string key = Keys[currentIndex].key;

                if (Children[currentIndex].NumberOfKeys >= MinimumDegree)
                {
                    (string key, string value) pred = GetPreventElement(currentIndex);
                    Keys[currentIndex] = pred;
                    Children[currentIndex].Remove(pred.key);
                }
                else if (Children[currentIndex + 1].NumberOfKeys >= MinimumDegree)
                {
                    (string key, string value) next = GetNextElement(currentIndex);
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
            public void InsertNotFull(string currentKey, string currentValue)
            {
                (string key, string value) newKey = (currentKey, currentValue);

                int index = NumberOfKeys - 1;
                
                if (IsLeaf)
                {
                    while (index >= 0 && String.Compare(Keys[index].key, newKey.key) > 0)
                    {
                        Keys[index + 1] = Keys[index];
                        index--;
                    }

                    Keys[index + 1] = newKey;
                    NumberOfKeys++;
                }
                else
                {
                    while (index >= 0 && String.Compare(Keys[index].key, newKey.key) > 0)
                    {
                        index--;
                    }

                    if (Children[index + 1].NumberOfKeys == 2 * MinimumDegree - 1)
                    {
                        SplitChild(index + 1, Children[index + 1]);
                        
                        if (String.Compare(Keys[index + 1].key, newKey.key) < 0)
                        {
                            index++;
                        }
                    }

                    Children[index + 1].InsertNotFull(currentKey, currentValue);
                }
            }
        }

        private BTreeNode root;
        private int MinimumDegree;

        public BTree(int currentDegree)
        {
            MinimumDegree = currentDegree;
        }

        /// <summary>
        /// Empty tree check
        /// </summary>
        public bool IsEmpty()
            => root == null;

        public string GetValue(string currentKey)
        {
            BTreeNode currentNode = root.SearchNode(currentKey);

            if (currentNode == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < currentNode.NumberOfKeys; i++)
                {
                    if (currentNode.Keys[i].key == currentKey)
                    {
                        return currentNode.Keys[i].value;
                    }
                }
            }

            return null;
        }

        public bool IsExistKey(string currentKey)
            => GetValue(currentKey) != null;

        /// <summary>
        /// A function that changes the value paired with the current key to a new one
        /// </summary>
        public void ChangeValue(string currentKey, string newValue)
        {
            if (!IsExistKey(currentKey))
            {
                throw new NonExistentKeyException();
            }

            root.ChangeValue(currentKey, newValue);
        }

        /// <summary>
        /// Insert in tree
        /// </summary>
        public void Insert(string keyToAdd, string valueToAdd)
        {
            (string key, string value) newKey = (keyToAdd, valueToAdd);

            if (IsEmpty())
            {
                root = new BTreeNode(MinimumDegree, true);
                root.Keys[0] = newKey;
                root.NumberOfKeys = 1;
            }
            else
            {
                if (root.NumberOfKeys == 2 * MinimumDegree - 1)
                {
                    BTreeNode newNode = new BTreeNode(MinimumDegree, false);
                    newNode.Children[0] = root;
                    newNode.SplitChild(0, root);
                    int index = 0;
                    
                    if (String.Compare(newNode.Keys[0].key, newKey.key) < 0)
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
        }

        /// <summary>
        /// Remove from tree
        /// </summary>
        /// <param name="keyToDelete"></param>
        public void Delete(string keyToDelete)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty!");
                return;
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
        }

        /// <summary>
        /// Prints all values in the tree
        /// </summary>
        public void PrintElementsInTree()
        {
            if (root != null)
            {
                root.PrintNode();
            }
        }
    }
}