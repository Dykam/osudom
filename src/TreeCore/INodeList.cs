namespace TreeCore
{
    public interface INodeList
    {
        void Add(INodeList inodesToAdd);
        bool Remove(INodeList inodesToRemove);
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
