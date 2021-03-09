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
        private NodeList endCursor;

        /// <summary>
        /// Insert value in List
        /// </summary>
        /// <param name="value">Inserted value</param>
        public virtual void Insert(int value)
        {
            var newNode = new NodeList(value);
            if (head == null)
            {
                head = newNode;
                endCursor = head;
            }
            else
            {
                endCursor.NextNode = newNode;
                endCursor = endCursor.NextNode;
            }
        }

        /// <summary>
        /// Getting the size of list
        /// </summary>
        public int GetSize()
        {
            NodeList cursor = head;
            int size = 0;

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
        public int GetIndexByValue(int value)
        {
            NodeList cursor = head;
            int index = 0;

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
                Console.WriteLine($"{cursor.Value} ");
                cursor = cursor.NextNode;
            }
        }
    }
}