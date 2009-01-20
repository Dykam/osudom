using System;
namespace TreeCore
{
    class ChildNodesRemovedEventArgs
    {
        private INodeList _removedNodes;

        public INodeList RemovedNodes
        {
            get { return _removedNodes; }
        }
        private int _reachedDepth;

        public int ReachedDepth
        {
            get { return reachedDepth; }
        }
        public ChildNodesRemovedEventArgs(INodeList removedNodes, int reachedDepth)
        {
            _removedNodes = removedNodes;
            _reachedDepth = reachedDepth;
        }
    }
}
