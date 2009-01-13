namespace TreeCore
{
    public interface INodeList
    {
        INodeList Add(INodeList inodesToAdd);
        INodeList Remove(INodeList inodesToRemove);
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
