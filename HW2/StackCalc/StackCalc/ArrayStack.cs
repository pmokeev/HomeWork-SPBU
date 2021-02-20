using System;
using System.Collections.Generic;
using System.Text;

namespace StackCalc
{
    class ArrayStack : IStack
    {
        private float[] stackArray = new float[0];

        public void Push(float element)
        {
            Array.Resize(ref stackArray, stackArray.Length + 1);
            stackArray[stackArray.Length - 1] = element;
        }

        public float Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            var popElement = stackArray[stackArray.Length - 1];
            Array.Resize(ref stackArray, stackArray.Length - 1);
            return popElement;
        }

        public bool IsEmpty()
            => stackArray.Length == 0;
    }
}
