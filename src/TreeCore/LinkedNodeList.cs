using System;
namespace TreeCore
{
    [Serializable]
    [CLSCompliantAttribute(true)]
    public class LinkedNodeList : INodeList
    {
        private LinkedListNode<INode> firstNode;

        private bool initFirst(INode node)
        {
            if (firstNode == null)
            {
                firstNode = new LinkedListNode<INode>(node);
                return false;
            }
            return true;
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
        public virtual event NodesAddedEventHandler NodesAdded
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
        public virtual event NodesRemovedEventHandler NodesRemoved
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
        public LinkedNodeList()
        {

        }
        /// <summary>
        /// Adds a single Node into this new NodeList.
        /// </summary>
        /// <param name="node">The Node to be added.</param>
        public LinkedNodeList(INode node)
        {
            firstNode = new LinkedListNode<INode>(node);
        }
        /// <summary>
        /// Adds multiple Nodes into this new NodeList.
        /// </summary>
        /// <param name="nodes">The Nodes to be added.</param>
        public LinkedNodeList(INodeList nodes)
        {
            firstNode = new LinkedListNode<INode>(nodes[0]);
            for (int i = 1; i < nodes.Length; i++)
            {
                firstNode.Prepend(nodes[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public virtual void Add(INode node)
        {
            if (initFirst(node))
            {
                firstNode.Prepend(node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public virtual void Add(INodeList nodes)
        {
            if (initFirst(nodes[0]))
            {
                firstNode.Prepend(nodes[0]);
            }
            for (int i = 1; i < nodes.Length; i++)
            {
                firstNode.Prepend(nodes[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual int InsertAt(int position, INode node)
        {
            if (initFirst(node))
            {
                if (position == 0)
                {
                    firstNode.Prepend(node);
                    firstNode = firstNode.Previous;
                }
                else if (position > firstNode.Length)
                {
                    firstNode.Prepend(node);
                    return firstNode.Length - 1;
                }
                else
                {
                    firstNode[position].Prepend(node);
                    return position;
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public virtual int InsertAt(int position, INodeList nodes)
        {
            if (initFirst(nodes[0]))
            {
                if (position == 0)
                {
                    firstNode.Prepend(nodes[0]);
                    firstNode = firstNode.Previous;
                    for (int i = 1; i < nodes.Length; ++i)
                    {
                        firstNode.Append(nodes[i]);
                    }
                }
                else if (position > firstNode.Length)
                {
                    for (int i = nodes.Length - 1; i >= 0; --i)
                    {
                        firstNode.Prepend(nodes[i]);
                    }
                    return firstNode.Length - 1;
                }
                else
                {
                    LinkedListNode<INode> nextNode = firstNode[position - 1];
                    for (int i = nodes.Length - 1; i >= 0; --i)
                    {
                        firstNode[position].Append(nodes[i]);
                    }
                    return position;
                }
            }
            for (int i = 1; i < nodes.Length; ++i)
            {
                firstNode.Append(nodes[i]);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual bool Remove(INode node)
        {
            bool didExcist = false;
            LinkedListNode<INode> currentNode = firstNode.Next;
            {
                while (currentNode != firstNode)
                {
                    if (currentNode.Value == node)
                    {
                        currentNode = currentNode.TakeOut();
                        didExcist = true;
                    }
                    else
                        currentNode = currentNode.Next;
                }
            }
            if (removeFirst(node))
                didExcist = true;
            return didExcist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public virtual int Remove(INodeList nodes)
        {
            int didExcist = 0;
            LinkedListNode<INode> currentNode = firstNode.Next;
            {
                while (currentNode != firstNode)
                {
                    if (nodes.Contains(currentNode.Value))
                    {
                        currentNode = currentNode.TakeOut();
                        didExcist++;
                    }
                    else
                        currentNode = currentNode.Next;
                }
            }
            if (removeFirst(nodes))
                didExcist++;
            return didExcist;
        }
        /// <summary>
        /// Checks if a Node exists in the NodeList
        /// </summary>
        /// <param name="node">The Node to check for.</param>
        /// <returns>True if the Node does exist in the NodeList.</returns>
        public virtual bool Contains(INode node)
        {
#if THREADSAFE
			int i = 0;
			while(this.Length - i >= 0)
			{
				if (this[nodes.Length - i] == node)
					return true;
			}
			return false;
#else
            for (int i = 0; i < this.Length; i++)
                if (this[i] == node)
                    return true;
            return false;
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool removeFirst(INode node)
        {

            if (firstNode.Value == node)
            {
                firstNode = firstNode.TakeOut();
                return true;
            }
            return false;
        }
        private bool removeFirst(INodeList nodes)
        {

            if (nodes.Contains(firstNode.Value))
            {
                firstNode = firstNode.TakeOut();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual INode this[int index]
        {

            get
            {
                return firstNode.Jump(unchecked((int)index)).Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Length
        {
            get
            {
                return firstNode == null ? 0 : firstNode.Length;
            }
        }

        #endregion
    }
}
