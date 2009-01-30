using System;
namespace TreeCore
{
    public abstract class AbstractNodeList : INodeList // Done
    {
        #region internalMembers
        /// <summary>
        /// Adds a single Node into this NodeList.
        /// </summary>
        /// <param name="node">The Node to be added.</param>
        abstract protected void internalAdd(INode node);
        /// <summary>
        /// Adds multiple Nodes into this NodeList.
        /// </summary>
        /// <param name="nodes">The Nodes to be added.</param>
        abstract protected void internalAdd(INodeList nodes);
        /// <summary>
        /// Inserts a node at a given position in targetList.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length, the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="node">Node to insert.</param>
        /// <returns>0-indexed position the Node is added.</returns>
        abstract protected uint internalInsertAt(int position, INode node);
        /// <summary>
        /// Inserts nodes at a given position.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="nodeList">The NodeList to insert.</param>
        /// <returns>0-indexed position of the first Node added from nodes.</returns>
        abstract protected uint internalInsertAt(int position, INodeList nodes);
        /// <summary>
        /// Remove a single Node from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Node!</remarks>
        /// <param name="node">The Node to remove.</param>
        /// <returns>Returns false if the Node was not in this NodeList.</returns>
        abstract protected bool internalRemove(INode node);
        /// <summary>
        /// Remove multiple Nodes from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Nodes!</remarks>
        /// <param name="nodes">The Nodes to remove.</param>
        /// <returns>The Nodes which were in the NodeList.</returns>
        abstract protected INodeList internalRemove(INodeList node);
        /// <summary>
        /// Checks for and removes doubles.
        /// </summary>
        abstract protected void internalCleanUp();
        /// <summary>
        /// Returns a Node from the specified index.
        /// </summary>
        /// <param name="index">The index to get the Node from.</param>
        /// <returns>A Node from the specified index.</returns>
        abstract protected INode internalGetInode(uint index);
        /// <summary>
        /// Sets a Node at the specified index.
        /// </summary>
        /// <param name="index">The index of the Node to set.</param>
        abstract protected void internalSetInode(uint index, INode node);
        /// <summary>
        /// 
        /// </summary>
        abstract protected uint internalLenght { get; }
        #endregion


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
        #endregion

        #region CleanedUpEventHandler CleanedUp
        /// <summary>
        /// 
        /// </summary>
        private event CleanedUpEventHandler cleanedUp;
        /// <summary>
        /// Lock for CleanedUp delegate access.
        /// </summary>
        private readonly object cleanedUpLock = new object();
        /// <summary>
        /// 
        /// </summary>
        public event CleanedUpEventHandler CleanedUp
        {
            add
            {
                lock (cleanedUpLock)
                {
                    cleanedUp += value;
                }
            }
            remove
            {
                lock (cleanedUpLock)
                {
                    cleanedUp -= value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnCleanedUp(CleanedUpEventArgs e)
        {
            CleanedUpEventHandler handler;
            lock (cleanedUpLock)
            {
                handler = cleanedUp;
            }
            if (handler != null)
            {
                handler(this, e);
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
        #endregion

        public void Add(INode node)
        {
            internalAdd(node);
            NodeList nodeList = new NodeList();
            nodeList.Add(node);
            OnNodesAdded(new NodesAddedEventArgs(nodeList, Length));
        }

        public void Add(INodeList nodes)
        {
            internalAdd(nodes);
            OnNodesAdded(new NodesAddedEventArgs(nodes, Length - nodes.Length));
        }

        public uint InsertAt(int position, INode node)
        {
            uint insertedPos = internalInsertAt(position, node);
            NodeList nodeList = new NodeList();
            nodeList.Add(node);
            OnNodesAdded(new NodesAddedEventArgs(nodeList, insertedPos));
            return insertedPos;
        }

        public uint InsertAt(int position, INodeList nodes)
        {
            uint insertedPos = internalInsertAt(position, nodes);
            OnNodesAdded(new NodesAddedEventArgs(nodes, insertedPos));
            return insertedPos;
        }

        public bool Remove(INode node)
        {
            bool wasInList= internalRemove(node);
            if (wasInList)
            {
                NodeList nodeList = new NodeList();
                nodeList.Add(node);
                OnNodesRemoved(new NodesRemovedEventArgs(nodeList));
            }
            return wasInList;
        }

        public uint Remove(INodeList nodes)
        {
            INodeList wereInList = internalRemove(nodes);
            if (wereInList.Length != 0)
            {
                OnNodesRemoved(new NodesRemovedEventArgs(wereInList));
            }
            return nodes.Length - wereInList.Length;
        }

        public void CleanUp()
        {
            internalCleanUp();
            OnCleanedUp(new CleanedUpEventArgs());
        }

        public INode this[uint index]
        {
            get
            {
                return internalGetInode(index);
            }
        }

        public uint Length
        {
            get { return internalLenght; }
        }

        #endregion
    }
}
