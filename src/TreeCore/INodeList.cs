using System;
namespace TreeCore
{
    public interface INodeList
    {
        /// <summary>
        /// Is called when Nodes are added tho this NodeList
        /// </summary>
        event NodesAddedEventHandler NodesAdded
        {
        	add;
        	remove;
        }
        /// <summary>
        /// Is called when this NodeList is cleaned up.
        /// </summary>
        event CleanedUpHandler CleanedUp
        {
        	add;
        	remove;
        }
        /// <summary>
        /// Is called when Nodes are removed from this NodeList.
        /// </summary>
        event NodesRemovedHandler NodesRemoved
        {
        	add;
        	remove;
        }

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
        int InsertAt(int position, INode node);
        /// <summary>
        /// Inserts nodes at a given position.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="nodeList">The NodeList to insert.</param>
        /// <returns>0-indexed position of the first Node added from nodes.</returns>
        int InsertAt(int position, INodeList nodes);
        /// <summary>
        /// Remove a single Node from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Node!</remarks>
        /// <param name="inodeToRemove">The Node to remove.</param>
        /// <returns>Returns false if the Node was not in this NodeList.</returns>
        bool Remove(INode inodeToRemove);
        /// <summary>
        /// Remove multiple Nodes from this NodeList.
        /// </summary>
        /// <remarks>This will not delete the Nodes!</remarks>
        /// <param name="inodesToRemove">The Nodes to remove.</param>
        /// <returns>Returns the number of Nodes which where not in the NodeList.</returns>
        int Remove(INodeList inodesToRemove);

        /// <summary>
        /// Checks for and removes doubles.
        /// </summary>
        void CleanUp();

        /// <summary>
        /// Returns a Node from the specified index.
        /// </summary>
        /// <param name="index">The index to get the Node from.</param>
        /// <returns>A Node from the specified index.</returns>
        INode this[int index]
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        int Length
        {
            get;
        }
    }
}
