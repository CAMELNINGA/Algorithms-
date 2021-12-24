using System;
using System.Collections.Generic;
using System.Text;
using Deveel.Math;

namespace Arithmetic
{
    class Arithmetic
    {
        List<Node> Nodes { get; set; }
        
        public  Arithmetic(List<Node>nodes)
        {
            Nodes = nodes;
        }

        public void Start(char[] c)
        {
            for (int i = 0; i < c.Length; i++) 
            {
                Recount(c[i]);
            }
            
        }

        private void Recount (char c)
        {
            BigDecimal low = 0;
            BigDecimal high = 0;
            foreach (Node node in Nodes)
            {
                if (node.Chars == c)
                {
                     low  = node.Low;
                    high = node.High;
                }
            }
            BigDecimal range = high - low;
            foreach (Node node in Nodes)
            {
                node.Low = low;
                low = low + range * node.Range;
                node.High = low;
            }
        }

        public (BigDecimal,BigDecimal) Count()
        {
            BigDecimal low = Nodes[0].Low;
            BigDecimal high = Nodes[Nodes.Count - 1].High;
            return (low, high);
        }

        
    }
}
