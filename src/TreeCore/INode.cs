using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
    public interface INode
    {
        /// <summary>
        /// Is called when this Node is deleted.
        /// </summary>
        event NodeDeletedEventHandler NodeDeleted;
        /// <summary>
        /// Is called when this Nodes ChildNodes are deleted.
        /// </summary>
        event ChildNodesDeletedEventHandler ChildNodesDeleted;
        /// <summary>
        /// Is called when this node is splitted from his parents.
        /// </summary>
        event NodeSplittedEventHandler NodeSplitted;
        /// <summary>
        /// Is called when all child nodes have been split from their parents, and their only parent lead to this Node.
        /// </summary>
        event ChildNodesSplittedEventHandler ChildNodesSplitted;

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
        /// Completely removes all childNodes to a specified depth.
        /// </summary>
        /// <param name="depth">The depth the childNodes should be removed.</param>
        /// <returns>Reached depth.</returns>
        int DeleteChildNodes(int depth);
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
        int SplitChildNodes(int depth);
    }
}
