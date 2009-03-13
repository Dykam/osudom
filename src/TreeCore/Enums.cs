using System;
namespace TreeCore
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    [Serializable]
    [CLSCompliantAttribute(true)]
	public enum NodeListType : byte
	{
        /// <summary>
        /// 
        /// </summary>
		ChildNodes = 0x000001,
        /// <summary>
        /// 
        /// </summary>
		ParentNodes = 0x000002
	}
}
