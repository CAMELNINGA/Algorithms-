using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    class Node
    {
        public char Chars { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public double Range { get; set; }


        public Node(char chars, double range)
        {
            Chars = chars;

            Range = range;

        }
    }
}
