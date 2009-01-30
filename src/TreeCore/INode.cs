using System;
namespace TreeCore
{
    public interface INode
    {
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        event NodeDeletedHandler NodeDeleted
        {
        	add;
        	remove;
        }
        /// <summary>
        /// Is called when this Nodes ChildNodes are deleted.
        /// </summary>
        event ChildNodesDeletedHandler ChildNodesDeleted        	
        {
        	add;
        	remove;
        }
        /// <summary>
        /// Is called when this node is splitted from his parents.
        /// </summary>
        event NodeSplittedEventHandler NodeSplitted
        {
        	add;
        	remove;
        }

        /// <summary>
        /// Parent Nodes.
        /// </summary>
        INodeList Parents
        {
            get;
        }
        
        /// <summary>
        /// Child Nodes.
        /// </summary>
        INodeList Nodes
        {
            get;
        }

        /// <summary>
        /// Lets a Node to be garbage collected by removing all references to this Node.
        /// </summary>
        void Delete();
        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        /// <remarks>This function does not always have a loop-detection.</remarks>
        void Split();
        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        /// <param name="depth">The depth for removing references from parents from ChildNodes. Time will increase exponentially.</param>
        /// <returns>Reached depth.</returns>
        uint Split(uint depth);

        /// <summary>
        /// Completely removes all childNodes to a specified depth.
        /// </summary>
        /// <param name="depth">The depth the childNodes should be removed.</param>
        /// <returns>Reached depth.</returns>
        uint DeleteChildNodes(uint depth);
    }
}
