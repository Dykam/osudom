namespace TreeCore
{
    public abstract class AbstractNodeList : INodeList
    {    	
		public event NodesRemovedEventHandler OnNodesRemoved;
    	
		public event NodeRemovedEventHandler OnRemoved;

        public abstract INode this[int i]
        {
            get;
            set;
        }

        public abstract int Length
        {
            get;
        }

        public abstract bool Add(INode inodeToAdd);

        public abstract int Add(INodeList inodesToAdd);

        public abstract bool Remove(INode inodeToRemove);

        public abstract int Remove(INodeList inodesToRemove);
    }
}
