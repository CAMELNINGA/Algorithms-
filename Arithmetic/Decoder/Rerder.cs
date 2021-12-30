using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    class Rerder
    {
        List <Node> Nodes { get; set; }
        int count { get; set; }
        public (List<Node>,int) SplitString(string text)
        {
            
            Nodes = new List<Node>();
            string[] line = text.Split('\n');
            for (int  i=0; i< line.Length-2;i++)
            {
                char c;
                string s;
                if (line[i] != "")
                {
                    c = line[i][0];
                    s = line[i].Remove(0, 1);
                }
                else
                {
                     c = '\n';
                    i++;
                    s = line[i];
                }
                Nodes.Add(new Node(c, Convert.ToDouble(s)));
            }
           
            count = Convert.ToInt32(Nodes[Nodes.Count - 1].Range);

            Nodes.RemoveAt(Nodes.Count - 1);
            Nodes = AddRangeNode(count);
            return (Nodes, count);
        }
        private List<Node> AddRangeNode(int count)
        {
            decimal low = 0;
            foreach (Node node in Nodes)
            {
                node.Range = node.Range / count;
                node.Low = low;
                low += (decimal)node.Range;
                node.High = low;
            }
            return Nodes;
        }
    }
}
