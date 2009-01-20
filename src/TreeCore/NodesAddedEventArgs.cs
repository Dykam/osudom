using System;
namespace TreeCore
{
    class NodesAddedEventArgs
    {
        private INodeList _nodes;

        public INodeList Nodes
        {
            get { return _node; }
        }
        public NodesAddedEventArgs(INodeList nodes)
        {
            _node = node;
        }
    }
}