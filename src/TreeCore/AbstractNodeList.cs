namespace TreeCore
{
    public abstract class AbstractNodeList : INodeList // Not finished, need to switch some events
    {
        #region internalMembers
        abstract private void internalAdd(INodeList inodesToAdd);
        abstract private void internalAdd(INodeList inodesToAdd);
        abstract private void internalInsertNodeAt(int position, INode node);
        abstract private void internalInsertNodesAt(int position, INodeList nodes);
        abstract private bool internalRemove(INode inodeToRemove);
        abstract private int internalRemove(INodeList inodesToRemove);
        abstract private void internalCleanUp();
        abstract private INode internalGetInode(int index);
        abstract private void internalSetInode(int index, INode node);
        abstract private int internalLenght { get; }
        #endregion


        #region INodeList Members

        public event NodesRemovedEventHandler OnNodesRemoved;

        public event NodeRemovedEventHandler OnRemoved;

        public void Add(INode inodeToAdd)
        {
            internalAdd(inodeToAdd);
        }

        public void Add(INodeList inodesToAdd)
        {
            internalAdd(inodesToAdd);
        }

        public int InsertNodeAt(int position, INode node)
        {
            internalInsertNodeAt(position, node);
        }

        public int InsertNodesAt(int position, INodeList nodes)
        {
            internalInsertNodesAt(position, nodes);
        }

        public bool Remove(INode inodeToRemove)
        {            
            Remove(inodeToRemove);
        }

        public int Remove(INodeList inodesToRemove)
        {
            Remove(inodesToRemove);
        }

        public void CleanUp()
        {
            CleanUp();
        }

        public INode this[int index]
        {
            get
            {
                return internalGetInode(index);
            }
            set
            {
                internalSetInode(index, value);
            }
        }

        public int Length
        {
            get
            {
                return internalLenght;
            }
        }

        #endregion
    }
}
