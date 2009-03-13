using System;
namespace TreeCore
{
    [Serializable]
    //[CLSCompliantAttribute(true)]
    internal class LinkedListNode<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private T m_value;
        /// <summary>
        /// 
        /// </summary>
        public virtual T Value
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
        public virtual void Append(LinkedListNode<T> linkedListNode)
        {
            Link(linkedListNode);
        }
        public virtual void Append(T value)
        {
            Link(new LinkedListNode<T>(value));
        }
        public virtual LinkedListNode<T> Jump(int offset)
        {
            LinkedListNode<T> result = this;
            if (offset > 0)
            {
                while (offset != 0)
                {
                    result = result.next;
                    offset--;
                }
            }
            else if (offset < 0)
            {
                while (offset != 0)
                {
                    result = result.previous;
                    offset++;
                }
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkedListNode"></param>
        /// <returns>The old link.</returns>
        public virtual LinkedListNode<T> Link(LinkedListNode<T> linkedListNode)
        {
            LinkedListNode<T> result = next;
            linkedListNode.previous.next = next;
            next.previous = linkedListNode.previous;
            linkedListNode.previous = this;
            next = linkedListNode;
            return result;
        }
        public virtual void Prepend(LinkedListNode<T> linkedListNode)
        {
            previous.Link(linkedListNode);
        }
        public virtual void Prepend(T value)
        {
            previous.Link(new LinkedListNode<T>(value));
        }
        /// <summary>
        /// Splits the LinkedList in two.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public virtual LinkedListNode<T> Split(int offset)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkedListNode"></param>
        public virtual void Switch(LinkedListNode<T> linkedListNode)
        {
            LinkedListNode<T> newNext = linkedListNode.next, newPrevious = linkedListNode.previous;
            linkedListNode.previous.next = this;
            linkedListNode.next.previous = this;
            this.previous.next = linkedListNode;
            this.next.previous = linkedListNode;
            linkedListNode.next = this.next;
            linkedListNode.previous = this.previous;
            this.next = newNext;
            this.previous = newPrevious;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The node next to the node taken out.</returns>
        public virtual LinkedListNode<T> TakeOut()
        {
            LinkedListNode<T> oldNext = next;
            next.previous = next;
            previous.next = previous;
            next = null;
            previous = null;
            return oldNext;
        }
        public virtual int Length
        {
            get
            {
                int lenght = 1;
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
        public virtual LinkedListNode<T> Next
        {
            get
            {
                return next;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual LinkedListNode<T> Previous
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

        public virtual LinkedListNode<T> this[int i]
        {
            get { return Jump(i); }
            set { Jump(i).Switch(value); }
        }
    }
}
