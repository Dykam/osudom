using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    class NodeSplittedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private INodeList _exParents;
        public INodeList ExParents
        {
            get { return _exParents; }
        }
        /// <summary>
        /// 
        /// </summary>
        private INode _discoveredParent;
        public INode DiscoveredParent
        {
            get { return _discoveredParent; }
        }
        /// <summary>
        /// 
        /// </summary>
        private INode _node;
        public INode Node
        {
            get { return _node; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="exParents"></param>
        /// <param name="discoveredParent"></param>
        public NodeSplittedEventArgs(INode node, NodeList exParents, INode discoveredParent)
        {
            _node = node;
            _exParents = exParents;
            _discoveredParent = discoveredParent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="exParents"></param>
        public NodeSplittedEventArgs(INode node, NodeList exParents)
        {
            _node = node;
            _exParents = exParents;
            _discoveredParent = null;
        }
    }
}