using System;

namespace UniqueListNumber
{
    /// <summary>
    /// Struct of list
    /// </summary>
    public class List
    {
        private class NodeList
        {
            public int Value { get; set; }
            public NodeList NextNode { get; set; }

            public NodeList(int value)
            {
                Value = value;
                NextNode = null;
            }
        }

        private NodeList head;

        /// <summary>
        /// Insert value in List
        /// </summary>
        /// <param name="value">Inserted value</param>
        public virtual void Insert(int value, int index)
        {
            if (index > GetSize() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var newNode = new NodeList(value);
            
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var currentIndex = 1;
                NodeList cursor = head;

                while (cursor.NextNode != null)
                {
                    if (currentIndex == index)
                    {
                        newNode.NextNode = cursor.NextNode;
                        cursor.NextNode = newNode;
                        return;
                    }

                    currentIndex++;
                    cursor = cursor.NextNode;
                }

                newNode.NextNode = cursor.NextNode;
                cursor.NextNode = newNode;
            }
        }

        /// <summary>
        /// Getting the size of list
        /// </summary>
        public int GetSize()
        {
            NodeList cursor = head;
            var size = 0;

            while (cursor != null)
            {
                size++;
                cursor = cursor.NextNode;
            }

            return size;
        }

        /// <summary>
        /// Checking the presence of the value in list
        /// </summary>
        /// <param name="value">value to check</param>
        public bool IsExistValue(int value)
        {
            NodeList cursor = head;

            while (cursor != null)
            {
                if (cursor.Value == value)
                {
                    return true;
                }

                cursor = cursor.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Getting value in list by index
        /// </summary>
        /// <param name="index">Searchable index</param>
        public int GetValueByIndex(int index)
        {
            NodeList cursor = head;
            
            while (cursor != null && index != 0)
            {
                cursor = cursor.NextNode;
                index--;
            }

            return cursor == null ? throw new ValueDoesNotExistException() : cursor.Value;
        }

        /// <summary>
        /// Getting index in list by value
        /// </summary>
        /// <param name="value">Searchable value</param>
        public int GetIndexByValue(int value)
        {
            NodeList cursor = head;
            var index = 0;

            while (cursor != null)
            {
                if (cursor.Value == value)
                {
                    return index;
                }

                cursor = cursor.NextNode;
                index++;
            }

            throw new ValueDoesNotExistException();
        }

        /// <summary>
        /// Delete an item by value
        /// </summary>
        /// <param name="value">Value to delete</param>
        public virtual void DeleteByValue(int value)
        {
            if (head.Value == value)
            {
                head = head.NextNode;
                return;
            }

            NodeList cursor = head;

            while (cursor.NextNode != null)
            {
                if (cursor.NextNode.Value == value)
                {
                    cursor.NextNode = cursor.NextNode.NextNode;
                    return;
                }

                cursor = cursor.NextNode;
            }

            if (cursor.Value == value)
            {
                cursor.NextNode = null;
            }
        }

        /// <summary>
        /// Delete an item by index
        /// </summary>
        /// <param name="index">Index to delete</param>
        public virtual void DeleteByIndex(int index)
        {
            if (index == 0)
            {
                head = head.NextNode;
                return;
            }

            NodeList cursor = head;

            while (cursor.NextNode != null)
            {
                if (index == 1)
                {
                    cursor.NextNode = cursor.NextNode.NextNode;
                    return;
                }

                index--;
                cursor = cursor.NextNode;
            }
        }

        /// <summary>
        /// Print all list
        /// </summary>
        public void PrintList()
        {
            NodeList cursor = head;

            while (cursor != null)
            {
                Console.Write($"{cursor.Value} ");
                cursor = cursor.NextNode;
            }
        }

        /// <summary>
        /// Set a new value at the specified position
        /// </summary>
        public virtual void SetValueByIndex(int value, int index)
        {
            if (index > GetSize() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            NodeList cursor = head;
            var currentIndex = 0;

            while (cursor != null)
            {
                if (index == currentIndex)
                {
                    cursor.Value = value;
                }

                currentIndex++;
                cursor = cursor.NextNode;
            }
        }
    }
}