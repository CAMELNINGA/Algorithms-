using System;
using System.Collections.Generic;
using System.Text;

namespace LZW
{
    class DeLzw
    {
        public Dictionary<int,string> Keys { get; set; }
        string Code { get; set; }
        public string Text { get; set; }
        string P { get; set; }
        string C { get; set; }
        int Id { get; set; }
        string p_c { get; set; }
        public DeLzw(Dictionary<string ,int> keys,string code)
        {
            Id = 0;
            Keys = new Dictionary<int, string>();
            foreach (KeyValuePair<string,int> keyValuePair in keys)
            {
                Keys.Add(keyValuePair.Value, keyValuePair.Key);
                if(Id < keyValuePair.Value)
                {
                    Id = keyValuePair.Value;
                }
            }
            Id++;
            Code = code;
            Text = "";
           
        }
        public void Start()
        {
            string[] c = Code.Split('.');
            P = Keys[Convert.ToInt32(c[0])];
            AddText(P);
            C = Keys[Convert.ToInt32(c[1].ToString())];
            p_c = P + C;
            AddDictonary();
            P = C;
            for (int i = 2; i < c.Length; i++)
            {
                C= Keys[Convert.ToInt32(c[i].ToString())];
                
                AddText(P);
                
                p_c = P + C[0];
                
                if (!Keys.ContainsValue(p_c))
                    {
                        AddDictonary();
                      
                }

                P = C;
            }
            AddText(P);
                       
        }
        private void AddDictonary()
        {
            Keys.Add(Id, p_c);
            Id++;
        }
        private void AddText(string key)
        {
         Text = Text +  key;
           
        }

    }
}
