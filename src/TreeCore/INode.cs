namespace TreeCore
{
    public interface INode
    {
        /// <summary>
        /// Parent INodes.
        /// </summary>
        INodeList Parents
        {
            get;
            set;
        }
        /// <summary>
        /// Child INodes.
        /// </summary>
        INodeList Nodes
        {
            get;
            set;
        }
    }
}
