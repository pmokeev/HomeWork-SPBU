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
            if (Contains(value))
            {
                throw new ValueIsAlreadyInsertedException("Error! Value is already inserted");
            }

            base.Insert(value, index);
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
            else if (Contains(value) && index != GetIndexByValue(value))
            {
                throw new ValueIsAlreadyInsertedException("Error! Value is already inserted");
            }

            base.SetValueByIndex(value, index);
        }
    }
}