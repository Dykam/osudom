using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    class NodesRemovedEventArgs : EventArgs
    {
        private uint _depth;

        public NodesRemovedEventArgs(uint depth)
        {
            _depth = depth;
        }

        public uint Depth
        {
            get { return _depth; }
        }
    }
}
