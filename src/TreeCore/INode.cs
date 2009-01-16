namespace TreeCore
{
    public interface INode
    {
        /// <summary>
        /// Parent Nodes.
        /// </summary>
        INodeList Parents
        {
            get;
            set;
        }
        
        /// <summary>
        /// Child Nodes.
        /// </summary>
        INodeList Nodes
        {
            get;
            set;
        }
    }
}
