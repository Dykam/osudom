using System;
namespace TreeCore
{
    public class NodeList : AbstractNodeList
    {

        public override INode this[int i]
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override int Length
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool Add(INode inodeToAdd)
        {
            throw new System.NotImplementedException();
        }

        public override int Add(INodeList inodesToAdd)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(INode inodeToRemove)
        {
            throw new System.NotImplementedException();
        }

        public override int Remove(INodeList inodesToRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}
