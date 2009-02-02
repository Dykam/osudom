using System;

namespace TreeCore
{
    public class NodeSplittedEventArgs : EventArgs
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
        /// <param name="originalParents"></param>
        /// <param name="reachedRemovedFromParentDepth"></param>
        public NodeSplittedEventArgs(INodeList originalParents)
        {
            m_originalParents = originalParents;
        }
    }
}
