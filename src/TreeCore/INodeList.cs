using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
	public interface INodeList : System.Collections.IEnumerable, System.Collections.Generic.IEnumerable<INode>
        // Done
	{
		/// <summary>
		/// Is called when Nodes are added tho this NodeList
		/// </summary>
		event NodesAddedEventHandler NodesAdded;
		/// <summary>
		/// Is called when Nodes are removed from this NodeList.
		/// </summary>
		event NodesRemovedEventHandler NodesRemoved;

		/// <summary>
		/// Adds a single Node into this NodeList.
		/// </summary>
		/// <param name="node">The Node to be added.</param>
		void Add(INode node);
		/// <summary>
		/// Adds multiple Nodes into this NodeList.
		/// </summary>
		/// <param name="nodes">The Nodes to be added.</param>
		void Add(INodeList nodes);
		/// <summary>
		/// Checks if a Node exists in the NodeList
		/// </summary>
		/// <param name="node">The Node to check for.</param>
		/// <returns>True if the Node does exist in the NodeList.</returns>
		bool Contains(INode node);
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
		/// <param name="nodes">The NodeList to insert.</param>
		/// <returns>0-indexed position of the first Node added from nodes.</returns>
		int InsertAt(int position, INodeList nodes);
		/// <summary>
		/// Remove a single Node from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Node!</remarks>
		/// <param name="node">The Node to remove.</param>
		/// <returns>False if the Node was not in this NodeList.</returns>
		bool Remove(INode node);
		/// <summary>
		/// Remove multiple Nodes from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Nodes!</remarks>
		/// <param name="nodes">The Nodes to remove.</param>
		/// <returns>The number of Nodes which where in the NodeList.</returns>
		int Remove(INodeList nodes);

		/// <summary>
		/// The Node at the specified index.
		/// </summary>
		/// <param name="index">The index to get the Node from.</param>
		/// <returns>The Node at the specified index.</returns>
		INode this[int index]
		{
			get;
		}

		/// <summary>
		/// The lenght of the NodeList
		/// </summary>
		int Length
		{
			get;
		}
	}
}
