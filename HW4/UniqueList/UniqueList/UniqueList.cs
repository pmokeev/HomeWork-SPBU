using System;

namespace UniqueListNumber
{
    /// <summary>
    /// Class unique list, which inherits from a simple list
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Insert value in unique list
        /// </summary>
        /// <param name="value">value to insert</param>
        public override void Insert(int value, int index)
        {
            if (IsExistValue(value))
            {
                throw new ValueIsAlreadyInsertedException("Error! Value is already inserted");
            }

            base.Insert(value, index);
        }

        /// <summary>
        /// Delete an item by value from unique list
        /// </summary>
        /// <param name="value">value to delete</param>
        public override void DeleteByValue(int value)
        {
            if (!IsExistValue(value))
            {
                throw new ValueDoesNotExistException("There is no such element!");
            }

            base.DeleteByValue(value);
        }

        /// <summary>
        /// Delete an item by index from unique list
        /// </summary>
        /// <param name="index">index to delete</param>
        public override void DeleteByIndex(int index)
        {
            if (index > GetSize() || index < 0 )
            {
                throw new ValueDoesNotExistException("There is no such element!");
            }

            base.DeleteByIndex(index);
        }

        /// <summary>
        /// Set value by index in unique list
        /// </summary>
        public override void SetValueByIndex(int value, int index)
        {
            if (index > GetSize() || index < 0)
            {
                throw new ValueDoesNotExistException("There is no such element!");
            }
            else if (IsExistValue(value) && index != GetIndexByValue(value))
            {
                throw new ValueIsAlreadyInsertedException("Error! Value is already inserted");
            }

            base.SetValueByIndex(value, index);
        }
    }
}
