namespace TreeCore
{
	/// <summary>
	/// Description of INodesManager.
	/// </summary>
	public class NodesManager<TNodeList> where TNodeList : INodeList
	{
		/// <summary>
    	/// Is called when multiple INodes are removed from this INodeList.
    	/// </summary>
    	static event NodesRemovedEventHandler OnNodesRemoved;
    	/// <summary>
    	/// Is called when a single INode is removed from this INodeList.
    	/// </summary>
    	static event NodeRemovedEventHandler OnRemoved;
    	
    	/// <summary>
    	/// Lets all Node to be garbage collected by removing all references to them.
    	/// </summary>
    	/// <param name="node"></param>
    	/// <param name="depth"></param>
    	/// <returns></returns>
    	static uint RemoveChildNodes(INode node, uint depth)
    	{
    		if(depth != 0)
    		{
    			RemoveChildNodes(node, depth);
    		}
    		RemoveNode(node);
    	}
    	
    	/// <summary>
    	/// Lets a Node to be garbage collected by removing all references to this Node.
    	/// </summary>
    	/// <param name="node"></param>
    	/// <returns></returns>
    	static INodeList RemoveNode(INode node)
    	{    		
    		for(uint i = 0; i < node.Parents.Length; i++)
    		{
    			node.Parents[i].Nodes.Remove(node);
    		}
    		for(uint i = 0; i < node.Nodes.Length; i++)
    		{
    			node.Nodes[i].Parents.Remove(node);
    		}
    	}
    	
    	/// <summary>
    	/// Inserts a node at a given position.
    	/// </summary>
    	/// <param name="position">Position to insert, negative value to count from the end. If position is bigger then the lenght of the NodeList, the Node is added to the end. Position is 0-indexed.</param>
    	/// <param name="node">Node to insert.</param>
    	/// <param name="nodeList">The NodeList to add the Node in.</param>
    	/// <returns>0-indexed position the Node is added.</returns>
    	static uint InsertNodeAt(int position, INode node, INodeList nodeList)
    	{
    		if(position > inodeList.Lenght)
    		{
    			nodeList.Add(node);
    			return nodeList.Lenght;
    		}
		if(position < 0)
			position = nodeList.Lenght - position;
    		TNodeList newNodeList = new TNodeList();
    		uint newPos;
    		for(uint i = 0; i < nodeList.Lenght; i++)
    		{
			if(i = position)
    			{
				newNodeList.Add(node);
				newPos = i;
    			}
    			newNodeList.Add(nodeList[i]);
    		}
    	}
	}
}
