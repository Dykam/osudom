using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    class NodeSplittedEventArgs
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
        private INodeList _exParents;

        private int _depth;

        public int Depth
        {
            get { return _depth; }
        }

        public INodeList ExParents
        {
            get { return _exParents; }
        }
        public NodeSplittedEventArgs(INode node, INodeList childNodes, INodeList exParents)
        {
            _node = node;
            _childNodes = childNodes;
            _parents = parents;
            _depth = 0;
        }
        public NodeSplittedEventArgs(INode node, INodeList childNodes, INodeList exParents, int realSplitDepth)
        {
            _node = node;
            _childNodes = childNodes;
            _parents = parents;
            _depth = Depth;
        }
    }
}
