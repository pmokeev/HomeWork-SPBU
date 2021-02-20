using System;
using System.Collections.Generic;
using System.Text;

namespace StackCalc
{
    interface IStack
    {
        void Push(float element);
        
        float Pop();

        bool IsEmpty();
    }
}
