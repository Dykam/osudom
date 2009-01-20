﻿using System;
namespace TreeCore
{
    class NodeRemovedEventArgs
    {
        private INode _node;

        public INode Node
        {
            get { return _node; }
        }
        public NodeRemovedEventArgs(INode node)
        {
            _node = node;
        }
    }
}