using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [CLSCompliantAttribute(true)]
    public class LinkedNodeList : INodeList
    {
        #region Nonstatic
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
        /// Is called when Nodes are added tho this NodeList
        /// </summary>
        private event NodesAddedEventHandler nodesAdded;
        /// <summary>
        /// Lock for NodeAdded delegate access.
        /// </summary>
        private readonly object nodesAddedLock = new object();
        /// <summary>
        /// Is called when Nodes are added tho this NodeList
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
        /// Returns true if the NodesAdded delegate contains listeners, else false.
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
        /// Returns true if the NodesRemoved delegate contains listeners, else false.
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
        /// Constructs a NodeList and adds a single Node into this new NodeList.
        /// </summary>
        /// <param name="node">The Node to be added.</param>
        public LinkedNodeList(INode node)
        {
            firstNode = new LinkedListNode<INode>(node);
        }
        /// <summary>
        /// Constructs a NodeList and adds multiple Nodes into this new NodeList.
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
        /// Adds a single Node into this NodeList.
        /// </summary>
        /// <param name="node">The Node to be added.</param>
        public virtual void Add(INode node)
        {
            if (initFirst(node))
            {
                firstNode.Prepend(node);
            }
        }

        /// <summary>
        /// Adds multiple Nodes into this NodeList.
        /// </summary>
        /// <param name="nodes">The Nodes to be added.</param>
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
        /// Inserts a node at a given position in targetList.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length, the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="node">Node to insert.</param>
        /// <returns>0-indexed position the Node is added.</returns>
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
        /// Inserts nodes at a given position.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="nodes">The NodeList to insert.</param>
        /// <returns>0-indexed position of the first Node added from nodes.</returns>
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
                    LinkedListNode<INode> backNode = firstNode[position];
                    for (int i = 0; i < nodes.Length; ++i)
                    {
                        backNode.Prepend(nodes[i]);
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
        /// Remove a single Node from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Node!</remarks>
        /// <param name="node">The Node to remove.</param>
        /// <returns>False if the Node was not in this NodeList.</returns>
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
        /// Remove multiple Nodes from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Nodes!</remarks>
        /// <param name="nodes">The Nodes to remove.</param>
        /// <returns>The number of Nodes which where in the NodeList.</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
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
        /// The Node at the specified index.
        /// </summary>
        /// <param name="index">The index to get the Node from.</param>
        /// <returns>The Node at the specified index.</returns>
        public virtual INode this[int index]
        {
            get
            {
                return firstNode.Jump(unchecked((int)index)).Value;
            }
        }

        /// <summary>
		/// The lenght of the NodeList
		/// </summary>
        public virtual int Length
        {
            get
            {
                return firstNode == null ? 0 : firstNode.Length;
            }
        }

        #endregion

        #region IEnumerable Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            yield return firstNode.Value;
            LinkedListNode<INode> currentNode = firstNode.Next;
            while (currentNode != firstNode)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #region IEnumerable<INode> Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.IEnumerator<INode> System.Collections.Generic.IEnumerable<INode>.GetEnumerator()
        {
            yield return firstNode.Value;
            LinkedListNode<INode> currentNode = firstNode.Next;
            while (currentNode != firstNode)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #endregion

        #region Static
        #region Implicit conversion operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static explicit operator LinkedNodeList(INode[] value)
        {
            return new LinkedNodeList();
        }
        #endregion
        #endregion
    }
}
