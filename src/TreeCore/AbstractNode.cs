using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    abstract class AbstractNode : INode
    {
        #region INode Members

        public INodeList Parents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public INodeList Nodes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Remove()
        {
            throw new NotImplementedException();
            Parents.Remove(this);
        }

        public void RemoveNodes(uint maxDepth)
        {
            throw new NotImplementedException();
            if (maxDepth != 0)
            {
                for (uint i = 0; i < Nodes.Length; i++)
                {
                    Nodes[i].RemoveNodes(maxDepth - 1);
                    Nodes[i].Remove();
                }
            }
        }

        #endregion
    }
}
