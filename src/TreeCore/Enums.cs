using System;
namespace TreeCore
{
    [Serializable]
    [CLSCompliantAttribute(true)]
	public enum NodeListType : byte
	{
		ChildNodes = 0x000001,
		ParentNodes = 0x000002
	}
}
