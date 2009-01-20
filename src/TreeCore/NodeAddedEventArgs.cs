using System;
namespace TreeCore
{
    class NodeAddedEventArgs
    {
        private INode _node;

        public INode Node
        {
            get { return _node; }
        }
        public NodeAddedEventArgs(INode node)
        {
            _node = node;
        }
    }
}