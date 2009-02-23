using System;
namespace TreeCore
{
    /// <summary>
    /// Eventargs used when a Node has been split from his parents
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class NodeSplittedEventArgs : EventArgs
	{
		/// <summary>
		/// The parents before the splitting event.
		/// </summary>
		private INodeList m_originalParents;
		/// <summary>
        /// The parents before the splitting event.
		/// </summary>
		public virtual INodeList OriginalParents
		{
			get { return m_originalParents; }
		}
		/// <summary>
        /// Eventargs used when a Node is splitted from his parents
		/// </summary>
        /// <param name="originalParents">The parents before the splitting event.</param>
		public NodeSplittedEventArgs(INodeList originalParents)
		{
			m_originalParents = originalParents;
		}
	}
}
