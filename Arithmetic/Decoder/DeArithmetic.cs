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
            string Text = "";
            int len = int.MaxValue;
            foreach(Node i in Nodes){
                if (i.Low.ToString().Length - 2 < len)
                {
                    len = i.Low.ToString().Length;
                }
            }
            string data = Same.Substring(len);
            decimal ddata = Convert.ToDecimal("0," + data);
           for(int i =0; i < Count; i++)
            {
                string sameRangeText = "";
               
                foreach (Node node in Nodes)
                {
                    if (node.Low<ddata && node.High > ddata)
                    {
                        sameRangeText=sameRangeText + node.Chars;
                        C = node.Chars;
                    }
                }
                if (sameRangeText.Length == 1)
                {
                   len= Recount(C, sameRangeText,len);
                    Text = Text + C;
                }
                else
                {
                    len++;
                }
                if (Same.Length > len)
                {
                    data = Same.Substring(len);
                    ddata = Convert.ToDecimal("0," + data);
                }
                else
                {
                    data = Same;
                    ddata = Convert.ToDecimal("0," + data);
                }
                
            }
            return Text;
        }

        private int Recount(char c, string data, int len)
        {
            foreach (Node node in Nodes)
            {
                if (node.Chars == c)
                {
                    Low = node.Low;
                    High = node.High;
                }
            }


            DellSamePart(data);



            decimal range = High - Low;

            foreach (Node node in Nodes)
            {

                node.Low = Low;
                var r = range * (decimal)(node.Range);
                Low = Low + r;
                node.High = Low;
                if (node.Low.ToString().Length - 2 < len)
                {
                    len = node.Low.ToString().Length;
                }
            }
            return len;
        }

        private void DellSamePart(string samepart)
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
            for (int i = 3; i < length; i++)
            {
                if (sLow[i] == sHigh[i]) same += sLow[i - 1];
                else
                {
                    if (same.Length != 0)
                    {
                        Same = Same.Remove(0,same.Length);
                        DelSamePart(samepart, sLow, sHigh);
                    }
                    break;
                }
            }
        }
        private void DelSamePart(string samepart, string sLow, string sHigh)
        {
            sLow = sLow.Remove(2, samepart.Length);
            sHigh = sHigh.Remove(2, samepart.Length);
            Low = Convert.ToDecimal(sLow);
            High = Convert.ToDecimal(sHigh);

        }
    }
}
