using System;
namespace TreeCore
{
    public class NodeList : INodeList
    {
        #region INodeList Members

        public event NodesAddedEventHandler NodesAdded;

        public event CleanedUpEventHandler CleanedUp;

        public event NodesRemovedEventHandler NodesRemoved;

        public void Add(INode node)
        {
            throw new NotImplementedException();
        }

        public void Add(INodeList nodes)
        {
            throw new NotImplementedException();
        }

        public uint InsertAt(int position, INode node)
        {
            throw new NotImplementedException();
        }

        public uint InsertAt(int position, INodeList nodes)
        {
            throw new NotImplementedException();
        }

        public bool Remove(INode node)
        {
            throw new NotImplementedException();
        }

        public uint Remove(INodeList nodes)
        {
            throw new NotImplementedException();
        }

        public void CleanUp()
        {
            throw new NotImplementedException();
        }

        public INode this[uint index]
        {
            get { throw new NotImplementedException(); }
        }

        public uint Length
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
