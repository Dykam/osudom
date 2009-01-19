namespace TreeCore
{
    public class Node : INode
    {
        #region INode Members

        public event NodeRemovedEventHandler OnNodeRemoved;

        public INodeList Parents
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

        public INodeList Nodes
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

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Split()
        {
            throw new System.NotImplementedException();
        }

        public bool Split(int depth)
        {
            throw new System.NotImplementedException();
        }

        public int RemoveChildNodes(int depth)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
