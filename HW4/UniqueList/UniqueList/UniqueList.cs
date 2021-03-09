using System;

namespace UniqueListNumber
{
    public class UniqueList : List
    {
        /// <summary>
        /// Insert value in unique list
        /// </summary>
        /// <param name="value">value to insert</param>
        public override void Insert(int value)
        {
            if (IsExistValue(value))
            {
                throw new ValueIsAlreadyInsertedException("Error! Value is already inserted");
            }

            base.Insert(value);
        }

        /// <summary>
        /// Delete an item by value from unique list
        /// </summary>
        /// <param name="value">value to delete</param>
        public override void DeleteByValue(int value)
        {
            if (!IsExistValue(value))
            {
                throw new ValueDoesNotExistException();
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
                throw new ValueDoesNotExistException();
            }

            base.DeleteByIndex(index);
        }
    }
}
