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
    public delegate void CleanedUpHandler(object sender, CleanedUpEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodesRemovedHandler(object sender, NodesRemovedEventArgs e);
    #endregion
    
    #region NodeDelegates
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeDeletedHandler(object sender, NodeDeletedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChildNodesDeletedHandler(object sender, ChildNodesDeletedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NodeSplittedEventHandler(object sender, NodeSplittedEventArgs e);
    #endregion
}
