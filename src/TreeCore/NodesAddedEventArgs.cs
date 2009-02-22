using System;
namespace TreeCore
{
	[Serializable]
	public class NodesAddedEventArgs : EventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		private INodeList m_addedNodes;
		/// <summary>
		/// 
		/// </summary>
		public virtual INodeList AddedNodes
		{
			get { return m_addedNodes; }
		}

		/// <summary>
		/// 
		/// </summary>
		private int m_firstAddedNodeIndex;
		/// <summary>
		/// 
		/// </summary>
		public virtual int FirstAddedNodeIndex
		{
			get { return m_firstAddedNodeIndex; }
		}

		/// <summary>
		/// 
		/// </summary>
		public NodesAddedEventArgs(INodeList addedNodes, int firstAddedNodeIndex)
		{
			m_addedNodes = addedNodes;
			m_firstAddedNodeIndex = firstAddedNodeIndex;
		}
	}
}
