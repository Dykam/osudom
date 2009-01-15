namespace TreeCore
{
    public interface INodeList
    {
        void Add(INodeList inodesToAdd);
        void Add(INode inodeToAdd);
        uint Remove(INodeList inodesToRemove);
        bool Remove(INode inodeToRemove);
        INode this[int i]
        {
            get;
            set;
        }
        uint Length
        {
            get;
        }
    }
}
