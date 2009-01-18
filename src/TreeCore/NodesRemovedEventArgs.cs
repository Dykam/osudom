using System;
namespace TreeCore
{
    public class NodesRemovedEventArgs : EventArgs
    {
        private int _depth;

        public NodesRemovedEventArgs(int depth)
        {
            _depth = depth;
        }

        public int Depth
        {
            get { return _depth; }
        }
    }
}
