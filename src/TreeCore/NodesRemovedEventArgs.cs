using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    public class NodesRemovedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private INodeList m_removedNodes;
        /// <summary>
        /// 
        /// </summary>
        public INodeList RemovedNodes
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
