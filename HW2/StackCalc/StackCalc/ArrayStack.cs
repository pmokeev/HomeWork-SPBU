using System;

namespace StackCalc
{
    class ArrayStack : IStack
    {
        private float[] stackArray = new float[2];
        private int currentIndex = 0;

        public void Push(float element)
        {
            if (stackArray.Length <= currentIndex)
            {
                Array.Resize(ref stackArray, stackArray.Length * 2);
            }

            stackArray[currentIndex++] = element;
        }

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

        public bool IsEmpty()
            => currentIndex == 0;
    }
}