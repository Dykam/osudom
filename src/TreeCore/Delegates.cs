using System;
namespace TreeCore
{
	#region ListDelegates
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
    public delegate void CleanedUpEventHandler(object sender, CleanedUpEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodesRemovedEventHandler(object sender, NodesRemovedEventArgs e);
    #endregion
    
    #region NodeDelegates
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeDeletedEventHandler(object sender, NodeDeletedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChildNodesDeletedEventHandler(object sender, ChildNodesDeletedEventArgs e);
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
    public delegate void ChildNodesSplittedEventHandler(object sender, ChildNodesSplittedEventArgs e);
    #endregion
}
