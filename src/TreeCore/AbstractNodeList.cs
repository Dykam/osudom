namespace TreeCore
{
    abstract class AbstractNodeList :INodeList
    {    	
		public event NodesRemovedEventHandler OnNodesRemoved;
    	
		public event NodeRemovedEventHandler OnRemoved;
    	
		public INode this[int i]
		{
		}
    	
		public uint Length {
			get {
				throw new NotImplementedException();
			}
		}
    	
		public bool Add(INode inodeToAdd)
		{
			throw new NotImplementedException();
		}
    	
		public uint Add(INodeList inodesToAdd)
		{
			throw new NotImplementedException();
		}
    	
		public bool Remove(INode inodeToRemove)
		{
			throw new NotImplementedException();
		}
    	
		public uint Remove(INodeList inodesToRemove)
		{
			throw new NotImplementedException();
		}
    }
}
