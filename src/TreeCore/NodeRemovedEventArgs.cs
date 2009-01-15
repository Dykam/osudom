using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    class NodeRemovedEventArgs : EventArgs
    {
        private INode _node;

        public INode Node
        {
            get { return _node; }
        }
        private INodeList _childNodes;

        public INodeList ChildNodes
        {
            get { return _childNodes; }
        }
        private INodeList _parents;

        public INodeList Parents
        {
            get { return _parents; }
        }
        public NodeRemovedEventArgs(INode node, INodeList childNodes, INodeList parents)
        {
            _node = node;
            _childNodes = childNodes;
            _parents = parents;
        }
    }
}
