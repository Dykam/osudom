#if DEBUG
using System;
namespace TreeCore
{
	[Serializable]
	internal class ThreadSafeLinkedNodeList : INodeList, IAsyncResult
	{
		public ThreadSafeLinkedNodeList()
		{
			throw new NotImplementedException();
		}

		#region IAsyncResult Members

		public virtual object AsyncState
		{
			get { throw new NotImplementedException(); }
		}

		public virtual System.Threading.WaitHandle AsyncWaitHandle
		{
			get { throw new NotImplementedException(); }
		}

		public virtual bool CompletedSynchronously
		{
			get { throw new NotImplementedException(); }
		}

		public virtual bool IsCompleted
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region INodeList Members

		public virtual event NodesAddedEventHandler NodesAdded;

		public virtual event NodesRemovedEventHandler NodesRemoved;

		public virtual void Add(INode node)
		{
			throw new NotImplementedException();
		}

		public virtual void Add(INodeList nodes)
		{
			throw new NotImplementedException();
		}

		public virtual bool Contains(INode node)
		{
			throw new NotImplementedException();
		}
		
		public virtual int InsertAt(int position, INode node)
		{
			throw new NotImplementedException();
		}

		public virtual int InsertAt(int position, INodeList nodes)
		{
			throw new NotImplementedException();
		}

		public virtual bool Remove(INode node)
		{
			throw new NotImplementedException();
		}

		public virtual int Remove(INodeList nodes)
		{
			throw new NotImplementedException();
		}

		public virtual INode this[int index]
		{
			get { throw new NotImplementedException(); }
		}

		public virtual int Length
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
#endif
