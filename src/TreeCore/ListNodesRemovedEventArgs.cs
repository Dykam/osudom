using System;
namespace TreeCore
{
    class ListNodesRemovedEventArgs
    {
        INodeList _removedNodes;

        public INodeList RemovedNodes
        {
            get { return _removedNodes; }
        }

        public ListNodesRemovedEventArgs(INodeList removedNodes)
        {
            _removedNodes = removedNodes;
        }
    }
}