using System;

namespace StackCalc
{
    /// <summary>
    /// A class that implements a stack on an array
    /// </summary>
    public class ArrayStack : IStack
    {
        private float[] stackArray = new float[2];
        private int currentIndex = 0;

        /// <summary>
        /// Push element in stack
        /// </summary>
        public void Push(float element)
        {
            if (stackArray.Length <= currentIndex)
            {
                Array.Resize(ref stackArray, stackArray.Length * 2);
            }

            stackArray[currentIndex] = element;
            currentIndex++;
        }

        /// <summary>
        /// Pop element from stack
        /// </summary>
        public float Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            if (currentIndex >= 1)
            {
                currentIndex--;
            }

            var popElement = stackArray[currentIndex];
            return popElement;
        }

        /// <summary>
        /// Checking the stack for emptiness
        /// </summary>
        public bool IsEmpty()
            => currentIndex == 0;
    }
}