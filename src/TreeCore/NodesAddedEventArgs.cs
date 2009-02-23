using System;
namespace TreeCore
{
    /// <summary>
    /// Eventargs used when nodes has been added to a Node.
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class NodesAddedEventArgs : EventArgs
	{
		/// <summary>
		/// The nodes which have been added.
		/// </summary>
		private INodeList m_addedNodes;
		/// <summary>
        /// The nodes which have been added.
		/// </summary>
		public virtual INodeList AddedNodes
		{
			get { return m_addedNodes; }
		}

		/// <summary>
		/// The index of the first Node added.
		/// </summary>
		private int m_firstAddedNodeIndex;
		/// <summary>
        /// The index of the first Node added.
		/// </summary>
		public virtual int FirstAddedNodeIndex
		{
			get { return m_firstAddedNodeIndex; }
		}

		/// <summary>
        /// Eventargs used when nodes has been added to a Node.
		/// </summary>
        /// <param name="addedNodes">The nodes which have been added.</param>
        /// <param name="firstAddedNodeIndex">The index of the first Node added.</param>
		public NodesAddedEventArgs(INodeList addedNodes, int firstAddedNodeIndex)
		{
			m_addedNodes = addedNodes;
			m_firstAddedNodeIndex = firstAddedNodeIndex;
		}
	}
}
