using System;
namespace TreeCore
{
    public interface INode
    {
        /// <summary>
        /// Is called when all References
        /// </summary>
        event NodeRemovedEventHandler OnNodeRemoved;

        /// <summary>
        /// Parent Nodes.
        /// </summary>
        INodeList Parents
        {
            get;
            set;
        }
        
        /// <summary>
        /// Child Nodes.
        /// </summary>
        INodeList Nodes
        {
            get;
            set;
        }

        /// <summary>
        /// Lets a Node to be garbage collected by removing all references to this Node.
        /// </summary>
        void Delete();
        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        void Split();
        /// <summary>
        /// Removes all references to this Node in Parents, being a new Tree-top afterwards.
        /// </summary>
        /// <param name="depth">The depth to look for references to Parent.</param>
        /// <returns>Returns true if the lookup reached a Parent Node.</returns>
        bool Split(int depth);

        /// <summary>
        /// Completely removes all childNodes to a specified depth.
        /// </summary>
        /// <param name="depth">The depth the childNodes should be removed.</param>
        /// <returns>Reached depth.</returns>
        int DeleteChildNodes(int depth);
    }
}
