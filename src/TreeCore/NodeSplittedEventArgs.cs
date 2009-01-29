using System;

namespace TreeCore
{
    class NodeSplittedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private INodeList m_originalParents;
        /// <summary>
        /// 
        /// </summary>
        public INodeList OriginalParents
        {
            get { return m_originalParents; }
        }
        /// <summary>
        /// 
        /// </summary>
        private uint m_reachedRemovedFromParentDepth;
        /// <summary>
        /// 
        /// </summary>
        public uint ReachedRemovedFromParentDepth
        {
            get { return m_reachedRemovedFromParentDepth; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalParents"></param>
        /// <param name="reachedRemovedFromParentDepth"></param>
        public NodeSplittedEventArgs(INodeList originalParents, uint reachedRemovedFromParentDepth)
        {
            m_originalParents = originalParents;
            m_reachedRemovedFromParentDepth = reachedRemovedFromParentDepth;
        }
    }
}
