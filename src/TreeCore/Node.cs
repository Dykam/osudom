using System;
namespace TreeCore
{
    public class Node : INode
    {
        #region INode Members
        
        #region NodeDeletedEventHandler NodeDeleted
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        private event NodeDeletedEventHandler nodeDeleted;
        /// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object nodeDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
        public event NodeDeletedEventHandler NodeDeleted
        {
        	add
        	{
        		lock(nodeDeletedLock)
        		{
	        		nodeDeleted += value;
        		}
		    }
		    remove
		    {
		    	lock(nodeDeletedLock)
        		{
		     		nodeDeleted -= value;
		    	}
		    }
        }
        /// <summary>
        /// Has to be called when this Node is deleted.
        /// </summary>
        /// <param name="e"></param>
		protected void OnNodeDeleted(NodeDeletedEventArgs e)
		{			
			NodeDeletedEventHandler handler;
		    lock (nodeDeletedLock)
		    {
		        handler = nodeDeleted;
		    }			
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion
		
		#region ChildNodesDeletedEventHandler ChildNodesDeleted
        /// <summary>
        /// Is called when this Nodes ChildNodes are deleted.
        /// </summary>
        private event ChildNodesDeletedEventHandler childNodesDeleted;
        /// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object childNodesDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
        public event ChildNodesDeletedEventHandler ChildNodesDeleted
        {
        	add
        	{
        		lock(childNodesDeletedLock)
        		{
	        		childNodesDeleted += value;
        		}
		    }
		    remove
		    {
		    	lock(childNodesDeletedLock)
        		{
		     		childNodesDeleted -= value;
		    	}
		    }
        }
        /// <summary>
        /// Has to be called when this Node is deleted.
        /// </summary>
        /// <param name="e"></param>
		protected void OnChildNodesDeleted(ChildNodesDeletedEventArgs e)
		{			
			ChildNodesDeletedEventHandler handler;
		    lock (childNodesDeletedLock)
		    {
		        handler = childNodesDeleted;
		    }			
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion
		
		#region NodeSplittedEventHandler NodeSplitted
        /// <summary>
        /// Is called when this node is splitted from his parents.
        /// </summary>
        private event NodeSplittedEventHandler nodeSplitted;
        /// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object nodeSplittedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
        public event NodeSplittedEventHandler NodeSplitted
        {
        	add
        	{
        		lock(nodeSplittedLock)
        		{
	        		nodeSplitted += value;
        		}
		    }
		    remove
		    {
		    	lock(nodeSplittedLock)
        		{
		     		nodeSplitted -= value;
		    	}
		    }
        }
        /// <summary>
        /// Has to be called when this Node is deleted.
        /// </summary>
        /// <param name="e"></param>
		protected void OnNodeSplitted(NodeSplittedEventArgs e)
		{			
			NodeSplittedEventHandler handler;
		    lock (nodeSplittedLock)
		    {
		        handler = nodeSplitted;
		    }			
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion

        private NodeList parents;
        public INodeList Parents
        {
            get
            {
                return parents;
            }
        }
        private NodeList nodes;
        public INodeList Nodes
        {
            get 
            {
                return nodes;
            }
        }

        public void Delete()
        {
            while (parents.Length != 0)
            {
                parents[0].Nodes.Remove(this);
                parents.Remove(parents[0]);
            }
            while (nodes.Length != 0)
            {
                nodes[0].Parents.Remove(this);
                nodes.Remove(nodes[0]);
            }
            OnNodeDeleted(new NodeDeletedEventArgs());
        }

        public void Split()
        {
            throw new NotImplementedException();
            uint reachedDepth = 0;
            while(nodes.Length != 0)
            {
                INode childNode = nodes[0];
                uint localReachedDepth = Node.Split(this);
                childNode.Parents.Add(this);
                if (localReachedDepth > reachedDepth)
                    reachedDepth = localReachedDepth;
            }
            OnNodeSplitted(new NodeSplittedEventArgs(parents, reachedDepth));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static uint Split(INode node)
        {
            uint reachedDepth = 0;
            while (node.Nodes.Length != 0)
            {
                INode childNode = node.Nodes[0];
                uint localReachedDepth = Node.Split(childNode);
                childNode.Parents.Add(node);
                node.Nodes.Add(node);
                if (localReachedDepth > reachedDepth)
                    reachedDepth = localReachedDepth;
            }
            while (node.Parents.Length != 0)
            {
                node.Parents[0].Nodes.Remove(node);
                node.Parents.Remove(node.Parents[0]);
            }
            return ++reachedDepth;
        }
        public uint Split(uint depth)
        {
            uint reachedDepth = 0;
            while(nodes.Length != 0)
            {
            	INode node = nodes[0];
            	uint localReachedDepth = node.Split(depth - 1);
            	node.Parents.Add(this);
            	nodes.Add(node);
            	if(localReachedDepth > reachedDepth)
            		reachedDepth = localReachedDepth;
            }
            while(parents.Length != 0)
            {
            	parents[0].Nodes.Remove(this);
            	parents.Remove(parents[0]);
            }
            OnNodeSplitted(new NodeSplittedEventArgs(parents, reachedDepth));
            return ++reachedDepth;
        }

        public uint DeleteChildNodes(uint depth)
        {
            uint reachedDepth = 0;
            while(nodes.Length != 0)
            {
            	uint localReachedDepth = nodes[0].DeleteChildNodes(depth - 1);
            	if(localReachedDepth > reachedDepth)
            		reachedDepth = localReachedDepth;
            	nodes[0].Delete();
            }
            OnChildNodesDeleted(new ChildNodesDeletedEventArgs(reachedDepth));
            return ++reachedDepth;
        }

        #endregion
    }
}
