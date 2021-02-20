using System;

namespace StackCalc
{
    class ListStack : IStack
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

        public void Push(float element)
            => head = new Node(element, head);

        public float Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            var popElement = head.element;
            head = head.nextNode;
            return popElement;
        }

        public bool IsEmpty()
            => head == null;
    }
}