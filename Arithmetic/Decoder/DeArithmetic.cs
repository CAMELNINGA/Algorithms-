using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    class DeArithmetic
    {
        List<Node> Nodes { get; set; }

        ReadText readText { get; set; }

        int Count { get; set; }

        decimal Low { get; set; }

        decimal High { get; set; }

        string Same { get; set; }
        char C { get; set; }

        public DeArithmetic(List<Node> nodes,ReadText read, string same, int count)
        {
            Nodes = nodes;
            readText = read;
            Same = same;
            Count = count;
            Low = 0;
            High = 1;
        }
        public string Start()
        {
            string text = "";
            decimal ddata = Convert.ToDecimal("0," + Same);
           for(int i =0; i < Count+1; i++)
            {
                string sameRangeText = "";
               
                foreach (Node node in Nodes)
                {
                    if (node.Low<ddata && node.High > ddata)
                    {
                        sameRangeText=sameRangeText + node.Chars;
                        C = node.Chars;
                        break;
                    }
                }
                text = text + sameRangeText;
                Recount();
               ddata = Convert.ToDecimal("0," + Same);
                
                
            }
            return text;
        }

        private void Recount()
        {
            foreach (Node node in Nodes)
            {
                if (node.Chars == C)
                {
                    Low = node.Low;
                    High = node.High;
                }
            }

            DellSamePart();

            decimal range = High - Low;
            var low = Low;
            foreach (Node node in Nodes)
            {
                node.Low = low;
                var r = range * (decimal)(node.Range);
                low = low + r;
                node.High = low;
                
            }
            
        }

        private void DellSamePart()
        {
            string same = "";
            string sLow = Low.ToString();
            string sHigh = High.ToString();
            int length;
            if (sLow.Length > sHigh.Length)
            {
                length = sHigh.Length;
            }
            else
            {
                length = sLow.Length;
            }
            for (int i = 2; i < length; i++)
            {
                if (sLow[i] == sHigh[i]) same += sLow[i ];
                else
                {
                  
                    while(same.Length != 0 && Same[0]==sLow[2])
                    {
                        Same = Same.Remove(0, 1);
                        (sLow,sHigh)=DelSamePart(same, sLow, sHigh);
                        same=same.Remove(0, 1);
                    }
                    
                    break;
                }
            }
        }
        private (string,string) DelSamePart(string samepart, string sLow, string sHigh)
        {
            sLow = sLow.Remove(2, 1);
            sHigh = sHigh.Remove(2, 1);
            Low = Convert.ToDecimal(sLow);
            High = Convert.ToDecimal(sHigh);
            Console.WriteLine("sLow={0} sHigh={0}", Low, High);
            return (sLow, sHigh);
        }
    }
}
