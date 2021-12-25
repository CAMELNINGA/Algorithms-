using Deveel.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetic
{
    class Node
    {
        public char Chars { get; set; }
        public int Frequency { get; set; }
        
        public decimal Low { get; set; }
        public decimal High { get; set; }

        public double Range { get; set; }

        public Node(char chars, int frequency)
        {
            Chars = chars;
            
            Frequency = frequency;

        }


       
    }
}
