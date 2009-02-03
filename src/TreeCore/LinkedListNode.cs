using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    public class LinkedListNode
    {
		protected LinkedListNode previous, next;
		
		public INode Node;
		
		public LinkedListNode Next {
			get { return next; }
		}
		
		public LinkedListNode Previous {
			get { return previous; }
		}
		
		public LinkedListNode(INode node)
		{
			Node = node;
			this.next = this;
			this.previous = this;
		}
		
		public void Append(LinkedListNode linkedListNode)
		{
			linkedListNode.previous = this;
			linkedListNode.next = next;
			next.previous =  linkedListNode;
			next = linkedListNode;
		}
		public uint Lenght
		{
			get
			{
				uint pos = 1;
				LinkedListNode currentLinkedListNode = this.next;
				while(currentLinkedListNode != this)
				{
					pos++;
					currentLinkedListNode = currentLinkedListNode.next;
				}
				return pos;
			}
		}
		public void Prepend(LinkedListNode linkedListNode)
		{
			linkedListNode.next = this;
			linkedListNode.previous = next;
			previous.next =  linkedListNode;
			previous = linkedListNode;
		}
		public void TakeOut()
		{
			next.previous = previous;
			previous.next = next;
			this.next = null;
			this.previous = null;
		}
    }
}
