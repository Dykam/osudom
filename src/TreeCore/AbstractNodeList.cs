namespace TreeCore
{
    public abstract class AbstractNodeList : INodeList
    {

        #region INodeList Members

        public event NodesRemovedEventHandler OnNodesRemoved;

        public event NodeRemovedEventHandler OnRemoved;

        public void Add(INode inodeToAdd)
        {
            throw new System.NotImplementedException();
        }

        public void Add(INodeList inodesToAdd)
        {
            throw new System.NotImplementedException();
        }

        public int InsertNodeAt(int position, INode node)
        {
            throw new System.NotImplementedException();
        }

        public int InsertNodesAt(int position, INodeList nodes)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(INode inodeToRemove)
        {
            throw new System.NotImplementedException();
        }

        public int Remove(INodeList inodesToRemove)
        {
            throw new System.NotImplementedException();
        }

        public void CleanUp()
        {
            throw new System.NotImplementedException();
        }

        public INode this[int i]
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

        public int Length
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}
