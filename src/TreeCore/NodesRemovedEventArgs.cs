using System;
namespace TreeCore
{
	[Serializable]
	public class NodesRemovedEventArgs : EventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		private INodeList m_removedNodes;
		/// <summary>
		/// 
		/// </summary>
		public virtual INodeList RemovedNodes
		{
			get { return m_removedNodes; }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="removedNodes"></param>
		public NodesRemovedEventArgs(INodeList removedNodes)
		{
			m_removedNodes = removedNodes;
		}
	}
}
