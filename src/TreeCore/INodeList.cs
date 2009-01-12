using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    interface INodeList
    {
        public static INodeList operator +(INodeList nodeList, INodeList inodesToAdd);
        public static INodeList operator -(INodeList nodeList, INodeList inodesToRemove);
        public void NextNode();
        public void PreviousNode();
        public INode CurrentNode;
    }
}
