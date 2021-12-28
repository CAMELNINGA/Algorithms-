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
        public string Cnt { get; set; }
        
        public  Arithmetic(List<Node>nodes, ReadText read)
        {
            Nodes = nodes;
            readText = read;
            binarin = new Binarin();
            Same = "";
            Cnt = "";
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
            (text, zero) = binarin.ToByteInBig(Same,Cnt);
            readText.WriteText(text,zero);
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
                    break;
                }
            }
            

            WrSamePart();
           

            decimal range = High - Low;
            var low = Low;
            foreach(Node node in Nodes)
            {

                node.Low = low;
                var r = range * (decimal)(node.Range);
                low = low + r;
                node.High = low;
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
            for (int i=2; i < length; i++)
            {
                if ( sLow[i]==sHigh[i]) same += sLow[i];
                else
                {

                    DelSamePart(same, sLow, sHigh);

                    Same = Same + same;
                    Cnt = Cnt + same.Length;

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
            Console.WriteLine("sLow={0} sHigh={0}", Low, High);
           
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
                Cnt = Cnt + same.Length;
                return same;
            }
            else
            {
                return "00000";
            }
        }
    }
}
