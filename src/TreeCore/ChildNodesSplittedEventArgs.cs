using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
	[Serializable][CLSCompliantAttribute(true)]
	public class ChildNodesSplittedEventArgs : EventArgs
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
        /// <param name="reachedRemovedFromParentDepth"></param>
		public ChildNodesSplittedEventArgs(int reachedRemovedFromParentDepth)
		{
			m_reachedRemovedFromParentDepth = reachedRemovedFromParentDepth;
		}
	}
}
