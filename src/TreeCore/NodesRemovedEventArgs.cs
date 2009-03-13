using System;
namespace TreeCore
{
    /// <summary>
    /// Eventargs used when nodes have been removed from a Node.
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class NodesRemovedEventArgs : EventArgs
	{
		/// <summary>
        /// The nodes which have been removed.
		/// </summary>
		private INodeList m_removedNodes;
		/// <summary>
        /// The nodes which have been removed.
		/// </summary>
		public virtual INodeList RemovedNodes
		{
			get { return m_removedNodes; }
		}
		/// <summary>
        /// Eventargs used when nodes have been removed from a Node.
		/// </summary>
        /// <param name="removedNodes">The nodes which have been removed.</param>
		public NodesRemovedEventArgs(INodeList removedNodes)
		{
			m_removedNodes = removedNodes;
		}
	}
}
