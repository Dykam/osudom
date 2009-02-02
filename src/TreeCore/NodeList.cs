using System;
namespace TreeCore
{
    public class NodeList : INodeList
    {       	
        private LinkedListNode firstLinkedListNode;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Returns true if firstLinkedListNode was not null.</returns>
        private bool firstNode(INode node)
        {
        	firstLinkedListNode = firstLinkedListNode ?? new LinkedListNode(node);
        	return firstLinkedListNode.Node != node;
        }
    	
        #region INodeList Members
        
        #region NodesAddedEventHandler NodesAdded
        /// <summary>
        /// 
        /// </summary>
        private event NodesAddedEventHandler nodesAdded;
        /// <summary>
        /// 
        /// </summary>
        private readonly object nodesAddedLock = new object();
        /// <summary>
        /// 
        /// </summary>
        public event NodesAddedEventHandler NodesAdded
        {
            add
            {
                lock (nodesAddedLock)
                {
                    nodesAdded += value;
                }
            }
            remove
            {
                lock (nodesAddedLock)
                {
                    nodesAdded -= value;
                }
            }
        }
        /// <summary>
        /// Has to be called when this Node is deleted.
        /// </summary>
        /// <param name="e"></param>
        protected void OnNodesAdded(NodesAddedEventArgs e)
        {
            NodesAddedEventHandler handler;
            lock (nodesAddedLock)
            {
                handler = nodesAdded;
            }
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected bool NodesAddeddHasCallers
        {
        	get
        	{
        		lock (nodesAddedLock)
	            {
                    return nodesAdded != null;
	            }
        	}
        }
        #endregion
        
        #region NodesRemovedEventHandler NodesRemoved
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        private event NodesRemovedEventHandler nodesRemoved;
        /// <summary>
        /// Lock for NodeDeleted delegate access.
        /// </summary>
        private readonly object nodesRemovedLock = new object();
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        public event NodesRemovedEventHandler NodesRemoved
        {
            add
            {
                lock (nodesRemovedLock)
                {
                    nodesRemoved += value;
                }
            }
            remove
            {
                lock (nodesRemovedLock)
                {
                    nodesRemoved -= value;
                }
            }
        }
        /// <summary>
        /// Has to be called when this Node is deleted.
        /// </summary>
        /// <param name="e"></param>
        protected void OnNodesRemoved(NodesRemovedEventArgs e)
        {
            NodesRemovedEventHandler handler;
            lock (nodesRemovedLock)
            {
                handler = nodesRemoved;
            }
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected bool NodesRemovedHasCallers
        {
        	get
        	{
        		lock (nodesRemovedLock)
	            {
	                return nodesRemoved != null;
	            }
        	}
        }
        #endregion

        /// <summary>
        /// Constructs a NodeList.
        /// </summary>
        public NodeList()
        {

        }
        /// <summary>
        /// Adds a single Node into this new NodeList.
        /// </summary>
        /// <param name="node">The Node to be added.</param>
        public NodeList(INode node)
        {
        	if(firstNode(node))
	        	firstLinkedListNode.insertBefore(new LinkedListNode(node));
        }
        /// <summary>
        /// Adds multiple Nodes into this new NodeList.
        /// </summary>
        /// <param name="nodes">The Nodes to be added.</param>
        public NodeList(INodeList nodes)
        {
        	uint i = 0;
        	if(firstNode(nodes[0]))
        		i++;
        	while(i < nodes.Length)
        	{
        		firstLinkedListNode.insertBefore(new LinkedListNode(nodes[i]));
                i++;
        	}
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void Add(INode node)
        {
            if(firstNode(node))
	        	firstLinkedListNode.insertBefore(new LinkedListNode(node));
            if(NodesAddeddHasCallers)
            {
            	OnNodesAdded(new NodesAddedEventArgs(new NodeList(node), Length));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public void Add(INodeList nodes)
        {
        	lock(nodes)
        	{
        		uint i = 0;
        		if(firstNode(nodes[0]))
	        		i++;
	        	while(i < nodes.Length)
	        	{
	        		firstLinkedListNode.insertBefore(new LinkedListNode(nodes[i]));
                    i++;
	        	}
	        	if(NodesAddeddHasCallers)
	            {
	        		OnNodesAdded(new NodesAddedEventArgs(new NodeList(nodes), Length - nodes.Length));
	            }
        	}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public uint InsertAt(int position, INode node)
        {
            uint insertedAt = (uint)position % Length;
        	if(!firstNode(node))
        	{
	            LinkedListNode currentLinkedListNode = firstLinkedListNode;
                if (position > 0)
	            {
		            while(position != 0)
		            {
		            	currentLinkedListNode = currentLinkedListNode.Next;
		            	position--;
		            }
	            }
	            else if (position < 0)
	            {
	            	while(position != 0)
		            {
		            	currentLinkedListNode = currentLinkedListNode.Previous;
		            	position++;
		            }
	            }
	            currentLinkedListNode.insertBefore(new LinkedListNode(node));
        	}
        	if(NodesAddeddHasCallers)
            {
        		OnNodesAdded(new NodesAddedEventArgs(new NodeList(node), insertedAt));
            }
            return insertedAt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public uint InsertAt(int position, INodeList nodes)
        {
            throw new NotImplementedException();
            uint insertedAt = (uint)position % Length;
            LinkedListNode currentLinkedListNode = firstLinkedListNode;
            if (position > 0)
            {
	            while(position != 0)
	            {
	            	currentLinkedListNode = currentLinkedListNode.Next;
	            	position--;
	            }
            }
            else if (position < 0)
            {
            	while(position != 0)
	            {
	            	currentLinkedListNode = currentLinkedListNode.Previous;
	            	position++;
	            }
            }
            for(uint i = 0; i < nodes.Length; i++)
        	{
        		firstLinkedListNode.insertBefore(new LinkedListNode(nodes[i]));
        	}
        	if(NodesAddeddHasCallers)
            {
        		OnNodesAdded(new NodesAddedEventArgs(new NodeList(nodes), insertedAt));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Remove(INode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public uint Remove(INodeList nodes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public INode this[uint index]
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public uint Length
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
