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
    	void Add(INode inodeToAdd);
    	/// <summary>
    	/// Adds multiple Nodes into this NodeList.
    	/// </summary>
    	/// <param name="inodesToAdd">The Nodes to be added.</param>
        void Add(INodeList inodesToAdd);
        /// <summary>
        /// Inserts a node at a given position in targetList.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length, the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="node">Node to insert.</param>
        /// <returns>0-indexed position the Node is added.</returns>
        int InsertNodeAt(int position, INode node);
        /// <summary>
        /// Inserts nodes at a given position.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="nodeList">The NodeList to insert.</param>
        /// <returns>0-indexed position of the first Node added from nodes.</returns>
        int InsertNodesAt(int position, INodeList nodes);
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

        /// <summary>
        /// Checks for and removes doubles.
        /// </summary>
        void CleanUp();
        
        INode this[int index]
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
