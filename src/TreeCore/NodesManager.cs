using System;
namespace TreeCore
{
	/// <summary>
    /// Contains some unnecessary functions, implemented by the NodeLists themself.
	/// </summary>
	public class NodesManager<TNodeList> where TNodeList : INodeList, new()
	{
		/************
		 * Deprecated
		/// <summary>
		/// Is called when multiple INodes are removed from this INodeList.
		/// </summary>
		static event NodesRemovedEventHandler OnNodesRemoved;
		/// <summary>
		/// Is called when a single INode is removed from this INodeList.
		/// </summary>
		static event NodeRemovedEventHandler OnRemoved;
		*/
		
		/************
		 * Deprecated
		/// <summary>
		/// Lets all Nodes to be garbage collected by removing all references to them.
		/// </summary>
		/// <param name="node"></param>
		/// <param name="depth"></param>
		/// <returns></returns>
		static int RemoveChildNodes(INode node, int depth)
		{
            throw new NotImplementedException();
            int reachedDepth;
			if (depth != 0)
			{
                reachedDepth = RemoveChildNodes(node, depth);
			}
			RemoveNode(node);
            return reachedDepth;
		}*/

		/************
		 * Deprecated
		/// <summary>
		/// Lets a Node to be garbage collected by removing all references to this Node.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		static INodeList RemoveNode(INode node)
		{
            throw new NotImplementedException();
			for (int i = 0; i < node.Parents.Length; i++)
			{
				node.Parents[Convert.ToInt32(i)].Nodes.Remove(node);
			}
			for (int i = 0; i < node.Nodes.Length; i++)
			{
                node.Nodes[Convert.ToInt32(i)].Parents.Remove(node);
			}
		}*/

		/************
		 * Deprecated
		/// <summary>
        /// Inserts a node at a given position in targetList.
		/// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then the Length of the targetList, the Node is added to the end. Position is 0-indexed.</param>
		/// <param name="node">Node to insert.</param>
        /// <param name="targetList">The NodeList to add the Node in.</param>
		/// <returns>0-indexed position the Node is added.</returns>
        static int InsertNodeAt(int position, INode node, INodeList targetList)
		{
            if (position > targetList.Length)
			{
                targetList.Add(node);
                return targetList.Length;
			}
			if (position < 0)
                position = targetList.Length - position;
			TNodeList newNodeList = new TNodeList();
			int newPos = 0;
			for (int i = 0; i < targetList.Length; i++)
			{
				if (i == position)
				{
					newNodeList.Add(node);
					newPos = i;
				}
                newNodeList.Add(targetList[i]);
			}
            return newPos;
		}*/

		/************
		 * Deprecated
        /// <summary>
        /// Inserts nodes at a given position.
        /// </summary>
        /// <param name="position">Position to insert, negative value to count from the end. If position is bigger then the Length of the targetList, the Node is added to the end. Position is 0-indexed.</param>
        /// <param name="nodeList">The NodeList to insert.</param>
        /// <param name="targetList">The NodeList to add the sourceList in.</param>
        /// <returns>0-indexed position of the first Node added from sourceList.</returns>
        static int InsertNodesAt(int position, INodeList sourceList, INodeList targetList)
        {
            if (position > targetList.Length)
            {
                targetList.Add(sourceList);
                return targetList.Length;
            }
            if (position < 0)
                position = targetList.Length - position;
            TNodeList newNodeList = new TNodeList();
            int newPos = 0;
            for (int i = 0; i < targetList.Length; i++)
            {
                if (i == position)
                {
                    newNodeList.Add(sourceList);
                    newPos = i;
                }
                newNodeList.Add(targetList[i]);
            }
            targetList.Remove(targetList);
            targetList.Add(newNodeList);
            return newPos;
        }*/
	}
}
