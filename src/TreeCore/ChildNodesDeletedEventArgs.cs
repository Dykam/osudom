using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    public class ChildNodesDeletedEventArgs : EventArgs
    {
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
        /// <param name="reachedDeletedChildNodeDepth"></param>
        public ChildNodesDeletedEventArgs(uint reachedDeletedChildNodeDepth)
        {

        }
    }
}
