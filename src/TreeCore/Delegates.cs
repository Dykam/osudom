﻿namespace TreeCore
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
}