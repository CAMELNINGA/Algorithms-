using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Arithmetic
{
    class Reader
     {
        Dictionary<char, int> _count;
        List<Node> nodes;
        public List<Node> Count(char[] chr)
        {
            _count = new Dictionary<char, int>();
            for (int i = 0; i < chr.Length; i++)
            {
                if (_count.Keys.Contains(Convert.ToChar(chr[i])))
                {
                    _count[Convert.ToChar(chr[i])]++ ;
                }
                else
                {
                    _count.Add(Convert.ToChar(chr[i]), 1);
                }
            }
            nodes = new List<Node>();
            foreach(var item in _count)
            {
                nodes.Add(new Node(item.Key, item.Value));
            }
            nodes = nodes.OrderByDescending(n=>n.Frequency).ToList();
            nodes = AddRangeNode(chr.Length);
            return nodes;
        }
        private List<Node> AddRangeNode( int lengh)
        {
            decimal low = 0;
             foreach (Node node in nodes)
            {
                node.Range = (double)node.Frequency/lengh ;
                node.Low = low;
                low += (decimal)node.Range;
                node.High = low;  
            }
            return nodes;
        }

        public string  Coding(string text , Dictionary<Node, string> dictionary)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (KeyValuePair<Node,string> i in dictionary)
            {
                d.Add(i.Key.Chars.ToString(), i.Value);
            }
            string line;
            string decode = "";
            while (text != "")
            {
                line = text[0].ToString();
                text = text.Remove(0, 1);
                while (!d.ContainsKey(line))
                {
                    line = line + text[0].ToString();
                    text = text.Remove(0, 1);

                }
                decode += d[line];
            }
            return decode;
        }
    }
}
