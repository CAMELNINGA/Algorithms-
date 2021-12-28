using System;
using System.Collections.Generic;
using System.Text;

namespace LZW
{
    class Lzw
    {
        public string Code { get; set; }

        public Dictionary<string, int> keys {get;set;}

        public string Text { get; set; }
        int Id { get; set; }

        string P { get; set; }
        string C { get; set; }
        string p_c { get; set; }
        public Lzw(string text)
        {
            Text = text;
            keys = new Dictionary<string, int>();
            char[] c = text.ToCharArray();
            Id = 0;
            foreach(char i in c)
            {
                if (!keys.ContainsKey(i.ToString()))
                {
                    AddDictonary(i.ToString());
                }
            }

        }
        public void Start()
        {
            char[] c = Text.ToCharArray();
            P = c[0].ToString();
            AddCode(P);
            if (c.Length > 1)
            {
                C = c[1].ToString();
                p_c = P + C;
                if (!keys.ContainsKey(p_c)) AddDictonary(p_c);
                P = C;
                for (int i = 2; i < c.Length; i++)
                {
                    C = c[i].ToString();
                    
                    p_c = P + C;
                    if (!keys.ContainsKey(p_c))
                    {
                        AddDictonary(p_c);
                        AddCode(P);
                        P = C;
                    }
                    else
                    {
                        P = P+C;
                    }
                        

                }
                AddCode(P);
                
            }
           
        }
    

        private void AddDictonary(string key)
        {
            if (!keys.ContainsKey(key))
            {
                keys.Add(key, Id);
                Id++;
            }
        }
        private void AddCode(string ps)
        {
            Code = Code + keys[ps];
        }

        
    }
}
