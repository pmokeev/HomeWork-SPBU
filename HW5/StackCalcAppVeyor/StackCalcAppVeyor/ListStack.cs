using System;

namespace StackCalcAppVeyor
{
    /// <summary>
    /// A class that implements a stack on an list
    /// </summary>
    public class ListStack : IStack
    {
        private class Node
        {
            public float element;
            public Node nextNode;

            public Node(float element, Node nextNode)
            {
                this.element = element;
                this.nextNode = nextNode;
            }
        }

        private Node head;

        /// <summary>
        /// Push element in stack
        /// </summary>
        public void Push(float element)
            => head = new Node(element, head);

        /// <summary>
        /// Pop element from stack
        /// </summary>
        public float Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var popElement = head.element;
            head = head.nextNode;
            return popElement;
        }

        /// <summary>
        /// Checking the stack for emptiness
        /// </summary>
        public bool IsEmpty()
            => head == null;
    }
}
