using System;
namespace TreeCore
{
    public class Node : INode
    {
        #region INode Members
        
        #region NodeDeletedHandler NodeDeleted
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        private event NodeDeletedHandler nodeDeleted;
        /// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object nodeDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
        public event NodeDeletedHandler NodeDeleted
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
			NodeDeletedHandler handler;
		    lock (nodeDeletedLock)
		    {
		        handler = nodeDeleted;
		    }			
			if (handler != null) {
				handler(this, e);
			}
		}
		#endregion
		
		#region ChildNodesDeletedHandler ChildNodesDeleted
        /// <summary>
        /// Is called when this Nodes ChildNodes are deleted.
        /// </summary>
        private event ChildNodesDeletedHandler childNodesDeleted;
        /// <summary>
		/// Lock for NodeDeleted delegate access.
		/// </summary>
		private readonly object childNodesDeletedLock = new object();
		/// <summary>
		/// Is called when this Node is deleted.
		/// </summary>
        public event ChildNodesDeletedHandler ChildNodesDeleted
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
			ChildNodesDeletedHandler handler;
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
                parents[i].Nodes.RemoveNode(this);
                parents.Remove(parents[0]);
            }
            while (nodes.Length != 0)
            {
                nodes[i].Parents.RemoveNode(this);
                nodes.Remove(nodes[0]);
            }
            if (NodeDeleted != null)
                NodeDeleted(this, new NodeDeletedEventArgs());
        }

        public void Split()
        {
            throw new NotImplementedException();
            while(nodes.Length != 0)
            {
            	INode node = nodes[0];
            	uint localReachedDepth = node.Split();
            	node.Parents.Add(this);
            }
            if (NodeSplitted != null)
                NodeSplitted(this, new NodeSplittedEventArgs(parents, reachedDepth));
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
            if (NodeSplitted != null)
                NodeSplitted(this, new NodeSplittedEventArgs(parents, reachedDepth));
            return ++reachedDepth;
        }

        public int DeleteChildNodes(uint depth)
        {
            uint reachedDepth = 0;
            while(nodes.Length != 0)
            {
            	uint localReachedDepth = nodes[0].DeleteChildNodes(depth - 1);
            	if(localReachedDepth > reachedDepth)
            		reachedDepth = localReachedDepth;
            	nodes[0].Delete();
            }
            if(ChildNodesDeleted != null)
                ChildNodesDeleted(this, new ChildNodesDeletedEventArgs(reachedDepth));
            return ++reachedDepth;
        }

        #endregion
    }
}
