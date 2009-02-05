using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private T m_value;
        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get { return m_value; }
            set { m_value = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private LinkedListNode<T> next, previous;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            next = this;
            previous = this;
            m_value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkedListNode">The node to connect to.</param>
        public void Append(LinkedListNode<T> linkedListNode)
        {
            Link(linkedListNode);
        }
        public LinkedListNode<T> Jump(int offset)
        {
            LinkedListNode<T> result = this;
            if (offset > 0)
                while (offset != 0)
                {
                    result = result.next;
                    offset--;
                }
            else if (offset < 0)
                while (offset != 0)
                {
                    result = result.previous;
                    offset++;
                }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkedListNode"></param>
        /// <returns>The old link.</returns>
        public LinkedListNode<T> Link(LinkedListNode<T> linkedListNode)
        {
            LinkedListNode<T> result = next;
            linkedListNode.previous.next = next;
            next.previous = linkedListNode.previous;
            linkedListNode.previous = this;
            next = linkedListNode;
            return result;
        }
        public void Prepend(LinkedListNode<T> linkedListNode)
        {
            linkedListNode.Link(this);
        }
        /// <summary>
        /// Splits the LinkedList in two.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public LinkedListNode<T> Split(int offset)
        {
            LinkedListNode<T> splitoffset = this;
            if (offset > 0)
            {
                while (offset != 0)
                {
                    splitoffset = splitoffset.next;
                    offset--;
                }
                return splitoffset.Link(this);
            }
            else if (offset < 0)
            {
                while (offset != 0)
                {
                    splitoffset = splitoffset.previous;
                    offset++;
                }
                return Link(splitoffset);
            }
            return Link(this);
        }

        public uint Lenght
        {
            get
            {
                uint lenght = 1;
                LinkedListNode<T> current = next;
                while (current != this)
                {
                    current = current.next;
                    lenght++;
                }
                return lenght;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<T> Next
        {
            get
            {
                return next;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<T> Previous
        {
            get
            {
                return previous;
            }
        }

        public override string ToString()
        {
            return m_value.ToString();
        }
    }
}
