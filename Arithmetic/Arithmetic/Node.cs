using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetic
{
    class Node
    {
        public char Chars { get; set; }
        public int Frequency { get; set; }
        
        public double Low { get; set; }
        public double High { get; set; }

        public double Range { get; set; }

        public Node(char chars, int frequency)
        {
            Chars = chars;
            
            Frequency = frequency;

        }


        public Node UpFreeq(int k)
        {

            Frequency = k;
            return this;
        }
    }
}
