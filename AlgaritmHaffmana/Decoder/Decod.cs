using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    class Decod
    {
        public Dictionary<string, string> WDictonary(List<string> vs)
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            for (int i =0; i < vs.Count - 1; i++)
            {
                string l,o;
                string line = vs[i];
                if (line == "")
                {
                    i++;
                    line = line + vs[i];
                     l = "\n";
                    o = line;
                }
                else
                {
                     l = line[0].ToString();
                    line=line.Remove(0,1);
                     o = line;
                }
                
                valuePairs.Add(o, l);
            }
            return valuePairs;
        }

        public string  Decode(Dictionary<string,string> dictionary, string text)
        {
            string line;
            string decode="";
            while (text != "")
            {
                line = text[0].ToString();
                text=text.Remove(0, 1);
                while (!dictionary.ContainsKey(line))
                {
                    line= line+text[0].ToString();
                    text=text.Remove(0, 1);

                }
                decode += dictionary[line];
            }
            return decode;
        }

    }
}
