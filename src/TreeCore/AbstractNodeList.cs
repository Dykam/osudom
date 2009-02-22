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
		protected abstract void internalAdd(INode node);
		/// <summary>
		/// Adds multiple Nodes into this NodeList.
		/// </summary>
		/// <param name="nodes">The Nodes to be added.</param>
		protected abstract void internalAdd(INodeList nodes);
		/// <summary>
		/// Checks if a Node exists in the NodeList
		/// </summary>
		/// <param name="node">The Node to check for.</param>
		/// <returns>True if the Node does exist in the NodeList.</returns>
		protected abstract bool internalContains(INode node);
		/// <summary>
		/// Inserts a node at a given position in targetList.
		/// </summary>
		/// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length, the Node is added to the end. Position is 0-indexed.</param>
		/// <param name="node">Node to insert.</param>
		/// <returns>0-indexed position the Node is added.</returns>
		protected abstract int internalInsertAt(int position, INode node);
		/// <summary>
		/// Inserts nodes at a given position.
		/// </summary>
		/// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
		/// <param name="nodeList">The NodeList to insert.</param>
		/// <returns>0-indexed position of the first Node added from nodes.</returns>
		protected abstract int internalInsertAt(int position, INodeList nodes);
		/// <summary>
		/// Remove a single Node from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Node!</remarks>
		/// <param name="node">The Node to remove.</param>
		/// <returns>Returns false if the Node was not in this NodeList.</returns>
		protected abstract bool internalRemove(INode node);
		/// <summary>
		/// Remove multiple Nodes from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Nodes!</remarks>
		/// <param name="nodes">The Nodes to remove.</param>
		/// <returns>The Nodes which were in the NodeList.</returns>
		protected abstract INodeList internalRemove(INodeList node);
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
		#endregion

		public virtual void Add(INode node)
		{
			internalAdd(node);
			LinkedNodeList nodeList = new LinkedNodeList();
			nodeList.Add(node);
			OnNodesAdded(new NodesAddedEventArgs(nodeList, Length));
		}

		public virtual void Add(INodeList nodes)
		{
			internalAdd(nodes);
			OnNodesAdded(new NodesAddedEventArgs(nodes, Length - nodes.Length));
		}
		/// <summary>
		/// Checks if a Node exists in the NodeList
		/// </summary>
		/// <param name="node">The Node to check for.</param>
		/// <returns>True if the Node does exist in the NodeList.</returns>
		public virtual bool Contains(INode node)
		{
			return internalContains(node);
		}
		public virtual int InsertAt(int position, INode node)
		{
			int insertedPos = internalInsertAt(position, node);
			LinkedNodeList nodeList = new LinkedNodeList();
			nodeList.Add(node);
			OnNodesAdded(new NodesAddedEventArgs(nodeList, insertedPos));
			return insertedPos;
		}

		public virtual int InsertAt(int position, INodeList nodes)
		{
			int insertedPos = internalInsertAt(position, nodes);
			OnNodesAdded(new NodesAddedEventArgs(nodes, insertedPos));
			return insertedPos;
		}

		public virtual bool Remove(INode node)
		{
			bool wasInList= internalRemove(node);
			if (wasInList)
			{
				LinkedNodeList nodeList = new LinkedNodeList();
				nodeList.Add(node);
				OnNodesRemoved(new NodesRemovedEventArgs(nodeList));
			}
			return wasInList;
		}

		public virtual int Remove(INodeList nodes)
		{
			INodeList wereInList = internalRemove(nodes);
			if (wereInList.Length != 0)
			{
				OnNodesRemoved(new NodesRemovedEventArgs(wereInList));
			}
			return nodes.Length - wereInList.Length;
		}

		public abstract INode this[int index]
		{
			get;
		}

		public abstract int Length
		{
			get;
		}

		#endregion
	}
}
