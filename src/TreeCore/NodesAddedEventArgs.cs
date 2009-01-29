using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    class NodesAddedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private INodeList m_addedNodes;
        /// <summary>
        /// 
        /// </summary>
        public INodeList AddedNodes
        {
            get { return m_addedNodes; }
        }

        /// <summary>
        /// 
        /// </summary>
        private uint m_firstAddedNodeIndex;
        /// <summary>
        /// 
        /// </summary>
        public uint FirstAddedNodeIndex
        {
            get { return m_firstAddedNodeIndex; }
        }

        /// <summary>
        /// 
        /// </summary>
        public NodesAddedEventArgs(INodeList addedNodes, uint firstAddedNodeIndex)
        {

        }
    }
}
