using System;
namespace TreeCore
{
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
		public ChildNodesSplittedEventArgs(int reachedRemovedFromParentDepth)
		{
			m_reachedRemovedFromParentDepth = reachedRemovedFromParentDepth;
		}
	}
}
