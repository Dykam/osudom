namespace TreeCore
{
    public interface INodeList
    {
    	/// <summary>
    	/// Is called when multiple Nodes are removed from this NodeList.
    	/// </summary>
    	event NodesRemovedEventHandler OnNodesRemoved;
    	/// <summary>
    	/// Is called when a single Node is removed from this NodeList.
    	/// </summary>
    	event NodeRemovedEventHandler OnRemoved;

    	/// <summary>
    	/// Adds a single Node into this NodeList.
    	/// </summary>
    	/// <param name="inodeToAdd">The Node to be added.</param>
    	/// <returns>Returns false if the Node already did exist in this NodeList.</returns>
    	bool Add(INode inodeToAdd);
    	/// <summary>
    	/// Adds multiple Nodes into this NodeList.
    	/// </summary>
    	/// <param name="inodesToAdd">The Nodes to be added.</param>
    	/// <returns>Returns the number of Nodes which already did exist in this NodeList.</returns>
        int Add(INodeList inodesToAdd);
        /// <summary>
        /// Removes a single Node from this NodeList.
        /// </summary>
        /// <param name="inodeToRemove">The Node to remove.</param>
        /// <returns>Returns false if the Node was not in this NodeList.</returns>
        bool Remove(INode inodeToRemove);
        /// <summary>
        /// Removes multiple Nodes from this NodeList.
        /// </summary>
        /// <param name="inodesToRemove">The Nodes to remove.</param>
        /// <returns>Returns the number of Nodes which where not in the NodeList.</returns>
        int Remove(INodeList inodesToRemove);
        
        INode this[int i]
        {
            get;
            set;
        }
        int Length
        {
            get;
        }
    }
}
