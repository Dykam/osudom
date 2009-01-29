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
    public delegate void NodesSplittedEventHandler(object sender, NodesSplittedEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CleanedUpHandler(object sender, ListCleanedUpEventArgs e);
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
    public delegate void NodeDeletedHandler(object sender, NodeDeletedEventArgse e);
    /// <summary>
    /// 
    /// </summary>
    public delegate void ChildNodesDeletedHandler(object sender, ChildNodesDeletedEventArgs e);
    #endregion
}
