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
        
        public BigDecimal Low { get; set; }
        public BigDecimal High { get; set; }

        public BigDecimal Range { get; set; }

        public Node(char chars, int frequency)
        {
            Chars = chars;
            
            Frequency = frequency;

        }


       
    }
}
