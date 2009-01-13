namespace TreeCore
{
    public interface INode
    {
        INodeList Parents
        {
            get;
            set;
        }
        INodeList Nodes
        {
            get;
            set;
        }
        void Remove();
        void RemoveNodes(uint maxDepth);
    }
}
