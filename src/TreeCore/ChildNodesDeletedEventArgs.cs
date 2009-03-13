using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class ChildNodesDeletedEventArgs : EventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		private int m_reachedRemovedFromParentDepth;
		/// <summary>
		/// 
		/// </summary>
		public virtual int ReachedRemovedFromParentDepth
		{
			get { return m_reachedRemovedFromParentDepth; }
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reachedDeletedChildNodeDepth"></param>
		public ChildNodesDeletedEventArgs(int reachedDeletedChildNodeDepth)
		{
			m_reachedRemovedFromParentDepth = reachedDeletedChildNodeDepth;
		}
	}
}
