using System;
namespace TreeCore
{
    public class Node : INode
    {
        #region INode Members

        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        public event NodeDeletedHandler NodeDeleted;
        /// <summary>
        /// Is called when this Nodes ChildNodes are deleted.
        /// </summary>
        public event ChildNodesDeletedHandler ChildNodesDeleted;
        /// <summary>
        /// Is called when this node is splitted from his parents.
        /// </summary>
        public event NodeSplittedEventHandler NodeSplitted;

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
            throw new NotImplementedException();
            if (NodeDeleted != null)
                NodeDeleted(this, new NodeDeletedEventArgs());
        }

        public void Split()
        {
            throw new NotImplementedException();
            uint reachedDepth = 0;
            if (NodeSplitted != null)
                NodeSplitted(this, new NodeSplittedEventArgs(parents, reachedDepth));
        }

        public void Split(uint depth)
        {
            throw new NotImplementedException();
            uint reachedDepth = 0;
            if (NodeSplitted != null)
                NodeSplitted(this, new NodeSplittedEventArgs(parents, reachedDepth));
        }

        public int DeleteChildNodes(uint depth)
        {
            throw new NotImplementedException();
            uint reachedDepth = 0;
            if(ChildNodesDeleted != null)
                ChildNodesDeleted(this, new ChildNodesDeletedEventArgs(reachedDepth));
        }

        #endregion
    }
}
