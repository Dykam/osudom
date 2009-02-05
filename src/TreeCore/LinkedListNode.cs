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
        private LinkedListNode<T> next, previous;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            next = this;
            previous = this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkedListNode">The node to connect to.</param>
        public void Append(LinkedListNode<T> linkedListNode)
        {
            throw new NotImplementedException();

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
            LinkedListNode<T> result = this.next;
            linkedListNode.previous.next = next;
            next.previous = linkedListNode.previous;
            linkedListNode.previous = this;
            next = linkedListNode;
            return result;
        }
        public void Prepend(LinkedListNode<T> linkedListNode)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Splits the LinkedList in two.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public LinkedListNode<T> Split(int offset)
        {
            throw new NotImplementedException();
        }

        public uint Lenght
        {
            get
            {
                throw new NotImplementedException();
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
    }
}
