using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetic
{
    [Serializable]
    class NodeDic
    {
        public char Char { get; set; }
        public double Range { get; set; }

        public NodeDic (char chars, double range)
        {
            Char = chars;
            Range = range;
        }
    }
}
