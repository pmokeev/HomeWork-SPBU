using System;

namespace StackCalc
{
    interface IStack
    {
        void Push(float element);
        
        float Pop();

        bool IsEmpty();
    }
}
