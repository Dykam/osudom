using System;
namespace TreeCore
{
    class ListNodeRemovedEventArgs
    {
        INode _removedNode;

        public INode RemovedNode
        {
            get { return _removedNode; }
        }

        public ListNodeRemovedEventArgs(INode removedNode)
        {
            _removedNode = removedNode;
        }
    }
}