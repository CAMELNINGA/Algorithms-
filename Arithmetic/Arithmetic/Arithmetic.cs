using System;
using System.Collections.Generic;
using System.Text;
using Deveel.Math;

namespace Arithmetic
{
    class Arithmetic
    {
        List<Node> Nodes { get; set; }

        ReadText readText { get; set; }

        decimal Low { get; set; }

        decimal High { get; set; }
        
        public  Arithmetic(List<Node>nodes, ReadText read)
        {
            Nodes = nodes;
            readText = read;
        }

        public string Start()
        {
            string line, exp;
            (line,exp)=readText.Readline();
            while (exp == null)
            {
                line = line + "\n";
                var c = line.ToCharArray();
                for(int i=0; i < c.Length; i++)
                {
                    Recount(c[i]);
                }
                (line, exp) = readText.Readline();

            }

            readText.ClouseSR();
           var ret = WriteText();
            return ret;
        }

        private void Recount (char c)
        {
           
            foreach (Node node in Nodes)
            {
                if (node.Chars == c)
                {
                     Low  = node.Low;
                    High = node.High;
                }
            }
            WrSamePart();
            decimal range = High - Low;
            foreach (Node node in Nodes)
            {

                node.Low = Low;
                var r = range * (decimal)(node.Range);
                Low = Low + r;
                node.High = Low;
            }
        }

        public (decimal,decimal) Count()
        {
            var low = Nodes[0].Low;
            var high = Nodes[Nodes.Count - 1].High;
            return (low, high);
        }


        private void WrSamePart()
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
            for (int i=3; i < length; i++)
            {
                if (sLow[i] == sHigh[i]) same += sLow[i-1];
                else
                {
                    if (same.Length != 0)
                    {
                        DelSamePart(same, sLow, sHigh);
                        readText.WriteText(same);
                    }
                    break;
                }
            }

        }

        private void DelSamePart(string samepart, string sLow, string sHigh)
        {
            sLow=sLow.Remove(2,samepart.Length);
            sHigh=sHigh.Remove(2,samepart.Length);
            Low = Convert.ToDecimal(sLow);
            High = Convert.ToDecimal(sHigh);
            if (sLow.Length > sHigh.Length)
            {
                var r = sLow.Length - sHigh.Length;
                sLow = sLow.Remove(sHigh.Length-1, r);
                Low = Convert.ToDecimal(sLow);
            }
            else if (sLow.Length < sHigh.Length)
            {
                var r = sHigh.Length-sLow.Length ;
                sHigh = sHigh.Remove(sLow.Length-1, r);
                High = Convert.ToDecimal(sHigh);
            }
        }
        
        public string WriteText()
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
            for (int i = 0; i < length; i++)
            {
                if (sLow[i] == sHigh[i]) same += sLow[i];
            }
            if (same.Length != 0)
            {
               
                    readText.WriteText(same);
                return same;
            }
            else
            {
                return "00000";
            }
        }
    }
}
