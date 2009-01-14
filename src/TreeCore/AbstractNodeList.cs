namespace TreeCore
{
    abstract class AbstractNodeList :INodeList
    {
        #region INodeList Members

        public abstract INodeList Add(INodeList inodesToAdd);

        public abstract INodeList Remove(INodeList inodesToRemove);

        public abstract INode this[int i]
        {
            get;
            set;
        }

        public abstract uint Length
        {
            get;
        }

        #endregion
    }
}
