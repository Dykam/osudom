using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    public class ChildNodesSplittedEventArgs : EventArgs
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
        public ChildNodesSplittedEventArgs(uint reachedRemovedFromParentDepth)
        {
            m_reachedRemovedFromParentDepth = reachedRemovedFromParentDepth;
        }
    }
}
