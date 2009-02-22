using System;
namespace TreeCore
{
	/// <summary>
	/// Description of IManualCleanedNodeList.
	/// </summary>
	public interface IManualCleanedNodeList : INodeList
	{
		/// <summary>
		/// Is called when this NodeList is cleaned up.
		/// </summary>
		event CleanedUpEventHandler CleanedUp;
		
		/// <summary>
		/// Checks for and removes doubles.
		/// </summary>
		void CleanUp();

		/// <summary>
		/// Adds a single Node into this NodeList.
		/// </summary>
		/// <param name="node">The Node to be added.</param>
		void ManualAdd(INode node);
		/// <summary>
		/// Adds multiple Nodes into this NodeList.
		/// </summary>
		/// <param name="nodes">The Nodes to be added.</param>
		void ManualAdd(INodeList nodes);
		/// <summary>
		/// Inserts a node at a given position in targetList.
		/// </summary>
		/// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length, the Node is added to the end. Position is 0-indexed.</param>
		/// <param name="node">Node to insert.</param>
		/// <returns>0-indexed position the Node is added.</returns>
		int ManualInsertAt(int position, INode node);
		/// <summary>
		/// Inserts nodes at a given position.
		/// </summary>
		/// <param name="position">Position to insert, negative value to count from the end. If position is bigger then Length , the Node is added to the end. Position is 0-indexed.</param>
		/// <param name="nodeList">The NodeList to insert.</param>
		/// <returns>0-indexed position of the first Node added from nodes.</returns>
		int ManualInsertAt(int position, INodeList nodes);
		/// <summary>
		/// Remove the first instance of a single Node from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Node!</remarks>
		/// <param name="node">The Node to remove.</param>
		/// <returns>Returns false if the Node was not in this NodeList.</returns>
		bool ManualRemove(INode node);
		/// <summary>
		/// Remove the first instance of multiple Nodes from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Nodes!</remarks>
		/// <param name="nodes">The Nodes to remove.</param>
		/// <returns>Returns the number of Nodes which where in the NodeList.</returns>
		int ManualRemove(INodeList nodes);
		/// <summary>
		/// Remove all entries of a single Node from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Node!</remarks>
		/// <param name="node">The Node to remove.</param>
		/// <returns>Returns false if the Node was not in this NodeList.</returns>
		bool AutomatedRemove(INode node);
		/// <summary>
		/// Remove all entries of multiple Nodes from this NodeList.
		/// </summary>
		/// <remarks>This will not delete the Nodes!</remarks>
		/// <param name="nodes">The Nodes to remove.</param>
		/// <returns>Returns the number of Nodes which where in the NodeList.</returns>
		int AutomatedRemove(INodeList nodes);
	}
}
