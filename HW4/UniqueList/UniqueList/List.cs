using System;

namespace UniqueListNumber
{
    /// <summary>
    /// Struct of list
    /// </summary>
    public class List
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode(int value)
            {
                Value = value;
                NextNode = null;
            }
        }

        private ListNode head;
        private int size = 0;

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

            var newNode = new ListNode(value);
            
            if (head == null)
            {
                head = newNode;
                size = 1;
                return;
            }
            var currentIndex = 1;
            ListNode cursor = head;

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
            size++;
        }

        /// <summary>
        /// Getting the size of list
        /// </summary>
        public int GetSize()
            => size;

        /// <summary>
        /// Checking the presence of the value in list
        /// </summary>
        /// <param name="value">value to check</param>
        public bool Contains(int value)
        {
            ListNode cursor = head;

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
            if (index > GetSize() || index < 0)
            {
                throw new ValueDoesNotExistException();
            }

            ListNode cursor = head;
            
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
            ListNode cursor = head;
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
            if (!Contains(value))
            {
                throw new ValueDoesNotExistException("There is no such element!");
            }

            if (head.Value == value)
            {
                head = head.NextNode;
                size--;
                return;
            }

            ListNode cursor = head;

            while (cursor.NextNode != null)
            {
                if (cursor.NextNode.Value == value)
                {
                    cursor.NextNode = cursor.NextNode.NextNode;
                    size--;
                    return;
                }

                cursor = cursor.NextNode;
            }

            if (cursor.Value == value)
            {
                cursor.NextNode = null;
                size--;
            }
        }

        /// <summary>
        /// Delete an item by index
        /// </summary>
        /// <param name="index">Index to delete</param>
        public virtual void DeleteByIndex(int index)
        {
            if (index > GetSize() || index < 0)
            {
                throw new ValueDoesNotExistException();
            }

            if (index == 0)
            {
                head = head.NextNode;
                size--;
                return;
            }

            ListNode cursor = head;

            while (cursor.NextNode != null)
            {
                if (index == 1)
                {
                    cursor.NextNode = cursor.NextNode.NextNode;
                    size--;
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
            ListNode cursor = head;

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

            ListNode cursor = head;
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