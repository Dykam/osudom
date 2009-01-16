namespace TreeCore
{
    /// <summary>
    /// Is called when complete removal of this <c>Inode</c> and/or childs is explicitly required.
    /// </summary>
    /// <param name="maxDepth">If non-zero, max depth of child-removal.</param>
    public delegate void RemoveHandler(uint maxDepth);
    /// <summary>
    /// Is called when complete removal of this <c>Inode</c>'s childs is explicitly required.
    /// </summary>
    /// <param name="maxDepth">If non-zero, max depth of child-removal.</param>
    public delegate void RemoveNodesHandler(uint maxDepth);
    /// <summary>
    /// Is called when multiple INodes are removed from a INodeList.
    /// </summary>
    public delegate void NodesRemovedEventHandler(object sender, NodesRemovedEventArgs e);
    /// <summary>
    /// Is called when a single INode is removed from a INodeList.
    /// </summary>
    public delegate void NodeRemovedEventHandler(object sender, NodeRemovedEventArgs e);
}
