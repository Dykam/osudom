using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    class NodeList : AbstractNodeList
    {
        public override INodeList Add(INodeList inodesToAdd)
        {
            throw new NotImplementedException();
        }

        public override INodeList Remove(INodeList inodesToRemove)
        {
            throw new NotImplementedException();
        }

        public override INode this[int i]
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

        public override uint Length
        {
            get { throw new NotImplementedException(); }
        }
    }
}
