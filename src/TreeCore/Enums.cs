using System;
namespace TreeCore
{
	[Serializable]
	public enum NodeListType : byte
	{
		ChildNodes = 0x000001,
		ParentNodes = 0x000002
	}
}
