using System;
namespace TreeCore
{
    /// <summary>
    /// The main implementation of the INode. Used internally and for testing.
    /// A good INode to build your stuff on top of it.
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class Node : INode
	{
		#region INode Members
		
		#region NodeDeletedEventHandler NodeDeleted
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
		private event NodeDeletedEventHandler nodeDeleted;
		/// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object nodeDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
		public virtual event NodeDeletedEventHandler NodeDeleted
		{
			add
			{
				lock(nodeDeletedLock)
				{
					nodeDeleted += value;
				}
			}
			remove
			{
				lock(nodeDeletedLock)
				{
					nodeDeleted -= value;
				}
			}
		}
		/// <summary>
		/// Has to be called when this Node is deleted.
		/// </summary>
		/// <param name="e"></param>
		protected void OnNodeDeleted(NodeDeletedEventArgs e)
		{
			NodeDeletedEventHandler handler;
			lock (nodeDeletedLock)
			{
				handler = nodeDeleted;
			}
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion
		
		#region ChildNodesDeletedEventHandler ChildNodesDeleted
		/// <summary>
		/// Is called when this Nodes ChildNodes are deleted.
		/// </summary>
		private event ChildNodesDeletedEventHandler childNodesDeleted;
		/// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object childNodesDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
		public virtual event ChildNodesDeletedEventHandler ChildNodesDeleted
		{
			add
			{
				lock(childNodesDeletedLock)
				{
					childNodesDeleted += value;
				}
			}
			remove
			{
				lock(childNodesDeletedLock)
				{
					childNodesDeleted -= value;
				}
			}
		}
		/// <summary>
		/// Has to be called when this Node is deleted.
		/// </summary>
		/// <param name="e"></param>
		protected void OnChildNodesDeleted(ChildNodesDeletedEventArgs e)
		{
			ChildNodesDeletedEventHandler handler;
			lock (childNodesDeletedLock)
			{
				handler = childNodesDeleted;
			}
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion
		
		#region NodeSplittedEventHandler NodeSplitted
		/// <summary>
		/// Is called when this node is splitted from his parents.
		/// </summary>
		private event NodeSplittedEventHandler nodeSplitted;
		/// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object nodeSplittedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
		public virtual event NodeSplittedEventHandler NodeSplitted
		{
			add
			{
				lock(nodeSplittedLock)
				{
					nodeSplitted += value;
				}
			}
			remove
			{
				lock(nodeSplittedLock)
				{
					nodeSplitted -= value;
				}
			}
		}
		/// <summary>
		/// Has to be called when this Node is deleted.
		/// </summary>
		/// <param name="e"></param>
		protected void OnNodeSplitted(NodeSplittedEventArgs e)
		{
			NodeSplittedEventHandler handler;
			lock (nodeSplittedLock)
			{
				handler = nodeSplitted;
			}
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion

		#region ChildNodesSplittedEventHandler ChildNodesSplitted
		/// <summary>
		/// Is called when all child nodes have been split from their parents, and their only parent lead to this Node.
		/// </summary>
		private event ChildNodesSplittedEventHandler childNodesSplitted;
		/// <summary>
		/// Lock for ChildNodesSplitted delegate access.
		/// </summary>
		private readonly object childNodesSplittedLock = new object();
		/// <summary>
		/// Is called when all child nodes have been split from their parents, and their only parent lead to this Node.
		/// </summary>
		public virtual event ChildNodesSplittedEventHandler ChildNodesSplitted
		{
			add
			{
				lock (childNodesSplittedLock)
				{
					childNodesSplitted += value;
				}
			}
			remove
			{
				lock (childNodesSplittedLock)
				{
					childNodesSplitted -= value;
				}
			}
		}
		/// <summary>
		/// Has to be called when the child nodes have been splitted.
		/// </summary>
		/// <param name="e"></param>
		protected void OnChildNodesSplitted(ChildNodesSplittedEventArgs e)
		{
			ChildNodesSplittedEventHandler handler;
			lock (childNodesSplittedLock)
			{
				handler = childNodesSplitted;
			}
			if (handler != null)
			{
				handler(this, e);
			}
		}
		#endregion

        /// <summary>
        /// Parent Nodes.
        /// </summary>
		private LinkedNodeList parents;
        /// <summary>
        /// Parent Nodes.
        /// </summary>
		public virtual INodeList Parents
		{
			get
			{
				return parents;
			}
		}

        /// <summary>
        /// Child Nodes.
        /// </summary>
		private LinkedNodeList nodes;
        /// <summary>
        /// Child Nodes.
        /// </summary>
		public virtual INodeList Nodes
		{
			get
			{
				return nodes;
			}
		}
		
        /// <summary>
        /// Default contructor for Node.
        /// </summary>
		public Node()
		{
			parents = new LinkedNodeList();
			nodes = new LinkedNodeList();
		}

		/// <summary>
        /// Lets a Node to be garbage collected by removing all references to this Node.
		/// </summary>
		public virtual void Delete()
		{
			while (parents.Length != 0)
			{
				parents[0].Nodes.Remove(this);
				parents.Remove(parents[0]);
			}
			while (nodes.Length != 0)
			{
				nodes[0].Parents.Remove(this);
				nodes.Remove(nodes[0]);
			}
			OnNodeDeleted(new NodeDeletedEventArgs());
		}
        /// <summary>
        /// Completely removes all childNodes to a specified depth.
        /// </summary>
        /// <param name="depth">The depth the childNodes should be removed.</param>
        /// <returns>Reached depth.</returns>
		public virtual int DeleteChildNodes(int depth)
		{
			int reachedDepth = 0;
			while (nodes.Length != 0)
			{
				int localReachedDepth = nodes[0].DeleteChildNodes(depth - 1);
				if (localReachedDepth > reachedDepth)
					reachedDepth = localReachedDepth;
				nodes[0].Delete();
			}
			OnChildNodesDeleted(new ChildNodesDeletedEventArgs(reachedDepth));
			return ++reachedDepth;
		}

        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        /// <remarks>This function does not always have a loop-detection.</remarks>
        public virtual void Split()
		{
			NodeSplittedEventHandler handler;
			LinkedNodeList nodeList;
			lock (childNodesSplittedLock)
			{
				handler = nodeSplitted;
			}
			if (handler != null)
			{
				nodeList = new LinkedNodeList();
				nodeList.Add(parents);
				splitFromParents();
				OnNodeSplitted(new NodeSplittedEventArgs(parents));
			}
			else
				splitFromParents();
		}
		private void splitFromParents()
		{
			while (parents.Length != 0)
			{
				parents[0].Nodes.Remove(this);
				parents.Remove(parents[0]);
			}
        }
        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        /// <param name="depth">The depth for removing references from parents from ChildNodes. Time will increase exponentially.</param>
        /// <returns>Reached depth.</returns>
        public virtual int SplitChildNodes(int depth)
		{
			int reachedDepth = 0;
			while(nodes.Length != 0)
			{
				INode node = nodes[0];
				int localReachedDepth = node.SplitChildNodes(depth - 1);
				node.Split();
				node.Parents.Add(this);
				nodes.Add(node);
				if(localReachedDepth > reachedDepth)
					reachedDepth = localReachedDepth;
			}
			OnChildNodesSplitted(new ChildNodesSplittedEventArgs(reachedDepth));
			return ++reachedDepth;
		}

		#endregion
	}
}
