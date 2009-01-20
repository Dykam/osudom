using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodesRemovedEventHandler(object sender, NodesRemovedEventArgs e);
    /// <summary>
    /// Is called when a single INode is removed from a INodeList.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeRemovedEventHandler(object sender, NodeRemovedEventArgs e);
    /// <summary>
    /// Is called when a single INode is Splitted from his Parents.    ///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeSplittedEventHandler(object sender, NodeSplittedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeAddedEventHandler(object sender, NodeAddedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodesAddedEventHandler(object sender, NodesAddedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeSplittedEventHandler(object sender, NodeSplittedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ListCleanedUpHandler(object sender, EventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ListCleanedUpHandler(object sender, ListCleanedUpEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ListNodeRemovedHandler(object sender, ListNodeRemovedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ListNodesRemovedHandler(object sender, ListNodesRemovedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChildNodesRemovedHandler(object sender, ChildNodesRemovedEventArgs e);
}
