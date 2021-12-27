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

        Binarin binarin { get; set; }

        public string Same { get; set; }
        
        public  Arithmetic(List<Node>nodes, ReadText read)
        {
            Nodes = nodes;
            readText = read;
            binarin = new Binarin();
            Same = "";
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
            var ret = WriteText();
            byte[] text, zero;
            (text, zero) = binarin.ToByteInBig(Same);
            readText.WriteText(text);
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
            int len = int.MaxValue;
            foreach (Node i in Nodes)
            {
                if (i.Low.ToString().Length - 2 < len)
                {
                    len = i.Low.ToString().Length;
                }
            }

            WrSamePart(len);
           

            decimal range = High - Low;
            var low = Low;
            foreach(Node node in Nodes)
            {

                node.Low = low;
                var r = range * (decimal)(node.Range);
                Low = low + r;
                node.High = low;
            }
        }

        public (decimal,decimal) Count()
        {
            var low = Nodes[0].Low;
            var high = Nodes[Nodes.Count - 1].High;
            return (low, high);
        }


        private void WrSamePart(int len)
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
            for (int i=2; i < length; i++)
            {
                if ( sLow[i]==sHigh[i]) same += sLow[i];
                else
                {
                    if (same.Length >=len)
                    {
                        DelSamePart(same, sLow, sHigh);
                        
                        Same = Same + same;
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
            /*
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
            }*/
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
            for (int i = 2; i < length; i++)
            {
                if (sLow[i] == sHigh[i]) same += sLow[i];
            }
            if (same.Length != 0)
            {
                Same = Same + same;
                return same;
            }
            else
            {
                return "00000";
            }
        }
    }
}
