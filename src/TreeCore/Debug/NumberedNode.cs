#if DEBUG
using System;

namespace TreeCore.Debug
{
    internal class NumberedNode : Node
    {
        private long m_value;

        public long Value
        {
            get { return m_value; }
            set { m_value = value; }
        }
        public NumberedNode(long value)
        {
            m_value = value;
        }

        public override string ToString()
        {
            return m_value.ToString();
        }
    }
}
#endif