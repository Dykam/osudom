using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    internal class LinkedListNode
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
    		}
    		
    		public void insertAfter(LinkedListNode linkedListNode)
    		{
    			linkedListNode.previous = this;
    			linkedListNode.next = next;
    			next.previous =  linkedListNode;
    			next = linkedListNode;
    		}
    		public void insertBefore(LinkedListNode linkedListNode)
    		{
    			linkedListNode.next = this;
    			linkedListNode.previous = next;
    			previous.next =  linkedListNode;
    			previous = linkedListNode;
    		}
    		public void takeOut()
    		{
    			next.previous = previous;
    			previous.next = next;
    			this.next = null;
    			this.previous = null;
    		}
    }
}
