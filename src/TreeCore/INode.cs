using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    interface INode
    {
        public INodeList Parents;
        public INodeList Nodes;
    }
}
