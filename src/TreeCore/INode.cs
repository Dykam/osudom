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

        /// <summary>
        /// Lets a Node to be garbage collected by removing all references to this Node.
        /// </summary>
        void Remove();

        /// <summary>
        /// Completely removes all childNodes to a specified depth.
        /// </summary>
        /// <param name="depth">The depth the childNodes should be removed.</param>
        /// <returns>Reached depth.</returns>
        int RemoveChildNodes(int depth);
    }
}
